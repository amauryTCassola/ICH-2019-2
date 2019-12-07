using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionStylePicker : MonoBehaviour
{

    public int instructionStyle;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        instructionStyle = Random.Range(0,3);
        Debug.Log(instructionStyle);
    }
}
