using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Image pauseImg;
    public Sprite[] icons;
    public Image filler;
    public Image pauseButton;

    public int levelSeconds;

    //private int minutes;
    //private int seconds;
    //private float millis;
    //private int secondsLeft;
    private float timeLeft;
    // private Text text;
    private bool paused;
    private int currentIcon;

	// Use this for initialization
	void Start () {
        //text = GetComponent<Text>();
        //secondsLeft = levelSeconds;
        timeLeft = levelSeconds;
        filler.fillAmount = 1.0f;
        paused = false;
        pauseImg.enabled = false;
        pauseButton = GameObject.Find("PauseButton").GetComponent<Image>();
        Time.timeScale = 1;
        currentIcon = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (!paused) {
            /*minutes = secondsLeft / 60;
            seconds = secondsLeft % 60;
            millis = ((float)levelSeconds - Time.timeSinceLevelLoad) * 1000;
            millis = millis % 1000;

            text.text = "Tiempo: " + minutes.ToString("00") + ":" + seconds.ToString("00") + "." + (int)(millis / 10);

            secondsLeft = (int)((float)levelSeconds - Time.timeSinceLevelLoad);

            // Verify remaining time
            if (secondsLeft == 0 && millis <= 0) {
                // TODO: Add feedback/message indicating no time left
                SceneManager.LoadScene("Menu");
            }*/

            filler.fillAmount = timeLeft/levelSeconds;

            timeLeft = levelSeconds - Time.timeSinceLevelLoad;

            // Verify remaining time
            if (timeLeft <= 0) {
                // TODO: Add feedback/message indicating no time left
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Pause () {
        paused = !paused;

        // Enable/Disable pause image to block game screen
        pauseImg.enabled = !pauseImg.enabled;

        // Change button sprite
        currentIcon = (currentIcon + 1) % icons.Length;
        pauseButton.sprite = icons[currentIcon];

        // Stop timer
        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;


        // TODO: Pause all components of the game
    }
}
