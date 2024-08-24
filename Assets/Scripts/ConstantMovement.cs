using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    public Vector3 movingDir;
    public float speed;
    public bool movement;
    public bool rotation;
    //public Vector3 rotationAxis;
    public int rotationDir; //-1 or 1
    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            transform.position += movingDir * speed * Time.deltaTime;
        }
        if(rotation)
        {
            transform.Rotate(transform.up, rotationDir * speed * Time.deltaTime, Space.Self);
        }
    }
}
