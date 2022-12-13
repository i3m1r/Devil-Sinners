using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isSinner, isDevil;

    [SerializeField] CardManager cardManager;
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "MultipleDirectionCube")
        {
            GameObject.Find("GAME MANAGER").GetComponent<Movement>().canMoveZ = true;
            GameObject.Find("GAME MANAGER").GetComponent<Movement>().canMoveX = true;
        }
        if(col.gameObject.name == "CardCube")
        {
            if (isSinner) { cardManager.isSinnerChoosing = true; cardManager.isDevilChoosing = false; }
            if (isDevil) { cardManager.isSinnerChoosing = false; cardManager.isDevilChoosing = true; }
        }
        if(col.gameObject.tag == "XRotator")
        {
            GameObject.Find("GAME MANAGER").GetComponent<Movement>().canMoveX = true;
            GameObject.Find("GAME MANAGER").GetComponent<Movement>().canMoveZ = false;
        }
        if (col.gameObject.tag == "ZRotator")
        {
            GameObject.Find("GAME MANAGER").GetComponent<Movement>().canMoveZ = true;
            GameObject.Find("GAME MANAGER").GetComponent<Movement>().canMoveX = false;
        }
    }
}
