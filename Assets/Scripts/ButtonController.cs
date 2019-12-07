﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Light m_pointLight;
    private TubeLight m_tubeLight;
    private Color onColor = Color.green, offColor = Color.red;
    private bool isOn = false;
    public Nav2 playerNavigation;
    public ObjectiveTextController objectiveController;
    public int nextObjectiveIndex;
    public int objectiveTextIndex;

    public DoorController m_doorController;

    // Start is called before the first frame update
    void Start()
    {
        m_pointLight = GetComponentInChildren<Light>();
        m_tubeLight = GetComponentInChildren<TubeLight>();
        objectiveController = GameObject.Find("ObjectiveTextController").GetComponent<ObjectiveTextController>();
    }

    void Interact() {
        if (!isOn)
        {
            isOn = true;
            m_pointLight.color = onColor;
            m_tubeLight.m_Color = onColor;
            m_doorController.OpenDoor();
        }
        else {
            isOn = false;
            m_pointLight.color = offColor;
            m_tubeLight.m_Color = offColor;
            m_doorController.CloseDoor();
        }

        if(objectiveController){
            objectiveController.ObjectiveCompleted(objectiveTextIndex);
        }

        if (playerNavigation)
        {
            playerNavigation.ChangeObjective(nextObjectiveIndex);
        }

    }
}
