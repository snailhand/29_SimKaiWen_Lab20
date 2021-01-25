using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 cameraPos1 = new Vector3(0,8,-8);
    Vector3 cameraPos2 = new Vector3(0,14,0);

    public float cameraSpeed = 16;

    public GameObject Player;

    private void Start()
    {
        
    }

    void Update()
    {
        FollowPlayer(Time.deltaTime);
        CameraChangeView(Time.deltaTime);
    }

    private void FollowPlayer(float t)
    {
        float speed = cameraSpeed * t;
        Vector3 playerPosition = Vector3.Lerp(transform.position, Player.transform.position + cameraPos1, speed);
        transform.position = playerPosition;
    }

    private void CameraChangeView(float t)
    {
        float speed = cameraSpeed * t;
        if (Input.GetKey(KeyCode.Tab))
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position + cameraPos2, cameraSpeed);
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position + cameraPos1, speed);
            transform.rotation = Quaternion.Euler(40f, 0, 0);
        }

    }
}
