using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    private GameObject PauseObj;
    private GameObject Timer;
    private int currentIcon;
    public bool paused;

    [SerializeField]
    Sprite[] PauseIcons;
    
    // Use this for initialization
    void Start () {
        PauseObj = GameObject.Find("Pause");
        Timer = GameObject.Find("Canvas/HUD/Timer");
        currentIcon = 0;
        paused = false;
	}
	
	public void Pause() {
        // Change game state
        paused = !paused;

        // Enable/Disable pause image to block game screen
        foreach (Transform child in PauseObj.transform) {
            if (child.gameObject.name != "PauseButton")
                child.gameObject.SetActive(paused);
        }

        // Change button sprite
        currentIcon = (currentIcon + 1) % PauseIcons.Length;
        PauseObj.transform.Find("PauseButton").GetComponent<Image>().sprite = PauseIcons[currentIcon];

        Timer.GetComponent<Timer>().Pause();
    }
}
