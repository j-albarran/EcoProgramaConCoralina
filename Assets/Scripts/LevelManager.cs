using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel (string name)
    {
        if (name == "Menu") {
            PersistentGameManager.Instance.ResetState();
            PersistentGameManager.Instance.currentGameLevel = 1;
        }
        SceneManager.LoadScene(name);
    }

    public void LoadLevel1() {
        PersistentGameManager.Instance.ResetState();
        PersistentGameManager.Instance.currentGameLevel = 1;
        SceneManager.LoadScene("Level1");
    }
}
