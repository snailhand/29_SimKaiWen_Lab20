using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject wallObject;
    public GameObject goalObject;

    public int goalCount;

    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }

        for(int i = 0; i < 100; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-200, 200), 0.5f, Random.Range(-200, 200));
            Instantiate(wallObject, randomPos, Quaternion.identity);
        }

        Vector3 randomGoal = new Vector3(Random.Range(-50, 50), 2.5f, Random.Range(-50, 50));
        Instantiate(goalObject, randomGoal, Quaternion.identity);
        goalCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGoal()
    {
        if (goalCount != 1)
        {
            Vector3 randomGoal = new Vector3(Random.Range(-50, 50), 2.5f, Random.Range(-50, 50));
            Instantiate(goalObject, randomGoal, Quaternion.identity);
            goalCount = 1;
        }
    }
}
