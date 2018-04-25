using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgorithmPathManager : MonoBehaviour {

    [SerializeField]
    Sprite[] PathSprite;

    private string[,] Algorithm;
    private string[,] TempAlgorithm;

    private GameObject Cursor;
    private GameObject TempImages;
    private Color myColor;
    private Coroutine lastRenderCoroutine;
    private Coroutine lastDelayCoroutine;

    private float worldUnitSize;
    private float waitTime;
    private bool renderBusy;
    private int algorithmIndexI;
    private int algorithmIndexJ;

    // Use this for initialization
    void Start () {
        Cursor = transform.Find("Cursor").gameObject;
        TempImages = transform.Find("TempImages").gameObject;
        worldUnitSize = 120f + 0.0005f;

        // Wait time between arrow appearance
        waitTime = 0.2f;

        // Set cursor local position and arrow color
        Cursor.transform.localPosition = new Vector3(0f * worldUnitSize, -1.0f * worldUnitSize, 0f);
        myColor = new Color32(0x00, 0xFF, 0xFF, 0x96);

        // Not rendering
        renderBusy = false;

        // Indexes to verify algorithm
        algorithmIndexI = PersistentGameManager.Instance.AlgorithmIndexI;
        algorithmIndexJ = PersistentGameManager.Instance.AlgorithmIndexJ;

        // Start with saved value
        Algorithm = PersistentGameManager.Instance.Algorithm;

        if (lastDelayCoroutine != null)
            StopCoroutine(lastDelayCoroutine);

        if (lastRenderCoroutine != null)
            StopCoroutine(lastRenderCoroutine);
    }
	
	// Update is called once per frame
	void Update () {
        if (!renderBusy) {
            ReadAlgorithm();
        }
    }

    // Read and populate array of Algorithm
    void ReadAlgorithm() {
        TempAlgorithm = Clone(Algorithm);
        lastRenderCoroutine = StartCoroutine(RenderAlgorithmPath());
    }

    void RenderUp() {
        // Move cursor up one tile
        Cursor.transform.position += Vector3.up;

        // New Image object
        GameObject obj = new GameObject("image", typeof(RectTransform));
        obj.transform.SetParent(TempImages.transform, false);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        obj.transform.position = Cursor.transform.position;
        Image AlgorithmPathRenderer = obj.AddComponent<Image>();

        // Render path sprite
        if (InsideBoundaries(obj.GetComponent<RectTransform>().anchoredPosition)) {
            AlgorithmPathRenderer.color = myColor;
            AlgorithmPathRenderer.sprite = PathSprite[0];
        }
        else {
            // Out of the game boundaries, show red rectangle
            obj.transform.position += Vector3.down / 4;
            AlgorithmPathRenderer.rectTransform.sizeDelta = new Vector2(120, 60);
            AlgorithmPathRenderer.sprite = PathSprite[5];
            lastDelayCoroutine = StartCoroutine(DelayBeforeStopping(waitTime));
        }
    }

    void RenderLeft() {
        // Move cursor to the left one tile
        Cursor.transform.position += Vector3.left;

        // New Image object
        GameObject obj = new GameObject("image", typeof(RectTransform));
        obj.transform.SetParent(TempImages.transform, false);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        obj.transform.position = Cursor.transform.position;
        Image AlgorithmPathRenderer = obj.AddComponent<Image>();

        // Render path sprite
        if (InsideBoundaries(obj.GetComponent<RectTransform>().anchoredPosition)) {
            AlgorithmPathRenderer.color = myColor;
            AlgorithmPathRenderer.sprite = PathSprite[1];
        }
        else {
            // Out of the game boundaries, show red rectangle
            obj.transform.position += Vector3.right / 4;
            AlgorithmPathRenderer.rectTransform.sizeDelta = new Vector2(60, 120);
            AlgorithmPathRenderer.sprite = PathSprite[4];
            lastDelayCoroutine = StartCoroutine(DelayBeforeStopping(waitTime));
        }
    }

    void RenderDown() {
        // Move cursor down one tile
        Cursor.transform.position += Vector3.down;

        // New Image object
        GameObject obj = new GameObject("image", typeof(RectTransform));
        obj.transform.SetParent(TempImages.transform, false);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        obj.transform.position = Cursor.transform.position;
        Image AlgorithmPathRenderer = obj.AddComponent<Image>();

        // Render path sprite
        if (InsideBoundaries(obj.GetComponent<RectTransform>().anchoredPosition)) {
            AlgorithmPathRenderer.color = myColor;
            AlgorithmPathRenderer.sprite = PathSprite[2];
        }
        else {
            // Out of the game boundaries, show red rectangle
            obj.transform.position += Vector3.up / 4;
            AlgorithmPathRenderer.rectTransform.sizeDelta = new Vector2(120, 60);
            AlgorithmPathRenderer.sprite = PathSprite[5];
            lastDelayCoroutine = StartCoroutine(DelayBeforeStopping(waitTime));
        }
    }

    void RenderRight() {
        // Move cursor to the right one tile
        Cursor.transform.position += Vector3.right;

        // New Image object
        GameObject obj = new GameObject("image", typeof(RectTransform));
        obj.transform.SetParent(TempImages.transform, false);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        obj.transform.position = Cursor.transform.position;
        Image AlgorithmPathRenderer = obj.AddComponent<Image>();

        // Render path sprite
        if (InsideBoundaries(obj.GetComponent<RectTransform>().anchoredPosition)) {
            AlgorithmPathRenderer.color = myColor;
            AlgorithmPathRenderer.sprite = PathSprite[3];
        }
        else {
            // Out of the game boundaries, show red rectangle
            obj.transform.position += Vector3.left / 4;
            AlgorithmPathRenderer.rectTransform.sizeDelta = new Vector2(60, 120);
            AlgorithmPathRenderer.sprite = PathSprite[4];
            lastDelayCoroutine = StartCoroutine(DelayBeforeStopping(waitTime));
        }
    }

    public void ResetPath() {
        if (lastDelayCoroutine != null)
            StopCoroutine(lastDelayCoroutine);

        if (lastRenderCoroutine != null)
            StopCoroutine(lastRenderCoroutine);

        if (TempAlgorithm != null)
            Array.Clear(TempAlgorithm, 0, TempAlgorithm.GetLength(0) * TempAlgorithm.GetLength(1));

        Cursor.transform.localPosition = new Vector3(0f * worldUnitSize, -1.0f * worldUnitSize, 0f);
        renderBusy = false;
    }

    public void ClearPath() {
        // Clear the algorithm path (Delete images)
        foreach (Transform child in TempImages.transform) {
            if (child.name == "image")
                GameObject.Destroy(child.gameObject);
        }
        ResetPath();
    }

    public void ResetAlgorithm() {
        // Delete current algorithm
        if (Algorithm != null)
            Array.Clear(Algorithm, 0, Algorithm.GetLength(0) * Algorithm.GetLength(1));
        ClearPath();
    }

    string[,] Clone(string[,] a) {
        // Clone Algorithm array to a temp array
        if (a != null) {
            string[,] tmp = new string[50, 3];
            for (int i = 0; i < a.GetLength(0); i++) {
                for (int j = 0; j < a.GetLength(1); j++) {
                    tmp[i, j] = a[i, j];
                }
            }
            return tmp;
        }
        return null;
    }

    bool InsideBoundaries(Vector3 pos) {
        // Check algorithm against the game boundaries
        if (pos.x > (10 * worldUnitSize) || pos.x < (0 * worldUnitSize) || pos.y < (-4 * worldUnitSize) || pos.y > (0 * worldUnitSize))
            return false;
        return true;
    }

    IEnumerator RenderAlgorithmPath() {
        // Renders the algorithm path after reading the algorithm array
        renderBusy = true;
        if (TempAlgorithm != null) {
            for (int i = 0; i < TempAlgorithm.GetLength(0); i++) {
                if (TempAlgorithm[i, 0] == "Swim") {
                    int temp;
                    Int32.TryParse(TempAlgorithm[i, 2], out temp);
                    for (int x = 0; x < temp; x++) {
                        switch (TempAlgorithm[i, 1]) {
                            case ("Up"):
                                RenderUp();
                                break;
                            case ("Left"):
                                RenderLeft();
                                break;
                            case ("Down"):
                                RenderDown();
                                break;
                            case ("Right"):
                                RenderRight();
                                break;
                        }
                        yield return new WaitForSeconds(waitTime);
                    }
                }
                else if (TempAlgorithm[i, 0] == "Jump") {
                    for (int x = 0; x < 2; x++) {
                        switch (TempAlgorithm[i, 1]) {
                            case ("Up"):
                                RenderUp();
                                break;
                            case ("Left"):
                                RenderLeft();
                                break;
                            case ("Down"):
                                RenderDown();
                                break;
                            case ("Right"):
                                RenderRight();
                                break;
                        }
                        yield return new WaitForSeconds(waitTime);
                    }
                }
            }
            foreach (Transform child in TempImages.transform) {
                if (child.name == "image")
                    GameObject.Destroy(child.gameObject);
            }
            yield return new WaitForSeconds(waitTime);
            Cursor.transform.localPosition = new Vector3(0f * worldUnitSize, -1.0f * worldUnitSize, 0f);

            renderBusy = false;
        }
    }

    IEnumerator DelayBeforeStopping(float delay) {
        // Introduce a delay after algorithm goes out of boundaries
        yield return new WaitForSeconds(delay);
        StopCoroutine(lastRenderCoroutine);
        foreach (Transform child in TempImages.transform) {
            if (child.name == "image")
                GameObject.Destroy(child.gameObject);
        }
        yield return new WaitForSeconds(delay);
        ResetPath();
    }

    public void AddToAlgorithm(string name) {
        // This function is called when a block is placed in the algorithm development area

        // First block placed
        bool first = false;
        if (Algorithm == null || Algorithm.Length == 0) {
            Algorithm = new string[50, 3];
            first = true;
        }

        switch (algorithmIndexJ) {
            case (0):
                switch (name) {
                    case ("Swim"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        algorithmIndexJ++;
                        break;
                    case ("Jump"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        algorithmIndexJ++;
                        break;
                }
                break;
            case (1):
                switch (name) {
                    case ("Up"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        switch (Algorithm[algorithmIndexI, algorithmIndexJ - 1]) {
                            case ("Swim"):
                                algorithmIndexJ++;
                                break;
                            case ("Jump"):
                                algorithmIndexI++;
                                algorithmIndexJ = 0;
                                if (first)
                                    renderBusy = false;
                                else
                                    ClearPath();
                                break;
                        }
                        break;
                    case ("Left"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        switch (Algorithm[algorithmIndexI, algorithmIndexJ - 1]) {
                            case ("Swim"):
                                algorithmIndexJ++;
                                break;
                            case ("Jump"):
                                algorithmIndexI++;
                                algorithmIndexJ = 0;
                                if (first)
                                    renderBusy = false;
                                else
                                    ClearPath();
                                break;
                        }
                        break;
                    case ("Down"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        switch (Algorithm[algorithmIndexI, algorithmIndexJ - 1]) {
                            case ("Swim"):
                                algorithmIndexJ++;
                                break;
                            case ("Jump"):
                                algorithmIndexI++;
                                algorithmIndexJ = 0;
                                if (first)
                                    renderBusy = false;
                                else
                                    ClearPath();
                                break;
                        }
                        break;
                    case ("Right"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        switch (Algorithm[algorithmIndexI, algorithmIndexJ - 1]) {
                            case ("Swim"):
                                algorithmIndexJ++;
                                break;
                            case ("Jump"):
                                algorithmIndexI++;
                                algorithmIndexJ = 0;
                                if (first)
                                    renderBusy = false;
                                else
                                    ClearPath();
                                break;
                        }
                        break;
                }
                break;
            case (2):
                switch (name) {
                    case ("1"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        algorithmIndexI++;
                        algorithmIndexJ = 0;
                        if (first)
                            renderBusy = false;
                        else
                            ClearPath();
                        break;
                    case ("2"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        algorithmIndexI++;
                        algorithmIndexJ = 0;
                        if (first)
                            renderBusy = false;
                        else
                            ClearPath();
                        break;
                    case ("3"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        algorithmIndexI++;
                        algorithmIndexJ = 0;
                        if (first)
                            renderBusy = false;
                        else
                            ClearPath();
                        break;
                    case ("4"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        algorithmIndexI++;
                        algorithmIndexJ = 0;
                        if (first)
                            renderBusy = false;
                        else
                            ClearPath();
                        break;
                    case ("5"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        algorithmIndexI++;
                        algorithmIndexJ = 0;
                        if (first)
                            renderBusy = false;
                        else
                            ClearPath();
                        break;
                    case ("6"):
                        Algorithm[algorithmIndexI, algorithmIndexJ] = name;
                        algorithmIndexI++;
                        algorithmIndexJ = 0;
                        if (first)
                            renderBusy = false;
                        else
                            ClearPath();
                        break;
                }
                break;
        }
    }

    public string[,] GetAlgorithm() {
        return Algorithm;
    }

    public bool GetRenderBusy() {
        return renderBusy;
    }

    public int GetAlgorithmIndexI() {
        return algorithmIndexI;
    }

    public int GetAlgorithmIndexJ() {
        return algorithmIndexJ;
    }
}
