using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPanelController : MonoBehaviour
{

    public Animator[] children;
    Animator thisAnimator;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClosing(){
        StartCoroutine(Close());
    }

    public IEnumerator Close(){
        foreach(Animator anim in children){
            anim.SetBool("ShouldClose", true);
        }

        if(children.Length > 0)
            yield return new WaitForSeconds(children[0].GetCurrentAnimatorStateInfo(0).length);

        thisAnimator.Play("TextPanelClose");

        yield return new WaitForSeconds(thisAnimator.GetCurrentAnimatorStateInfo(0).length);
    }
}
