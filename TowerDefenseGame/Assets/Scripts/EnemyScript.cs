using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    private int index = 0;
    private Vector3 last;
    
    private Rigidbody rb;
    private LineRenderer lr;
    private NavMeshPath _path;
    [HideInInspector]
    public GameObject End { set; get; }

    private float yRadius;

    private GameObject par;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    public void Start()
    {
        yRadius = this.transform.localScale.y / 2;
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        lr = GetComponent<LineRenderer>();

        last = rb.position;
        agent.SetDestination(End.transform.position);
        
        _path = agent.path;
        
    }

    private void FixedUpdate()
    {
        if (Math.Abs(this.transform.position.x - End.transform.position.x) < 2 && (Math.Abs((this.transform.position.z + 5) - End.transform.position.z) < 2 ))
        {
            Destroy(gameObject);
        }
    }
    
    
    //Distance between two vectors
    
    
}