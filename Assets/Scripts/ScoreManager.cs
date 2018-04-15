using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private Text text;
    private int currentScore;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Puntos: " + currentScore;
	}

    public void IncrementScore(int delta) {
        currentScore += delta;
    }
}
