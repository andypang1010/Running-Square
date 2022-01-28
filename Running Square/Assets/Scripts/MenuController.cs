using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public void AccessMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToggleMusic()
    {
        if (AudioController.playMusic != true)
        {
            AudioController.playMusic = true;
            transform.GetChild(0).GetComponent<TMP_Text>().SetText("Music: On");        }
        else
        {
            AudioController.playMusic = false;
            transform.GetChild(0).GetComponent<TMP_Text>().SetText("Music: Off");
        }
    }

    public void Quit()
    {
        Application.Quit(0);
    }
}
