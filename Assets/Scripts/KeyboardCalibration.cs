using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KeyboardCalibration : MonoBehaviour
{
    public Transform Camera;
    public float moveSpeed = 10f;
    Vector3 move = new Vector3();
    public string filePath;
    void Start()
    { 
        filePath = Path.Combine(Application.dataPath, "positions.txt");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))  // Enter key is pressed
        {
            SavePositionToFile();
        }

        move = new Vector3();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move.y += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move.y -= 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move.x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move.x += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.z -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            move.z += 1;
        }
        Camera.position+= move * moveSpeed * Time.deltaTime;
        
    }
    void SavePositionToFile()
    {
        Vector3 position = transform.position;
        string positionString = "Position: " + position.ToString();
        File.AppendAllText(filePath, positionString + "\n");
        Debug.Log("Position saved: " + positionString);
    }
}
