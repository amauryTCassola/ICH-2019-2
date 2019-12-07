using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartForm : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public TextPanelController startForm;
    public PlayerMove playerMove;
    public PlayerLook playerLook;
    public PlayerInteract playerInteract;


    void Start(){
        Pause();
    }

    public void Resume()
    {
        StartCoroutine(startForm.Close());
        playerMove.enabled = true;
        playerLook.enabled = true;
        playerInteract.enabled = true;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        playerMove.enabled = false;
        playerLook.enabled = false;
        playerInteract.enabled = false;
        GameIsPaused = true;
    }

}
