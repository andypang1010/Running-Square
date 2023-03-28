using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int frameRate = 30;

    void Start()
    {
        Application.targetFrameRate = frameRate;
    }
}
