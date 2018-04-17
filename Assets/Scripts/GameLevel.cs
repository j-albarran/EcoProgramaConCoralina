using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevel : MonoBehaviour {

    [SerializeField]
    Sprite[] PathSprites;

    GameObject AlgorithmPathCursor;
    //Image AlgorithmPathRenderer;

    private float timer;

    // Use this for initialization
    void Start () {
        AlgorithmPathCursor = GameObject.Find("AlgorithmPathCursor");
        //AlgorithmPathRenderer = AlgorithmPathCursor.GetComponent<Image>();
        //AlgorithmPathRenderer.enabled = true;
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            ReadAlgorithm();
            timer = 5;
            foreach (Transform child in transform) {
                if (child.name == "image")
                    GameObject.Destroy(child.gameObject);
            }
        }
    }

    public void RunAlgorithm() {

    }

    // Read and populate array of algorithm
    void ReadAlgorithm() {
        List<char> algorithm = new List<char>();
        /*algorithm.Add('W');
        algorithm.Add('D');
        algorithm.Add('D');
        algorithm.Add('W');
        algorithm.Add('D');
        algorithm.Add('D');
        algorithm.Add('S');
        algorithm.Add('S');
        algorithm.Add('A');*/
        StartCoroutine(Delay(algorithm));
        AlgorithmPathCursor.transform.position = new Vector3(-3.0f, 0f, 0f);
    }

    void RenderAlgorithmPath(List<char> algorithm) {
        // For each algorithm step render its path section
        foreach (char item in algorithm) {
            if (item == 'W')
                RenderUp();
            else if (item == 'A')
                RenderLeft();
            else if (item == 'S')
                RenderDown();
            else if (item == 'D')
                RenderRight();
        }
    }

    void RenderUp() {
        // Move cursor up one tile
        AlgorithmPathCursor.transform.position += Vector3.up;

        // New Image object
        GameObject obj = new GameObject("image");
        obj.transform.parent = GameObject.Find("GameLevel").transform;
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        obj.transform.position = AlgorithmPathCursor.transform.position;
        Image AlgorithmPathRenderer = obj.AddComponent<Image>();

        // Render path sprite
        AlgorithmPathRenderer.sprite = PathSprites[0];
    }

    void RenderLeft() {
        // Move cursor to the left one tile
        AlgorithmPathCursor.transform.position += Vector3.left;

        // New Image object
        GameObject obj = new GameObject("image");
        obj.transform.parent = GameObject.Find("GameLevel").transform;
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        obj.transform.position = AlgorithmPathCursor.transform.position;
        Image AlgorithmPathRenderer = obj.AddComponent<Image>();

        // Render path sprite
        AlgorithmPathRenderer.sprite = PathSprites[1];
    }

    void RenderDown() {
        // Move cursor down one tile
        AlgorithmPathCursor.transform.position += Vector3.down;

        // New Image object
        GameObject obj = new GameObject("image");
        obj.transform.parent = GameObject.Find("GameLevel").transform;
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        obj.transform.position = AlgorithmPathCursor.transform.position;
        Image AlgorithmPathRenderer = obj.AddComponent<Image>();

        // Render path sprite
        AlgorithmPathRenderer.sprite = PathSprites[2];
    }

    void RenderRight() {
        // Move cursor to the right one tile
        AlgorithmPathCursor.transform.position += Vector3.right;

        // New Image object
        GameObject obj = new GameObject("image");
        obj.transform.parent = GameObject.Find("GameLevel").transform;
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        obj.transform.position = AlgorithmPathCursor.transform.position;
        Image AlgorithmPathRenderer = obj.AddComponent<Image>();

        // Render path sprite
        AlgorithmPathRenderer.sprite = PathSprites[3];
    }

    IEnumerator Delay(List<char> algorithm) {
        // For each algorithm step render its path section
        foreach (char item in algorithm) {
            if (item == 'W')
                RenderUp();
            else if (item == 'A')
                RenderLeft();
            else if (item == 'S')
                RenderDown();
            else if (item == 'D')
                RenderRight();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
