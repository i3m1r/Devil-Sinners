using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] Camera cam;
    public GameObject player;
    CardManager cardManager;
    GameManager gameManager;

    public float distanceToMove;
    public bool canMoveX, canMoveZ, canMove;
    RaycastHit mainHitInfo;
    bool playMovementAnimation = false;
    void Start()
    {
        canMoveZ = true;
        canMove = true;

        cardManager = GameObject.Find("CARD MANAGER").GetComponent<CardManager>();
        gameManager = GameObject.Find("GAME MANAGER").GetComponent<GameManager>();
    }

    void Update()
    {
        player = gameManager.player;
        if (Input.GetMouseButtonDown(0) && canMove && cardManager.cardPanel.activeSelf == false)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                mainHitInfo = hitInfo;
                distanceToMove = Vector3.Distance(player.transform.position, hitInfo.collider.transform.position);

                //Check if selectable cube is a platform
                if(hitInfo.collider.gameObject.name == "EmptyCube" || hitInfo.collider.gameObject.name == "CardCube" || hitInfo.collider.gameObject.name == "MinigameCube" || hitInfo.collider.gameObject.name == "MultipleDirectionCube")
                {
                    if (canMoveX && canMoveZ)
                    {
                        if (distanceToMove < 13 && (((hitInfo.collider.transform.position.x < player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > player.transform.position.x - 3)) || (hitInfo.collider.transform.position.z < player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > player.transform.position.z - 3)))
                        {
                            if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                            {
                                playMovementAnimation = true;
                            }
                        }
                    } else if(canMoveZ)
                    {
                        if (distanceToMove < 13 && (hitInfo.collider.transform.position.x < player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > player.transform.position.x - 3) && (hitInfo.collider.transform.position.z > player.transform.position.z))
                        {
                            if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                            {
                                playMovementAnimation = true;
                            }
                        }
                    } else if (canMoveX)
                    {
                        if (distanceToMove < 13 && (hitInfo.collider.transform.position.z < player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > player.transform.position.z - 3) && (hitInfo.collider.transform.position.z + 1 > player.transform.position.z))
                        {
                            if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                            {
                                playMovementAnimation = true;
                            }
                        }
                    }
                }

                //Check if selectable cube is a portal
                if(hitInfo.collider.gameObject.name == "Portal")
                {
                    if (canMoveX && canMoveZ)
                    {
                        if (distanceToMove < 13 && (((hitInfo.collider.transform.position.x < player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > player.transform.position.x - 3)) || (hitInfo.collider.transform.position.z < player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > player.transform.position.z - 3)))
                        {
                            if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                            {
                                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                            }
                        }
                    }
                    else if (canMoveZ)
                    {
                        if (distanceToMove < 13 && (hitInfo.collider.transform.position.x < player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > player.transform.position.x - 3) && (hitInfo.collider.transform.position.z > player.transform.position.z))
                        {
                            if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                            {
                                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                            }
                        }
                    }
                    else if (canMoveX)
                    {
                        if (distanceToMove < 13 && (hitInfo.collider.transform.position.z < player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > player.transform.position.z - 3) && (hitInfo.collider.transform.position.z + 1 > player.transform.position.z))
                        {
                            if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                            {
                                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                            }
                        }
                    }
                }

                //Check if selectable object is a player as sinner
                if ((hitInfo.collider.gameObject.name == "Sinner1" || hitInfo.collider.gameObject.name == "Sinner2" || hitInfo.collider.gameObject.name == "Sinner3") && player.GetComponent<Player>().isDevil)
                {
                    if (canMoveX && canMoveZ)
                    {
                        if (distanceToMove < 7 && (((hitInfo.collider.transform.position.x < player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > player.transform.position.x - 3)) || (hitInfo.collider.transform.position.z < player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > player.transform.position.z - 3)))
                        {
                            if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                            {
                                hitInfo.collider.gameObject.GetComponent<Player>().isDead = true;
                                cardManager.isPlayed = true;
                            }
                        }
                    }
                    else if (canMoveZ)
                    {
                        if (distanceToMove < 7 && (hitInfo.collider.transform.position.x < player.transform.position.x + 3) && (hitInfo.collider.transform.position.x > player.transform.position.x - 3) && (hitInfo.collider.transform.position.z > player.transform.position.z))
                        {
                            if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                            {
                                hitInfo.collider.gameObject.GetComponent<Player>().isDead = true;
                                cardManager.isPlayed = true;
                            }
                        }
                    }
                    else if (canMoveX)
                    {
                        if (distanceToMove < 7 && (hitInfo.collider.transform.position.z < player.transform.position.z + 3) && (hitInfo.collider.transform.position.z > player.transform.position.z - 3) && (hitInfo.collider.transform.position.z + 1 > player.transform.position.z))
                        {
                            if (hitInfo.collider.gameObject.GetComponent<SelectableObject>() != null)
                            {
                                hitInfo.collider.gameObject.GetComponent<Player>().isDead = true;
                                cardManager.isPlayed = true;
                            }
                        }
                    }
                }
            }
        }
        if(playMovementAnimation) StartCoroutine(MovementAnimation());
    }

    IEnumerator MovementAnimation()
    {
        canMove = false;
        if(player.transform.position.y > 0f)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x, mainHitInfo.collider.transform.position.y + 4f, player.transform.position.z), 10f * Time.deltaTime);

            if(player.transform.position == new Vector3(player.transform.position.x, mainHitInfo.collider.transform.position.y + 4f, player.transform.position.z))
            {
                yield return new WaitForSeconds(0.2f);

                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(mainHitInfo.collider.transform.position.x, player.transform.position.y, mainHitInfo.collider.transform.position.z), 20f * Time.deltaTime);

                if(player.transform.position == new Vector3(mainHitInfo.collider.transform.position.x, player.transform.position.y, mainHitInfo.collider.transform.position.z))
                {
                    yield return new WaitForSeconds(0.2f);

                    player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(mainHitInfo.collider.transform.position.x, mainHitInfo.collider.transform.position.y + 2f, mainHitInfo.collider.transform.position.z), 10f * Time.deltaTime);

                    yield return new WaitForSeconds(0.2f);

                    playMovementAnimation = false;

                    //can move kaldýrýlacak!
                    canMove = true;
                }
            }
        }
    }
}
