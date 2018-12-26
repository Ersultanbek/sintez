using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.IO;
using System;

public class SerialReaderScript : MonoBehaviour {
    private GlobalSettings settings = GlobalSettings.Instance;
    byte[] buf = new byte[4]; // creates a byte array the size of the data you want to receive.
    SerialPort serialRoot = null;
    int bufCount = 0;
    int a, b;

    [Serializable]
    public class ArduinoResponseData {
        public float x;
        public float y;
        public float z;
        public float w;
    }
    
    public static Quaternion ReadQuaternion(SerialPort serial) {


        ArduinoResponseData responseData = ConvertToArduinoResonseData(GetDataFromSerial(serial));

        Quaternion quaternion = new Quaternion(responseData.x,responseData.y,responseData.z,responseData.w);
      
        return quaternion;
    }

    public static string GetTestData() {
        return "{\"x\":\"0.23\",\"y\":\"-0.93\",\"z\":\"-0.29\",\"w\":\"0.00\"}";
    }

    public static string GetDataFromSerial(SerialPort serial)
    {
        string str = serial.ReadLine();
        Debug.Log(str);
        return str;
    }

    private static ArduinoResponseData ConvertToArduinoResonseData(string json) {
       return JsonUtility.FromJson<ArduinoResponseData>(json);
    }

    public static bool TestConnection(int portNumber) {
        SerialPort serial = null;
        string ret = null;
        try
        {
            serial = new SerialPort("COM7",115200);
            
            serial.Open();
            
            ret = serial.ReadLine();
            Debug.Log(ret);
        
            serial.Close();

            if (ret != null || ret.Length != 0)
                return true;
    }
        catch (System.Exception e)
        {
            Debug.Log("ERROR");
            Debug.Log(e.Message);
        }

        return false;
    }
}
