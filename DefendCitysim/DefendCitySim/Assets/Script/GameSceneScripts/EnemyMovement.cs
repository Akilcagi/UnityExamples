using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] targets; 
    public float speed = 5f; 
    private Transform target; 

    private void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target").Select(obj => obj.transform).ToArray();

        
        if (targets.Length > 0)
        {
            target = targets[Random.Range(0, targets.Length)];

        }
    }

    private void Update()
    {
        if (target != null)
        {
           
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
