using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Missile : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    public float damage;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
    }
}
