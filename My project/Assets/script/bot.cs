
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class bot : MonoBehaviour
{
    // Start is called before the first frame update

    public NavMeshAgent agent;
    public GameObject target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.hasPath)
        {
            if (target != null)
            {

                agent.SetDestination(target.transform.position);

            }//end of if inside

        }//end if

    }
}
