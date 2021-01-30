using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActiveAI : MonoBehaviour
{

    public Transform[] RountineLocations;
    public int CRLN;
    public float Speed;
    public float ActiveDistance;

    public NavMeshAgentMover agentMover;

    [Space]
    public Transform FlashLight;
    public float FLRotateSpeed;
    //[Space]
    //NavMeshAgent navMeshAgent;



    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerActiveCollider")
        {
            GetComponent<ActiveAI>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CRLN = 0;
        agentMover.target = RountineLocations[CRLN];

        //navMeshAgent = GetComponent<NavMeshAgent>();
        //navMeshAgent.updateRotation = false;
        //navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(RountineLocations[CRLN].position, transform.position) <= ActiveDistance)
        {
            
            if (CRLN == RountineLocations.Length -1)
            {
                CRLN = 0;
                //print("again");
            }
            else
            {
                CRLN += 1;
            }

            agentMover.target = RountineLocations[CRLN];
            //navMeshAgent.SetDestination(RountineLocations[CRLN].position);
        }

        float angle = 0;

        Vector3 relative = FlashLight.transform.InverseTransformPoint(RountineLocations[CRLN].position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        FlashLight.transform.Rotate(0, 0, -angle*FLRotateSpeed);



    }
}
