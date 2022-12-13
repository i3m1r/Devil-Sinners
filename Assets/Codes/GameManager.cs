using UnityEngine;

public class GameManager : MonoBehaviour
{
    Camera cam;
    [SerializeField] Vector3 camDistance;

    GameObject player;

    bool areCubesSelectable;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
    }
    private void FixedUpdate()
    {
        cam.transform.position = player.transform.Find("CameraPosition").transform.position;
        cam.transform.LookAt(player.transform.position);
    }
}
