using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Diagnostics;

public class Rotation : MonoBehaviour
{

    SerialPort serial = new SerialPort("COM3", 115200);
    public float millimeters;
    public GameObject backSense;


    // Start is called before the first frame update
    void Start()
    {
        backSense = GameObject.Find("ReceiverRotation");
        serial.Open();
    }


    public void setRange(string range)
    {
        try
        {
            millimeters = float.Parse(range);
        }
        catch (System.FormatException e)
        {
            print(e);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (serial.IsOpen)
        {
            string data = serial.ReadLine();

            try
            {

                string[] values = data.Split('/');

                if (values.Length == 4)
                {
                    float w = float.Parse(values[0]);
                    float x = float.Parse(values[1]);
                    float y = float.Parse(values[2]);
                    float z = float.Parse(values[3]);


                    backSense.transform.localRotation = Quaternion.Lerp(backSense.transform.localRotation,
                        new Quaternion(w, x, y, z), Time.deltaTime * 15.0f);

                    backSense.transform.position =  Vector3.Lerp(backSense.transform.position,
                        new Vector3(millimeters,0, 0),5.0f *Time.deltaTime);
                }


                //print(this.transform.eulerAngles.x+" "+ this.transform.eulerAngles.y + " "+ this.transform.eulerAngles.z);

            }
            catch (System.FormatException e)
            {
                print(e.Message);
            }


        }

    }
}
