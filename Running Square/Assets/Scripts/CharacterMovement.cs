using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public static bool inputAllowed;

    Rigidbody rigidBody;

    public Material hitMaterial;

    [SerializeField]
    float controlSpeed = 9.5f;

    [SerializeField]
    float movementSpeed = 600f;

    // Allows user input and set the transformation and rotation of the player object
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezeRotation;

        inputAllowed = true;
        transform.position = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        if (inputAllowed == true)
        {
            ProcessMovement();

            // If the player has fallen off the plane
            if (transform.position.y < -1)
            {
                PlayerLost();

                // Prevents the player from increasing the score after falling
                rigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
                Invoke("ExitGame", 3f);
            }

            // If the player is on the edge of the plane
            if (transform.position.x >= 5 || transform.position.x <= -5)
            {
                // Allows the player to tilt in case falling
                rigidBody.constraints = RigidbodyConstraints.None;
            }
            else
            {
                // Resets the rotation of the player when returning to plane
                transform.rotation = new Quaternion(0, 0, 0, 0);
                rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
    }

    void ProcessMovement()
    {
        // Gets the input values and add force to the rigidbody
        float horizontalMovement =
            Input.GetAxis("Horizontal") * controlSpeed * Time.smoothDeltaTime;
        float forwardMovement = movementSpeed * Time.smoothDeltaTime;
        transform.Translate(new Vector3(horizontalMovement, 0, 0));
        rigidBody.AddForce(new Vector3(0, 0, forwardMovement));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            PlayerLost();
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            Invoke("ExitGame", 3f);
        }
        else if (collision.gameObject.tag == "Finish")
        {
            DisableInputs();
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
        // Secret easter egg
        else if (collision.gameObject.tag == "Egg")
        {
            transform.position = new Vector3(0, 0, 4700);
        }
    }

    // Disables player from sending input and allow all transformations
    private void DisableInputs()
    {
        inputAllowed = false;
        rigidBody.constraints = RigidbodyConstraints.None;
    }

    // Calls DisableInputs() and set the player material as the hit material
    private void PlayerLost()
    {
        DisableInputs();
        GetComponent<Renderer>().material = hitMaterial;
    }

    // Exits the game scene and show main menu
    private void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
