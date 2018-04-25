using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmManager : MonoBehaviour {

    private GameObject AlgorithmPathManager;
    private DialogBoxManager DialogBoxManager;

    // Use this for initialization
    void Start () {
        AlgorithmPathManager = GameObject.Find("AlgorithmPathManager");
        DialogBoxManager = GameObject.Find("DialogBoxManager").GetComponent<DialogBoxManager>();
    }
	
	public void DeleteSelect() {
        // TODO: Delete selected rows from algorithm

        DialogBoxManager.DeleteDialogBox();
    }

    public void ResetAll() {
        AlgorithmPathManager.GetComponent<AlgorithmPathManager>().ResetAlgorithm();

        DialogBoxManager.DeleteDialogBox();
    }
}
