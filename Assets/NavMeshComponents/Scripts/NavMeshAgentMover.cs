    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentMover : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Transform target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }
}
