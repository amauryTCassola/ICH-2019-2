using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public Animator[] children;
    public Animator thisAnimator;

    public LevelTimer Timer;

    void Start()
    {
        //pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //pauseMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        Timer.StartTimer();
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartClosing();
    }

    void Pause()
    {
        //pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        Timer.StopTimer();
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        StartOpening();
    }

    public void StartClosing()
    {
        StartCoroutine(Close());
    }

    public IEnumerator Close()
    {
        foreach (Animator anim in children)
        {
            anim.SetBool("ShouldClose", true);
        }

        if (children.Length > 0)
            yield return new WaitForSeconds(children[0].GetCurrentAnimatorStateInfo(0).length);

        thisAnimator.Play("PausePanelClosing");

        yield return new WaitForSeconds(thisAnimator.GetCurrentAnimatorStateInfo(0).length);
    }

    public void StartOpening()
    {
        StartCoroutine(Open());
    }

    public IEnumerator Open()
    {
        foreach (Animator anim in children)
        {
            anim.SetBool("ShouldClose", true);
        }

        if (children.Length > 0)
            yield return new WaitForSeconds(children[0].GetCurrentAnimatorStateInfo(0).length);

        thisAnimator.Play("PausePanelOpening");

        yield return new WaitForSeconds(thisAnimator.GetCurrentAnimatorStateInfo(0).length);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
