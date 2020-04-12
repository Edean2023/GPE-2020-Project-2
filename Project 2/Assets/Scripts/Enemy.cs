using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interfaces;

public class Enemy : MonoBehaviour, Idamageable<int>, Ikillable
{
    private int health;

    void Start()
    {
        Health = 4;
    }

    void Update()
    {
        Kill();
    }

    // --Example of Interfaces
    public int Health
    {
        get { return health; }
        set
        {
            // health is 3 by default
            health = 3;
            // if health is set to less than 3 (like when they take damage)
            if (value < 3)
            {
                // health is equal to that number
                health = value;
            }
            else if(value > 3)
            {
                health = 3;
                Debug.Log("Enemy health cannot be higher than 3. Defaulting to 3.");
            }
        }
    }

    // --Example of Interfaces
    public void Kill()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
