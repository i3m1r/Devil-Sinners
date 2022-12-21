using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    private Renderer renderer;

    CardManager cardManager;
    GameManager gameManager;
    Movement movementCode;

    Camera cam;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        cardManager = GameObject.Find("CARD MANAGER").GetComponent<CardManager>();
        gameManager = GameObject.Find("GAME MANAGER").GetComponent<GameManager>();
        movementCode = GameObject.Find("GAME MANAGER").GetComponent<Movement>();

        cam = GameObject.Find("CAMERA").GetComponent<Camera>();
    }

    private void OnMouseEnter()
    {
        float distanceToMove;
        if(cardManager.cardPanel.activeSelf == false)
        {
            if (movementCode && cardManager.cardPanel.activeSelf == false)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    distanceToMove = Vector3.Distance(gameManager.player.transform.position, hitInfo.collider.transform.position);

                    //Check if selectable cube is a platform
                    if (hitInfo.collider.gameObject.name == "EmptyCube" || hitInfo.collider.gameObject.name == "CardCube" || hitInfo.collider.gameObject.name == "MinigameCube" || hitInfo.collider.gameObject.name == "MultipleDirectionCube")
                    {
                        if (movementCode.canMoveX && movementCode.canMoveZ)
                        {
                            if (distanceToMove < 13 && (((hitInfo.collider.transform.position.x < gameManager.player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > gameManager.player.transform.position.x - 3)) || (hitInfo.collider.transform.position.z < gameManager.player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > gameManager.player.transform.position.z - 3)))
                            {
                                if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                                {
                                    renderer.material.color = Color.red;
                                }
                            }
                        }
                        else if (movementCode.canMoveZ)
                        {
                            if (distanceToMove < 13 && (hitInfo.collider.transform.position.x < gameManager.player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > gameManager.player.transform.position.x - 3) && (hitInfo.collider.transform.position.z > gameManager.player.transform.position.z))
                            {
                                if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                                {
                                    renderer.material.color = Color.red;
                                }
                            }
                        }
                        else if (movementCode.canMoveX)
                        {
                            if (distanceToMove < 13 && (hitInfo.collider.transform.position.z < gameManager.player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > gameManager.player.transform.position.z - 3) && (hitInfo.collider.transform.position.z + 1 > gameManager.player.transform.position.z))
                            {
                                if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                                {
                                    renderer.material.color = Color.red;
                                }
                            }
                        }
                    }


                    //Check if selectable cube is a portal
                    if (hitInfo.collider.gameObject.name == "Portal")
                    {
                        if (movementCode.canMoveX && movementCode.canMoveZ)
                        {
                            if (distanceToMove < 13 && (((hitInfo.collider.transform.position.x < gameManager.player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > gameManager.player.transform.position.x - 3)) || (hitInfo.collider.transform.position.z < gameManager.player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > gameManager.player.transform.position.z - 3)))
                            {
                                if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                                {
                                    renderer.material.color = Color.red;
                                }
                            }
                        }
                        else if (movementCode.canMoveZ)
                        {
                            if (distanceToMove < 13 && (hitInfo.collider.transform.position.x < gameManager.player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > gameManager.player.transform.position.x - 3) && (hitInfo.collider.transform.position.z > gameManager.player.transform.position.z))
                            {
                                if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                                {
                                    renderer.material.color = Color.red;
                                }
                            }
                        }
                        else if (movementCode.canMoveX)
                        {
                            if (distanceToMove < 13 && (hitInfo.collider.transform.position.z < gameManager.player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > gameManager.player.transform.position.z - 3) && (hitInfo.collider.transform.position.z + 1 > gameManager.player.transform.position.z))
                            {
                                if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                                {
                                    renderer.material.color = Color.red;
                                }
                            }
                        }
                    }

                    //Check if player is sinner
                    if ((hitInfo.collider.gameObject.name == "Sinner1" || hitInfo.collider.gameObject.name == "Sinner2" || hitInfo.collider.gameObject.name == "Sinner3") && gameManager.player.GetComponent<Player>().isDevil)
                    {
                        if (movementCode.canMoveX && movementCode.canMoveZ)
                        {
                            if (distanceToMove < 7 && (((hitInfo.collider.transform.position.x < gameManager.player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > gameManager.player.transform.position.x - 3)) || (hitInfo.collider.transform.position.z < gameManager.player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > gameManager.player.transform.position.z - 3)))
                            {
                                if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                                {
                                    renderer.material.color = Color.red;
                                }
                            }
                        }
                        else if (movementCode.canMoveZ)
                        {
                            if (distanceToMove < 7 && (hitInfo.collider.transform.position.x < gameManager.player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > gameManager.player.transform.position.x - 3) && (hitInfo.collider.transform.position.z > gameManager.player.transform.position.z))
                            {
                                if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                                {
                                    renderer.material.color = Color.red;
                                }
                            }
                        }
                        else if (movementCode.canMoveX)
                        {
                            if (distanceToMove < 7 && (hitInfo.collider.transform.position.z < gameManager.player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > gameManager.player.transform.position.z - 3) && (hitInfo.collider.transform.position.z + 1 > gameManager.player.transform.position.z))
                            {
                                if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                                {
                                    renderer.material.color = Color.red;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
