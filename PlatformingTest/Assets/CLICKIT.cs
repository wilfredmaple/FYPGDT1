using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CLICKIT : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Button play;
    }

    public void Game()
        {
        SceneManager.LoadScene("SampleScene");
        }
	
	// Update is called once per frame
	void Update () {
		
	}
}
