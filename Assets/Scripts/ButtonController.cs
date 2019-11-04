using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Light m_pointLight;
    private TubeLight m_tubeLight;
    private Color onColor = Color.green, offColor = Color.red;
    private bool isOn = false;

    public DoorController m_doorController;

    // Start is called before the first frame update
    void Start()
    {
        m_pointLight = GetComponentInChildren<Light>();
        m_tubeLight = GetComponentInChildren<TubeLight>();
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

    }
}
