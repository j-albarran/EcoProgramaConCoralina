using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Image img;

    public int levelSeconds;

    private int minutes;
    private int seconds;
    private float millis;
    private int secondsLeft;
    private Text text;
    private bool paused;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        secondsLeft = levelSeconds;
        paused = false;
        img = GameObject.Find("PauseImage").GetComponent<Image>();
        img.enabled = false;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (!paused) {
            minutes = secondsLeft / 60;
            seconds = secondsLeft % 60;
            millis = ((float)levelSeconds - Time.timeSinceLevelLoad) * 1000;
            millis = millis % 1000;

            text.text = "Tiempo: " + minutes.ToString("00") + ":" + seconds.ToString("00") + "." + (int)(millis / 10);

            secondsLeft = (int)((float)levelSeconds - Time.timeSinceLevelLoad);

            // Verify remaining time
            if (secondsLeft == 0 && millis <= 0) {
                // TODO: Add feedback/message indicating no time left
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Pause () {
        paused = !paused;
        img.enabled = !img.enabled;
        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        // TODO: Pause all components of the game
    }
}
