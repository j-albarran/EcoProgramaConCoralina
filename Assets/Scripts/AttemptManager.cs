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

	// Use this for initialization
	void Start () {
        CurrentAttempt = 0;
        LevelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (CurrentAttempt < MaxAttempts)
            Attempts.sprite = HeartSprites[CurrentAttempt];
        else {
            Attempts.sprite = HeartSprites[CurrentAttempt];
            LevelManager.LoadLevel("Menu");
        }
    }

    public void LoseAttempt () {
        CurrentAttempt++;
    }
}
