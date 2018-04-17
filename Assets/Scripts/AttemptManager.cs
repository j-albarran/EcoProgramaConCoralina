using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttemptManager : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image Attempts;
    public int MaxAttempts;
    private int CurrentAttempt;
    private LevelManager LevelManager;
    private GameObject DialogBox;
    private Image TransparentImage;

	// Use this for initialization
	void Start () {
        CurrentAttempt = 0;
        LevelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        DialogBox = GameObject.Find("LostDialogBox");
        DialogBox.SetActive(false);

        TransparentImage = GameObject.Find("TransparentImage").GetComponent<Image>();
        TransparentImage.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (CurrentAttempt < MaxAttempts)
            Attempts.sprite = HeartSprites[CurrentAttempt];
        else {
            Attempts.sprite = HeartSprites[CurrentAttempt];
            TransparentImage.enabled = true;
            DialogBox.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void LoseAttempt () {
        CurrentAttempt++;
    }
}
