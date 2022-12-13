using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Camera cam;
    GameObject player;

    float distanceToMove;
    public bool canMoveX, canMoveZ;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        canMoveZ = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                distanceToMove = Vector3.Distance(player.transform.position, hitInfo.collider.transform.position);

                if (canMoveX && canMoveZ)
                {
                    if (distanceToMove < 13 && (((hitInfo.collider.transform.position.x < player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > player.transform.position.x - 3)) || (hitInfo.collider.transform.position.z < player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > player.transform.position.z - 3)))
                    {
                        if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                        {
                            player.transform.position = new Vector3
                                (hitInfo.collider.transform.position.x, hitInfo.collider.transform.position.y + 2f, hitInfo.collider.transform.position.z);
                        }
                    }
                } else if(canMoveZ)
                {
                    if (distanceToMove < 13 && (hitInfo.collider.transform.position.x < player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > player.transform.position.x - 3) && (hitInfo.collider.transform.position.z > player.transform.position.z))
                    {
                        if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                        {
                            player.transform.position = new Vector3
                                (hitInfo.collider.transform.position.x, hitInfo.collider.transform.position.y + 2f, hitInfo.collider.transform.position.z);
                        }
                    }
                } else if (canMoveX)
                {
                    if (distanceToMove < 13 && (hitInfo.collider.transform.position.z < player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > player.transform.position.z - 3) && (hitInfo.collider.transform.position.z + 1 > player.transform.position.z))
                    {
                        if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                        {
                            player.transform.position = new Vector3
                                (hitInfo.collider.transform.position.x, hitInfo.collider.transform.position.y + 2f, hitInfo.collider.transform.position.z);
                        }
                    }
                }
            }
        }
    }
}
