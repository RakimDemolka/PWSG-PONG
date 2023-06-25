using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;


    void Start()
    {
        Debug.Log("Start");
    }

    
    void Update()
    {
        // transform.position = transform.position + Vector3.up;         to alternatywa +=
       // transform.position += Vector3.up * Time.deltaTime;

        if (Input.GetKey(upKey) && transform.position.y < 3.75)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        
        if (Input.GetKey(downKey) && transform.position.y > -3.75)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }
}
