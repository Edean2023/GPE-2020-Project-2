using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interfaces;

using Reset;

public class Player : GameManager, Idamageable<int>, Ikillable
{
    public CharacterController controller;

    public GameObject gameOver;
    public float speed = 12f;
    public float jumpHeight = 2f;
    //public float gravity;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    private int health;

    Vector3 velocity;

    void Start()
    {
        // --Example of Namespace
        // makes sure the player is at 0, 0, 0 on start
        transform.position = Position.ResetPosition();

        Health = 3;
        Gravity = -8.25f;
    }


    // --Example of Interfaces
    public int Health
    {
        get { return health; }
        set {
            // health is 3 by default
            health = 3;
            // if health is set to less than 3 (like when they take damage)
            if (value < 3)
            {
                // health is equal to that number
                health = value;
            }
            // makes sure that the health cannot be above 3
            else if (value > 3)
            {
                health = 3;
                Debug.Log("Health cannot be higher than 3. Defaulting to 3.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Kill();

        // checks if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // if the player is grounded 
        if (isGrounded && velocity.y < 0)
        {
            // set the player on the ground
            velocity.y = -2f;
        }

        // gets the horizontal and vertical axis for movement 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // moves the character in the proper direction and speed
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // makes the player jump if the space bar is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // jump 
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * Gravity);
        }

        // sets gravity for the player
        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity *Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Enemy"))
        {
            Debug.Log("Collided with Enemy");
            Health--;
            Debug.Log(health);
        }
    }

    // --Example of Interfaces
    public void Kill()
    {
        if (Health <= 0)
        {
            gameOver.SetActive(true);
        }
    }
}
