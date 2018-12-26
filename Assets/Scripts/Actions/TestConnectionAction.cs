
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestConnectionAction : MonoBehaviour {
    public Text MessageField;

    private GlobalSettings settings;
    private const string SUCCESS = "П О Д К Л Ю Ч Е Н О";
    private const string ERROR = "Н Е Т   П О Д К Л Ю Ч Е Н И Я";
    private const string WRONG_PORT = "В В Е Д И Т Е   П О Р Т";
    Button btn;
    // Use this for initialization

    private void Awake()
    {
        settings = GlobalSettings.Instance; 
    }

    void Start () {
       btn = gameObject.GetComponent<Button>();

        if (btn != null) {
            btn.onClick.AddListener(()=> {
                if (settings.portNumber == 0)
                {
                    setWrongMes();
                    return;
                }

                if (SerialReaderScript.TestConnection(settings.portNumber))
                    setSuccessMes();
                else
                    setErrorMes();
            });
        }
	}

    private void setSuccessMes() {
        MessageField.text = SUCCESS;
        MessageField.color = Color.green;
    }

    private void setWrongMes()
    {
        MessageField.text = WRONG_PORT;
        MessageField.color = Color.red;
    }

    private void setErrorMes()
    {
        MessageField.text = ERROR;
        MessageField.color = Color.red;
    }

    private void Update()
    {
        btn.interactable = settings.portNumber != 0 ? true : false;
    }

}
