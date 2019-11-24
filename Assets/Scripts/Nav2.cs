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

    public void Start()
    {
        target = objectives[0];
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
        agent.isStopped = true ;//add this if you don't want to move the agent
    }

    public void Update()
    {
        StartCoroutine(DrawPath());
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

        int i = 1;
        Debug.Log("Nro corners:" + path.corners.Length);
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
        target = objectives[nextObjectiveIndex];
        agent.SetDestination(target.position);
    }
}
