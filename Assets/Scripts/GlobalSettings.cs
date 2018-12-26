using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour {
    public static GlobalSettings Instance
    {
        get;
        set;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    void Start()
    {
       
    }

    // Data persisted between scenes
    public int portNumber { get; set; }
    //...
}
