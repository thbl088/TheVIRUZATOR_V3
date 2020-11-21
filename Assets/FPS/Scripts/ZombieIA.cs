using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieIA : MonoBehaviour
{
    [SerializeField] float stoppingDistance;

    float lastAttackTime=0;
    float attackColldown = 0;


    NacMeshAgent agent;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.postion, target.transform.position);
        if (dist < stoppingDistance)
        {
            StopEnemy();
            Attack();
            
        }
        else
        {
            GoToTarget();
        }
    }


    private void GoTotarget()
    {
        agent.isStopped = false;
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
    }

    private void Attack()
    {
        if(Time.time - lastAttackTime >=attackColldown)
        {
            lastAttackTime = Time.time;
            target.GetComponent < CharacterStats().TakeDamage(damage);
        }
    }
}
