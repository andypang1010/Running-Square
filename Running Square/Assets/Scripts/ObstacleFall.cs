using UnityEngine;

public class ObstacleFall : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    float detectionRange = 50f;

    [SerializeField]
    float fallHeight = 11f;

    void Start()
    {
        transform.Translate(0, fallHeight, 0);
        enableFall(false);
    }

    void FixedUpdate()
    {
        // Start falling if the distance between the player and the obstacle
        // is smaller than range
        if (transform.position.z - playerTransform.position.z <= detectionRange)
        {
            enableFall(true);
        }
    }

    private void enableFall(bool b)
    {
        // Toggle the appearance and gravity of the obstacle
        GetComponent<Rigidbody>().useGravity = b;
        GetComponent<Renderer>().enabled = b;
    }
}
