using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 5f;
    public Vector3 vel;
    public bool isPlaying;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        ResetBall();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isPlaying == false)
        {
            ResetAndSendBallInRandomDirection();
        }

        if(rb2D.velocity.magnitude < speed * 0.5f)
            ResetBall();
    }
    private void ResetBall()
    {
        rb2D.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        isPlaying = false;
    }

    private void ResetAndSendBallInRandomDirection()
    {
        ResetBall();
        rb2D.velocity = GenerateRandomVelovity(true) * speed;
        vel = rb2D.velocity;
        isPlaying = true;
    }

    private Vector3 GenerateRandomVelovity(bool shouldReturnNormalized)
    {
        Vector3 velocity = new Vector3();
        bool shouldGoRight = Random.Range(1, 100) > 50;
        velocity.x = shouldGoRight ? Random.Range(0.8f, 0.3f): Random.Range(-0.8f, -0.3f);
        velocity.y = shouldGoRight ? Random.Range(0.8f, 0.3f) : Random.Range(-0.8f, -0.3f);

        return shouldReturnNormalized ? velocity.normalized : velocity;  
        
        /*if (shouldReturnNormalized)
        {
            return velocity.normalized;             albo to zamiast returna wy¿ej
        }
        return velocity;*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2D.velocity = Vector3.Reflect(vel, collision.contacts[0].normal);
        Vector3 newVelocityWithOffset = rb2D.velocity;
        newVelocityWithOffset += new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
        rb2D.velocity = newVelocityWithOffset.normalized * speed;
        vel = rb2D.velocity;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
            print("Left Player +1");
        if (transform.position.x < 0)
            print("Right Player +1");

        ResetBall();
    }

    
}
