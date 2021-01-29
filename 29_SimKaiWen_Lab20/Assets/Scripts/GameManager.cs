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

        for(int i = 0; i < 70; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-25, 25), 0.5f, Random.Range(-25, 25));
            Instantiate(wallObject, randomPos, Quaternion.identity);
        }

        Vector3 randomGoal = new Vector3(Random.Range(-5, 5), 2.5f, Random.Range(-5, 5));
        Instantiate(goalObject, randomGoal, Quaternion.identity);
        goalCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        print(goalCount);
    }

    public void ResetGoal()
    {
        if (goalCount == 0)
        {
            Vector3 randomGoal = new Vector3(Random.Range(-10, 10), 2.5f, Random.Range(-10, 10));
            Instantiate(goalObject, randomGoal, Quaternion.identity);
            goalCount++;
        }
    }
}
