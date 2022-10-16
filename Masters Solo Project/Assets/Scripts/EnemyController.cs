using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator anim = null;
    [SerializeField] private Transform target;
    [SerializeField] private float stoppingDistance;
    private EnemyStats stats = null;
    private float timeOfLastAttack = 0f;
    private bool hasStopped = false;

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
        //RotateToTarget();

        float distanceToTaget = Vector3.Distance(transform.position, target.position);
        if (distanceToTaget <= stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);
            //attack
            if(!hasStopped)
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;
            } 
            
            if(Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;
                CharacterStats targetstats = target.GetComponent<CharacterStats>();
                AttackTarget(targetstats);
            }
            
        }
        else
        {
            if(hasStopped)
            {
                hasStopped = false;
            }
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

    private void AttackTarget(CharacterStats statsToDamage)
    {
        anim.SetTrigger("Attack");
        stats.DealDamage(statsToDamage);
    }

    private void GetReference()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        stats = GetComponent<EnemyStats>();

    }
}
