using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private LevelManager LevelManager;
    private AudioSource SourceManager;

    public AudioClip Bubble;
    public AudioClip Click;

    // Use this for initialization
    void Start () {
        LevelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        SourceManager = this.GetComponent<AudioSource>();
    }

    public void BubbleSound() {
        SourceManager.PlayOneShot(Bubble);
    }

    public void ClickSound() {
        SourceManager.PlayOneShot(Click);
    }
}
