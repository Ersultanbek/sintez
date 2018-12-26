using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneAction : MonoBehaviour {
    public int sceneIndx = 0;
    // Use this for initialization
    private void Awake()
    {
    }

    void Start () {
        var btn = gameObject.GetComponent<Button>();

        btn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(sceneIndx);
        });
	}
}
