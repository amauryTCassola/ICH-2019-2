using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDetector : MonoBehaviour
{

    public Animator FadeOut;
    public LevelTimer Timer;
    public PlayerMove playerMove;
    public PlayerLook playerLook;
    public PlayerInteract playerInteract;
    public ObjectiveTextController objectiveController;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerMove.enabled = false;
            playerLook.enabled = false;
            playerInteract.enabled = false;
            Timer.StopTimer();
            Cursor.lockState = CursorLockMode.None;
            objectiveController.CloseCurrentObjective();
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene(){
        FadeOut.Play("FadeOut");
        yield return new WaitForSeconds(FadeOut.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
