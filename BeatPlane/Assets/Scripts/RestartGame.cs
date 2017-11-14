using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnMouseUpAsButton()
    {

        GameManager._instance.debugLog("RestartGame : OnMouseUpAsButton");
        SceneManager.LoadScene(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
