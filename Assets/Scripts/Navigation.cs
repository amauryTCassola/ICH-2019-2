using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public LineRenderer line; //to hold the line Renderer
    public Transform target; //to hold the transform of the target
    public NavMeshAgent agent; //to hold the agent of this gameObject


    // Update is called once per frame
    void Update()
    {
        //GetPath();
        line.SetPosition(0, transform.position); //set the line's origin

        agent.SetDestination(target.position); //create the path
    }

    private void LateUpdate()
    {
        DrawPath(agent.path);

        agent.isStopped = true; ;//add this if you don't want to move the agent
    }

    void Start()
    {
        line = gameObject.GetComponent(typeof(LineRenderer)) as LineRenderer; //get the line renderer
        agent = gameObject.GetComponent(typeof(NavMeshAgent)) as NavMeshAgent; //get the agent
        
    }

    private void GetPath()
    {
        line.SetPosition(0, transform.position); //set the line's origin

        agent.SetDestination(target.position); //create the path
        //yield return new WaitForEndOfFrame(); //wait for the path to generate

        DrawPath(agent.path);

        agent.isStopped = true; ;//add this if you don't want to move the agent
    }

    void DrawPath(NavMeshPath path)
    {
        //if (path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            //return;

        line.positionCount = path.corners.Length; //set the array of positions to the amount of corners

        line.SetPositions(path.corners); //set corner positions
        
    }
}
