using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttemptManager : MonoBehaviour {

    [SerializeField]
    Sprite[] HeartSprites;

    private GameObject Attempts;
    private Image Hearts;
    private DialogBoxManager DialogBoxManager;
    private int currentAttempt;
    private int maxAttempts;

	// Use this for initialization
	void Start () {
        Attempts = GameObject.Find("Attempts");
        Hearts = Attempts.transform.Find("Hearts").GetComponent<Image>();
        DialogBoxManager = GameObject.Find("DialogBoxManager").GetComponent<DialogBoxManager>();
        currentAttempt = PersistentGameManager.Instance.CurrentAttempts;
        maxAttempts = 2;
    }

    void Update() {
        Hearts.sprite = HeartSprites[currentAttempt];
    }
	
    public void LoseAttempt () {
        // Lose an attempt because of a collision, out of bounds, or level task
        // not completed.
        currentAttempt++;

        if (currentAttempt < maxAttempts) {
            Hearts.sprite = HeartSprites[currentAttempt];

        }
        else {
            Hearts.sprite = HeartSprites[currentAttempt];
            DialogBoxManager.LostDialogBox();
        }
    }

    public void LoseAttemptTimer() {
        // Lose an attempt because the time is up
        currentAttempt++;

        if (currentAttempt < maxAttempts) {
            Hearts.sprite = HeartSprites[currentAttempt];

        }
        else {
            Hearts.sprite = HeartSprites[currentAttempt];
        }
    }

    public void SetCurrentAttempts(int currentAttempt) {
        this.currentAttempt = currentAttempt;
    }

    public int GetCurrentAttempts() {
        return currentAttempt;
    }

    public int GetMaxAttempts() {
        return maxAttempts;
    }
}
