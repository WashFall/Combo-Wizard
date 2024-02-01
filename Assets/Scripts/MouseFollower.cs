using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public Transform player;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (GameManager.INSTANCE.gameIsPaused) { return; }

        float distanceToPlayer = Vector3.Distance(cam.transform.position, player.position);

        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToPlayer));
    }
}
