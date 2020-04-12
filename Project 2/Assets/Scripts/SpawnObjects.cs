using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    private GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        // finds the sphere prefab in the resource folder
        sphere = Resources.Load<GameObject>("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        // spanws that prefab when I press 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(sphere);
        }
    }
}
