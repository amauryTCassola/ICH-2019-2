using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectiveTextController : MonoBehaviour
{

    public Animator[] objectives;
    int currentObjective = 0;
    List<int> completedObjectives;
    bool isActive = true;

    void Awake(){
        InstructionStylePicker inst = GameObject.Find("InstructionStylePicker").GetComponent<InstructionStylePicker>();
        if(inst.instructionStyle != 1){
            this.enabled = false;
            isActive = false;
        }
        completedObjectives = new List<int>();
    }

    void Start(){
        objectives[0].Play("ObjectiveOpen");
    }

    public void ObjectiveCompleted(int objectiveNumber){
        if(isActive){
            Debug.Log("OBJECTIVE COMPLETED");
            if(currentObjective == objectiveNumber)
                StartCoroutine(OpenNextObjective());
            else if(objectiveNumber > currentObjective)
                completedObjectives.Add(objectiveNumber);
        }
    }

    IEnumerator OpenNextObjective(){
        objectives[currentObjective].Play("ObjectiveClose");
        yield return new WaitForSeconds(objectives[currentObjective].GetCurrentAnimatorStateInfo(0).length);
        currentObjective++;

        while(completedObjectives.Contains(currentObjective))
            currentObjective++;

        if(currentObjective < objectives.Length){
            objectives[currentObjective].Play("ObjectiveOpen");
            yield return new WaitForSeconds(objectives[currentObjective].GetCurrentAnimatorStateInfo(0).length);
        }
    }

    public void CloseCurrentObjective(){
        if(isActive)
            objectives[currentObjective].Play("ObjectiveClose");
    }
}
