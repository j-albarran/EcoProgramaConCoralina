using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private GameObject AttemptManager;
    private DialogBoxManager DialogBoxManager;

    public int levelSeconds;

    private Image filler;
    private float timeLeft;
    private bool paused;
    private float StartTime;
    private float ElapsedTime;
    private float LoadTime;

    // Use this for initialization
    void Start () {
        AttemptManager = GameObject.Find("AttemptManager");
        DialogBoxManager = GameObject.Find("DialogBoxManager").GetComponent<DialogBoxManager>();

        // Initialize timer bar characteristics
        filler = transform.Find("Mask/Filler").gameObject.GetComponent<Image>();
        timeLeft = levelSeconds;
        filler.fillAmount = 1.0f;

        // Start unpaused
        paused = false;
        Time.timeScale = 1;

        // Initialize with saved data if any
        ElapsedTime = PersistentGameManager.Instance.ElapsedTime;
        StartTime = PersistentGameManager.Instance.StartTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (!paused) {
            filler.fillAmount = timeLeft/levelSeconds;

            ElapsedTime = Time.time - StartTime;
            timeLeft = levelSeconds - ElapsedTime;

            // Verify remaining time
            if (timeLeft <= 0) {
                AttemptManager.GetComponent<AttemptManager>().LoseAttemptTimer();
                // Verify number of attempts left
                if (AttemptManager.GetComponent<AttemptManager>().GetCurrentAttempts() == AttemptManager.GetComponent<AttemptManager>().GetMaxAttempts())
                    DialogBoxManager.TimerDialogBox2();
                else {
                    DialogBoxManager.TimerDialogBox1On();
                    ResetTime();
                }
            }
        }
    }

    public void Pause () {
        paused = !paused;

        // Stop timer
        if (paused)
            Time.timeScale = 0;
        else {
            Time.timeScale = 1;
        }
    }

    public void ResetTime() {
        timeLeft = levelSeconds;
        ElapsedTime = 0;
    }

    public void SetStartTime(float st) {
        StartTime = st;
    }

    public float GetStartTime() {
        return StartTime;
    }

    public void SetElapsedTime(float ElapsedTime) {
        this.ElapsedTime = ElapsedTime;
    }

    public float GetElapsedTime() {
        return ElapsedTime;
    }

    public float GetLoadTime() {
        return Time.time;
    }
}
