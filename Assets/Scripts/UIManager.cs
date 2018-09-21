using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Button[] buttons;
    public Text scoreText;
    int score;
    int highscore;
    bool gameOver = false;
    public GameObject highscore_tag;

	// Use this for initialization
	void Start () {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score = 0;
        InvokeRepeating("ScoreUpdate", 1f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if(highscore < score)
        {
            scoreText.text = "High score: " + score;
        }
        else
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void gameOverActivated()
    {
        gameOver = true;
        if(score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            highscore_tag.SetActive(true);
        }
        foreach(Button button in buttons)
        {
            Debug.Log("btn- "+button.gameObject.name+" "+button.gameObject.activeSelf);
            if(button.gameObject.activeSelf)
            {
                button.gameObject.SetActive(false);
            }
            else
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    void ScoreUpdate()
    {
        if(!gameOver)
        {
            score += 1;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("level1");
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("LandingPage");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
