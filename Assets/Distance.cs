using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;



public class Distance : MonoBehaviour
{
    SerialPort stream2 = new SerialPort("COM4", 115200);
    public string range;
    
   

    /*public Vector3 rotationAngles;*/

    // Start is called before the first frame update
    void Start()
    {
        stream2.Open();
   
    }


 /*   public void eulerRotation(Vector3 v)
    {
        rotationAngles = v;
    }*/

    // Update is called once per frame
    void Update()
    {
        range = stream2.ReadLine();
        stream2.BaseStream.Flush(); //Clear the serial information so we assure we get new information.

        /*GameObject.Find("Rotation").SendMessage("getDistance", range);*/

        /* float degrX = rotationAngles.x;
         float degrY = rotationAngles.y;
         float degrZ = rotationAngles.z;

         float radX = degrX * Mathf.Deg2Rad;
         float radY = degrY * Mathf.Deg2Rad;
         float radZ = degrZ * Mathf.Deg2Rad;

         float cosx = (float)Mathf.Cos(radX);
         float cosy = (float)Mathf.Cos(radY);
         float cosz = (float)Mathf.Cos(radZ);


         float laserDistance = (float.Parse(receivedLaser) / 10) - 1.0f;


         transform.position = Vector3.Lerp(transform.position,
         //new Vector3(0, 0, (float.Parse(receivedLaser) / 10) - 1.0f), 5.0f * Time.deltaTime);
         new Vector3(laserDistance * cosx, laserDistance * cosy, laserDistance * cosz), 5.0f * Time.deltaTime);*/


    }
}