using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Navigate : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetPosition;
    public float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed=moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetPosition.position);
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            agent.isStopped = true;
        }

    }
}
