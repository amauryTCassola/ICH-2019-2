using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTest : MonoBehaviour
{
    Animator m_Animator;
    AudioSource m_AudioSource;
    const string animatorParamaterName = "DoorOpened";

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Interact() {
        if (!m_Animator.GetBool(animatorParamaterName))
        {
            m_Animator.SetBool(animatorParamaterName, true);
            m_AudioSource.Play();
        }
    }
}
