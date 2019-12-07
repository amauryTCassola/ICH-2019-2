using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{

    public string text;
    public float theTime = 0;
    public float speed = 1;
    private bool playing = true;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            theTime += Time.deltaTime * speed;
            string hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00");
            string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            string seconds = (theTime % 60).ToString("00");
            text = hours + ":" + minutes + ":" + seconds;
        }
       
    }

    public void StopTimer()
    {
        playing = false;
    }

    public void StartTimer()
    {
        playing = true;
    }

}

