using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartForm : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject startUI;

    void Start()
    {
        Pause();
    }

    public void Resume()
    {
        startUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        startUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
