using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LPuiManager : MonoBehaviour {

    int highscore = 0;

    public Text highscoreText;

	// Use this for initialization
	void Start () {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = ""+highscore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene("level1");
    }
}
