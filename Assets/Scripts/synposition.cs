using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class synposition : MonoBehaviour
{
    public bool triggered;
    public double x;
    public double y;
    public double z;
    public double ori_x;
    public double ori_y;
    public double ori_z;
    public double ori_w;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }
    void updatePosition(){
       
      this.transform.position = new Vector3((float)x,(float)y,(float)z);
      this.transform.rotation = new Quaternion((float)ori_x,(float)ori_y,(float)ori_z,(float) ori_w);

    }

    // Update is called once per frame
    void Update()
    {
        if(triggered){
            triggered = false;
            updatePosition();
        }
    }
}
