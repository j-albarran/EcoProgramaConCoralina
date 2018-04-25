using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxManager : MonoBehaviour {

    private GameObject DialogBoxes;
    private PauseManager PauseManager;
    private Timer Timer;

    // Use this for initialization
    void Start () {
        DialogBoxes = GameObject.Find("DialogBoxes");
        PauseManager = GameObject.Find("PauseManager").GetComponent<PauseManager>();
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
    }
	
	public void PauseDialogBox() {
        // Pause timer
        PauseManager.Pause();

        // Enable the delete dialog box
        foreach (Transform child in DialogBoxes.transform) {
            if (child.gameObject.name == "TransparentImage" || child.gameObject.name == "PauseDialogBox")
                child.gameObject.SetActive(PauseManager.paused);
        }
    }

    public void ExitDialogBox() {
        // Pause timer
        PauseManager.Pause();

        // Enable the delete dialog box
        foreach (Transform child in DialogBoxes.transform) {
            if (child.gameObject.name == "TransparentImage" || child.gameObject.name == "ExitDialogBox")
                child.gameObject.SetActive(PauseManager.paused);
        }
    }

    public void WinCondition() {
        Debug.Log(PersistentGameManager.Instance.currentGameLevel + 1);
        if (PersistentGameManager.Instance.currentGameLevel == 3) {
            WinGameDialogBox();
        }
        else {
            WinLevelDialogBox();
        }
    }

    public void WinLevelDialogBox() {
        // Pause timer
        PauseManager.Pause();

        // Enable the win dialog box
        foreach (Transform child in DialogBoxes.transform) {
            if (child.gameObject.name == "TransparentImage" || child.gameObject.name == "WinLevelDialogBox")
                child.gameObject.SetActive(PauseManager.paused);
        }
    }

    public void WinGameDialogBox() {
        // Pause timer
        PauseManager.Pause();

        // Enable the win dialog box
        foreach (Transform child in DialogBoxes.transform) {
            if (child.gameObject.name == "TransparentImage" || child.gameObject.name == "WinGameDialogBox")
                child.gameObject.SetActive(PauseManager.paused);
        }
    }

    public void LostDialogBox() {
        // Pause timer
        PauseManager.Pause();

        // Enable the lost dialog box
        foreach (Transform child in DialogBoxes.transform) {
            if (child.gameObject.name == "TransparentImage" || child.gameObject.name == "LostDialogBox")
                child.gameObject.SetActive(PauseManager.paused);
        }
    }

    public void DeleteDialogBox() {
        // Pause timer
        PauseManager.Pause();

        // Enable the delete dialog box
        foreach (Transform child in DialogBoxes.transform) {
            if (child.gameObject.name == "TransparentImage" || child.gameObject.name == "DeleteDialogBox")
                child.gameObject.SetActive(PauseManager.paused);
        }
    }

    public void TimerDialogBox1On() {
        // Pause timer
        PauseManager.Pause();

        // Enable the delete dialog box
        foreach (Transform child in DialogBoxes.transform) {
            if (child.gameObject.name == "TransparentImage" || child.gameObject.name == "TimerDialogBox1")
                child.gameObject.SetActive(true);
        }
    }

    public void TimerDialogBox1Off() {
        // Enable the delete dialog box
        foreach (Transform child in DialogBoxes.transform) {
            if (child.gameObject.name == "TransparentImage" || child.gameObject.name == "TimerDialogBox1")
                child.gameObject.SetActive(false);
        }

        // Pause timer
        PauseManager.Pause();
        Timer.SetStartTime(Time.time);
    }

    public void TimerDialogBox2() {
        // Pause timer
        PauseManager.Pause();

        // Enable the delete dialog box
        foreach (Transform child in DialogBoxes.transform) {
            if (child.gameObject.name == "TransparentImage" || child.gameObject.name == "TimerDialogBox2")
                child.gameObject.SetActive(PauseManager.paused);
        }
    }
}
