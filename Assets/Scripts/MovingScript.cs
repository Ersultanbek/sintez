using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class MovingScript : MonoBehaviour {
    public Transform LThigh;
    public Transform RThigh;

    public Transform LKnee;
    public Transform RKnee;

    private SerialPort serial; 


    // Use this for initialization
    void Awake () {
        try
        {
            serial = new SerialPort("COM7", 115200);

            serial.Open();

        }
        catch (System.Exception e)
        {
            Debug.Log("ERROR");
            Debug.Log(e.Message);
        }
    }
	
	// Update is called once per frame
	void Update () {
      LThigh.rotation = SerialReaderScript.ReadQuaternion(serial);
	}
}
