using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public ParticleSystem goal;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Vector3 positionGoal = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
            Vector3 rotation = new Vector3(-90, 0, 0);

            Instantiate(goal, positionGoal, Quaternion.Euler(rotation));
            
        }
    }
}
