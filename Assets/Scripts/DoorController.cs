using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator m_Animator;
    AudioSource m_AudioSource;
    const string animatorParamaterOpen = "DoorOpened", animatorParamaterClose = "DoorClosed";

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void OpenDoor()
    {
        m_Animator.SetBool(animatorParamaterClose, false);
        m_Animator.SetBool(animatorParamaterOpen, true);
        m_AudioSource.Play();
    }

    public void CloseDoor()
    {
        m_Animator.SetBool(animatorParamaterOpen, false);
        m_Animator.SetBool(animatorParamaterClose, true);
        m_AudioSource.Play();
    }
}
