using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System.Configuration;

public class Rotation : MonoBehaviour
{

    SerialPort serial = new SerialPort("COM3",115200);

    // Start is called before the first frame update
    void Start()
    {
        serial.Open();
    }

    // Update is called once per frame
    void Update()
    {

        string data = serial.ReadLine();
        
        try
        {

            string[] values = data.Split('/');

            float w = float.Parse(values[0]);
            float x = float.Parse(values[1]);
            float y = float.Parse(values[2]);
            float z = float.Parse(values[3]);

            this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation,
                new Quaternion(w, x, y, z), Time.deltaTime * 15.0f);

        }
        catch (System.FormatException e)
        {
            print(e.Message);
        }
        
    }
}
