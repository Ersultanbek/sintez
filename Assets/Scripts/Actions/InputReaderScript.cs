using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputReaderScript : MonoBehaviour {
    private GlobalSettings settings;

    private void Awake()
    {
        settings = GlobalSettings.Instance;
    }

    private void Start()
    {
        var input = gameObject.GetComponent<InputField>();

        input.onEndEdit.AddListener(e => {
            settings.portNumber = int.Parse(input.text);
        });
    }
}
