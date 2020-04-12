using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public ObjectClicker sc;
    private float gravity;


    // --Example of JSON --
    public void Save()
    {
        // gets info from PlayerData
        PlayerData playerData = new PlayerData();
        // sets the saved score equal to the players score
        playerData.score = sc.score;

        // turns player's info into a string
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        // writes players info to a json file
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
        Debug.Log("File saved");
    }

    public void Load()
    {
        // reads the json file 
        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");

        // loads data
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log("score: " + loadedPlayerData.score);
    }

    public class PlayerData
    {
        public int score;
    }


    // --Example of Getters and Setters--
    // set the float for Gravity
    public float Gravity
    {
        get { return gravity; }

        // sets the gravity to earth, moon, or mars
        set {
            // if the gravity value that was input is equal to that of Earth's, the moon's, or Mars'
            if (value == -9.81f || value == -1.62f || value == -3.71f)
            {
                // set gravity equal to one of those three gravity values 
                gravity = value;
            }
            // if the gravity is not one of those 3 values
            else
            {
                // default to earths gravity if an invalid gravity value was inputted
                gravity = -9.81f;
                Debug.Log("Gravity is not that of Earth, Moon, or Mars. Defaulting to Earth gravity.");
            }
        }
    }

}
