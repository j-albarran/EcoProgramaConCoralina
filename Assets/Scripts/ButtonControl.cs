using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour {

    PersistentGameManager PersistentGameManager;
    Button Button;
    SoundManager SoundManager;

    void Start() {
        PersistentGameManager = GameObject.FindWithTag("PersistentGameManager").GetComponent<PersistentGameManager>();
        Button = GetComponent<Button>();
        if (gameObject.name == "Options" || gameObject.name == "Rules" || gameObject.name == "BlockInfo") {
            Button.onClick.AddListener(delegate { ButtonHandler(gameObject.name); });
            //Button.onClick.AddListener(delegate { PersistentGameManager.Instance.SaveLevelState(gameObject.name); });
        }
        else if (gameObject.name == "Return")
            Button.onClick.AddListener(PersistentGameManager.Instance.LoadLevelState);
    }

    public void ButtonHandler(string Name) {
        StartCoroutine(SoundDelay(Name));
    }

    IEnumerator SoundDelay(string Name) {
        SoundManager SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        SoundManager.BubbleSound();
        yield return new WaitForSeconds(0.1f);
        PersistentGameManager.Instance.SaveLevelState(Name);
    }
}
