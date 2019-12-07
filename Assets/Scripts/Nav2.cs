using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav2 : MonoBehaviour
{
    public Transform[] objectives;
    public Transform target;
    private NavMeshAgent agent;
    private Color c = Color.white;
    public LineRenderer line;
    bool isActive = true;

    void Awake(){
        agent = gameObject.GetComponent<NavMeshAgent>();
        InstructionStylePicker inst = GameObject.Find("InstructionStylePicker").GetComponent<InstructionStylePicker>();
        if(inst.instructionStyle != 2){
            agent.enabled = false;
            line.enabled = false;
            this.enabled = false;
            isActive = false;
        }
    }

    public void Start()
    {
        if(isActive){
            target = objectives[0];
            agent.SetDestination(target.position);
            agent.isStopped = true ;//add this if you don't want to move the agent
        }
    }

    public void Update()
    {
        if(isActive){
            StartCoroutine(DrawPath());
        }
    }

    IEnumerator DrawPath()
    {
        NavMeshPath path;
        yield return new WaitForEndOfFrame();
        path = agent.path;
        if (path.corners.Length < 2)
            yield break;
        switch (path.status)
        {
            case NavMeshPathStatus.PathComplete:
                c = Color.white;
                break;
            case NavMeshPathStatus.PathInvalid:
                c = Color.red;
                break;
            case NavMeshPathStatus.PathPartial:
                c = Color.yellow;
                break;
        }

        Vector3 previousCorner = path.corners[0];

        for(int index = 0; index < path.corners.Length; index++){
            path.corners[index] = new Vector3(path.corners[index].x, path.corners[index].y+0.1f, path.corners[index].z);
        }

        int i = 1;
        //Debug.Log("Nro corners:" + path.corners.Length);
        while (i < path.corners.Length)
        {
            Vector3 currentCorner = path.corners[i];
            Debug.DrawLine(previousCorner, currentCorner, c);
            previousCorner = currentCorner;
            i++;
        }
        line.positionCount = path.corners.Length; //set the array of positions to the amount of corners

        line.SetPositions(path.corners); //set corner positions

    }

    public void ChangeObjective(int nextObjectiveIndex)
    {
        if(isActive){
            target = objectives[nextObjectiveIndex];
            agent.SetDestination(target.position);
        }
    }
}
