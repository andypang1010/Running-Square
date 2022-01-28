using UnityEngine;

public class ObstacleSpin : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 10f;
    bool collided = false;

    void Update()
    {
        if (!collided)
        {
            transform.Rotate(new Vector3(0, rotateSpeed * Time.smoothDeltaTime, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collided = true;
        }
    }
}
