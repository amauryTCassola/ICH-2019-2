using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDetector : MonoBehaviour
{

    public GameObject EndMenu;
    public LevelTimer Timer;

    // Start is called before the first frame update
    void Start()
    {
        EndMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EndMenu.SetActive(true);
            Timer.StopTimer();
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
