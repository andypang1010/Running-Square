using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static bool playMusic = true;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Pause the BGM when player input is disabled
        if (!CharacterMovement.inputAllowed || !playMusic)
        {
            audioSource.Pause();
        }
    }
}
