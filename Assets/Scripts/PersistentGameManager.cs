using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentGameManager : MonoBehaviour {

    public static PersistentGameManager Instance {
        get;
        private set;
    }

    public int currentGameLevel;
    public int CurrentAttempts;
    public float ElapsedTime;
    public float StartTime;
    public int CurrentScore;
    public int CurAluminumItems;
    public int CurGlassItems;
    public int CurPlasticItems;
    public string[,] Algorithm;
    public int AlgorithmIndexI;
    public int AlgorithmIndexJ;

    private LevelManager LevelManager;
    private AttemptManager AttemptManager;
    private Timer Timer;
    private ScoreManager ScoreManager;
    private InventoryManager InventoryManager;
    private AlgorithmPathManager AlgorithmPathManager;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentGameLevel = 1;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start() {
        StartTime = Time.time;
    }

    public void SaveLevelState(string NextLevel) {

        // Find the game objects
        LevelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        AttemptManager = GameObject.Find("AttemptManager").GetComponent<AttemptManager>();
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
        ScoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
        InventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        AlgorithmPathManager = GameObject.Find("AlgorithmPathManager").GetComponent<AlgorithmPathManager>();

        // Store all values into the persistent game object
        CurrentAttempts = AttemptManager.GetCurrentAttempts();
        ElapsedTime = Timer.GetElapsedTime();
        StartTime = Timer.GetStartTime();
        CurrentScore = ScoreManager.GetCurrentScore();
        CurAluminumItems = InventoryManager.GetCurAluminumItems();
        CurGlassItems = InventoryManager.GetCurGlassItems();
        CurPlasticItems = InventoryManager.GetCurPlasticItems();
        Algorithm = AlgorithmPathManager.GetAlgorithm();
        AlgorithmIndexI = AlgorithmPathManager.GetAlgorithmIndexI();
        AlgorithmIndexJ = AlgorithmPathManager.GetAlgorithmIndexJ();

        // Stop time
        Time.timeScale = 0;

        // Load the specified level
        LevelManager.LoadLevel(NextLevel);
    }

    public void LoadLevelState() {
        // Load the current game level before saving the state
        LevelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        LevelManager.LoadLevel("Level" + currentGameLevel.ToString());
    }

    public void ResetState() {
        // Set all stored values to their initial values
        CurrentAttempts = 0;
        ElapsedTime = 0f;
        StartTime = Time.time;
        CurrentScore = 0;
        CurAluminumItems = 0;
        CurGlassItems = 0;
        CurPlasticItems = 0;
        if (Algorithm != null) {
            Array.Clear(Algorithm, 0, Algorithm.GetLength(0) * Algorithm.GetLength(1));
            Algorithm = null;
        }
        AlgorithmIndexI = 0;
        AlgorithmIndexJ = 0;
    }
}
