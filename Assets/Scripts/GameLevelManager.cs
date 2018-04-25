using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelManager : MonoBehaviour {

    private LevelManager LevelManager;
    private DialogBoxManager DialogBoxManager;

    // Use this for initialization
    void Start () {
        LevelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        if (GameObject.Find("DialogBoxManager") != null)
            DialogBoxManager = GameObject.Find("DialogBoxManager").GetComponent<DialogBoxManager>();
    }

    public void CurrentGameLevel() {
        LevelManager.LoadLevel("Level" + PersistentGameManager.Instance.currentGameLevel.ToString());
    }
	
	public void NextGameLevel() {
        // Loads next level given the user wins a level
        if (PersistentGameManager.Instance.currentGameLevel == 3) {
            DialogBoxManager.WinGameDialogBox();
        }
        else {
            PersistentGameManager.Instance.currentGameLevel++;
            LevelManager.LoadLevel("Level" + PersistentGameManager.Instance.currentGameLevel.ToString());
        }
        PersistentGameManager.Instance.ResetState();
    }

    public void ResetCurrentGameLevel() {
        DialogBoxManager.WinGameDialogBox();
        PersistentGameManager.Instance.ResetState();
        PersistentGameManager.Instance.currentGameLevel = 1;
        LevelManager.LoadLevel("Menu");
    }
}
