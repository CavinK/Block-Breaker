using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // configuration parameters
    [SerializeField] Paddle paddle1; // drag paddle object to the field on inspector
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = .2f;

    // state
    Vector2 paddleToBallVector; // difference between paddle and ball
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position; // (0,1)
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() // paddle is moving before ball <- define the order on script execution order on Unity(not to make ball slide on paddle)
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // 0: left click
        {
            hasStarted = true; // prevent ball from being stuck above paddle even after clicking
            myRigidBody2D.velocity = new Vector2(xPush, yPush); // this method allows us to access components on inspector // set values on Vector2 part to make ball go up to the right
        }
    }

    private void LockBallToPaddle() // ball's new position <- make ball stick to paddle with pivots
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2( // both System and UnityEngine namespace have the concept of Random
            UnityEngine.Random.Range(0f, randomFactor), // x
            UnityEngine.Random.Range(0f, randomFactor)); // y
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]; // randomisation of the array
            myAudioSource.PlayOneShot(clip); // this method is to play the sound effect // PlayOneShot(): prevent multiple sounds from interupting each other
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
