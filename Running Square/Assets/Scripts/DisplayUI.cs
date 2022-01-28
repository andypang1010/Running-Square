using UnityEngine;
using TMPro;

public class DisplayUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text speedText;

    bool eggFound = false;
    bool gameComplete = false;
    bool showScore = true;

    void Start()
    {
        scoreText.text = "0 m";
        speedText.text = "0 kmph";
    }

    void Update()
    {
        if (gameComplete == true)
        {
            scoreText.SetText("COMPLETE!");
        }

        if (eggFound == true)
        {
            scoreText.SetText("2001.11.23");
            speedText.SetText("MON UNIQUE AMOUR");
        }

        if (showScore == true)
        {
            scoreText.SetText(transform.position.z.ToString("n0") + " M");
            speedText.SetText(GetComponent<Rigidbody>().velocity.z.ToString("n0") + " KMPH");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            gameComplete = false;
            eggFound = true;
            showScore = false;
        }

        if (collision.gameObject.tag == "Finish")
        {
            gameComplete = true;
            eggFound = false;
            showScore = false;
        }
    }
}
