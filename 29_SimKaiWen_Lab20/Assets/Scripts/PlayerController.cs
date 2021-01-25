using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 13f;
    public float rotateSpeed = 200f;
    public float jumpHeight = 10f;

    private float gravityMod = 3f;

    public GameManager gameManager;

    public Rigidbody playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -moveSpeed);
        }

        if(Input.GetKey(KeyCode.A))
        {
           transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Goal") && gameManager.goalCount == 1)
        {
            Destroy(collision.gameObject);
            gameManager.goalCount--;
            gameManager.ResetGoal();
        }
    }
}
