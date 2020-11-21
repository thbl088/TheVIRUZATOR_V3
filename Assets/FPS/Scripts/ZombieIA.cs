using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieIA : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float stoppingDistance;

    public Health health
    {
        get; private set;
    }
    float lastAttackTime = 0;
    float attackColldown = 1;


    NavMeshAgent agent;

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
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist > stoppingDistance)
        {
            StopEnemy();

        }
        else
        {
            GoToTarget();
        }
    }


    private void GoToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
    }

    private void Attack()
    {
       

        if (Time.time - lastAttackTime >= attackColldown)
        {
            lastAttackTime = Time.time;
            target.GetComponent<Health>().takeDamage(damage);
        }
    }

    void OnCollisionEnter(Collision col)
    {
    
        if (col.gameObject.tag == "Player")
        {
            Attack();
        }
        /*  void OnCollisionEnter(Collision collision)
           {
             Debug.Log("collison ok");
             ZombieIA other = collision.gameObject.GetComponent<ZombieIA>();
               if (other)
               {
                 Attack();
               }
           }*/
    }
}
