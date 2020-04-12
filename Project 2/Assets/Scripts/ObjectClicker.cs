using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectClicker : GameManager
{
    public Text scoreDisplay;
    public Enemy en;

    [HideInInspector]
    public int score;
    // Update is called once per frame
    void Update()
    {
        // shoots ray when the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
             RaycastHit hit;
            // shoots ray from the camera to the mouses position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "Cube")
                {
                    score++;
                    PrintName(hit.transform.gameObject);
                    Destroy(hit.transform.gameObject);
                }

                if(hit.collider.tag == "Enemy")
                {
                    PrintName(hit.transform.gameObject);
                    en.Health--;
                    Debug.Log(en.Health);
                }
            }
        }
        scoreDisplay.text = score.ToString();
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }
}
