using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public TextPanelController menuPanel;

    public void StartPlayGame()
    {
        StartCoroutine(PlayGame());
    }

    IEnumerator PlayGame(){
        yield return menuPanel.Close();
        menuPanel.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartQuitGame(){
        StartCoroutine(QuitGame());
    }

    public IEnumerator QuitGame()
    {
        yield return menuPanel.Close();
        menuPanel.gameObject.SetActive(false);
        Application.Quit();
    }

}
