using UnityEngine;

public class GameManager : MonoBehaviour
{
    Camera cam;
    [SerializeField] Vector3 camDistance;
    public float cameraSpeed = 13.5f;

    CardManager cardManager;
    public GameObject player;

    public Player[] players;
    public int currentPlayer;
    void Start()
    {
        currentPlayer = 0;
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        cardManager = GameObject.Find("CARD MANAGER").GetComponent<CardManager>();
    }
    void Update()
    {
        //SIRA MEVZUSU YAZILACAK
        player = players[currentPlayer].gameObject;
        players[currentPlayer].enabled = true;

        if(players[currentPlayer].isDead || players[currentPlayer].isRunAway)
        {
            cardManager.isPlayed = true;
        }
        if (cardManager.isPlayed)
        {
            if(currentPlayer == 5)
            {
                currentPlayer = 0;
            } else
            {
                currentPlayer++;
            }
            cardManager.isPlayed = false;
        }
    }
    private void FixedUpdate()
    {
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, player.transform.Find("CameraPosition").transform.position, cameraSpeed * Time.deltaTime);
    }
}
