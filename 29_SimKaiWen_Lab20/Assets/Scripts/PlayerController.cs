using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 13f;
    public float rotateSpeed = 200f;
    public float jumpHeight = 10f;

    private int jumpCount = 0;
    private float gravityMod = 3f;

    public GameManager gameManager;
    public ParticleSystem jumpParticle;
    public ParticleSystem smokeParticle;
    public ParticleSystem starParticle;

    public Rigidbody playerRb;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        var emission = smokeParticle.emission;


        //Player movement
        //playerRb.AddForce(Input.GetAxis("Vertical") * transform.forward * 10);
        //playerRb.velocity = new Vector3(Mathf.Clamp(playerRb.velocity.x, -10, 10), Mathf.Clamp(playerRb.velocity.y, -10, 10), Mathf.Clamp(playerRb.velocity.z, -10, 10));

        //When not moving
        if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S))
        {
            emission.rateOverTime = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            emission.rateOverTime = 10;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -moveSpeed);
            emission.rateOverTime = 10;
        }

        if(Input.GetKey(KeyCode.A))
        {
           transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space) && jumpCount == 0)
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumpParticle.Play();
            jumpCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Goal") && gameManager.goalCount == 1)
        {
            Destroy(collision.gameObject);
            gameManager.goalCount--;
            gameManager.ResetGoal();
        }

        if (collision.collider.CompareTag("Ground") && jumpCount != 0)
        {
            jumpCount = 0;
        }

        if (collision.collider.CompareTag("Wall"))
        {
            starParticle.Play();
        }
    }
}
