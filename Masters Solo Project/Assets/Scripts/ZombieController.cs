using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator anim = null;
    [SerializeField] private Transform target;
    [SerializeField] private float stoppingDistance;

    private void Start()
    {
        GetReference();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        float distanceToTaget = Vector3.Distance(transform.position, target.position);
        if (distanceToTaget <= stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);
        }

        //float distanceToTaget = Vector3.Distance(transform.position, target.position);

        //if(distanceToTaget <= stoppingDistance)
        //{
        //    RotateToTarget();
        //}
    }

    private void RotateToTarget()
    {
        transform.LookAt(target);

        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void GetReference()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }
}
