using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isSinner, isDevil;

    CardManager cardManager;
    GameManager gameManager;
    Movement movementCode;

    public bool isDead;
    public bool isRunAway;

    private void Start()
    {
        cardManager = GameObject.Find("CARD MANAGER").GetComponent<CardManager>();
        gameManager = GameObject.Find("GAME MANAGER").GetComponent<GameManager>();
        movementCode = GameObject.Find("GAME MANAGER").GetComponent<Movement>();
    }
    private void Update()
    {
        /*if(cardManager.isPlayed)
        {
            GetComponent<Player>().enabled = false;
        }*/
        if(gameManager.player != gameObject)
        {
            GetComponent<Player>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "MultipleDirectionCube")
        {
            movementCode.canMoveZ = true;
            movementCode.canMoveX = true;
        }
        if(col.gameObject.name == "CardCube")
        {
            if (isSinner) { cardManager.isSinnerChoosing = true; cardManager.isDevilChoosing = false; }
            if (isDevil) { cardManager.isSinnerChoosing = false; cardManager.isDevilChoosing = true; }
        }
        if(col.gameObject.tag == "XRotator")
        {
            movementCode.canMoveX = true;
            movementCode.canMoveZ = false;
        }
        if (col.gameObject.tag == "ZRotator")
        {
            movementCode.canMoveZ = true;
            movementCode.canMoveX = false;
        }
        if(isSinner && col.gameObject.tag == "Finish")
        {
            isRunAway = true;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "CardCube")
        {
            cardManager.CardRaritySystem();
        }
    }
}
