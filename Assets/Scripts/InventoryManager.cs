using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    private GameObject Inventory;
    private Text AluminumCount;
    private Text GlassCount;
    private Text PlasticCount;
    private int curAluminumItems;
    private int curGlassItems;
    private int curPlasticItems;

    // Use this for initialization
    void Start() {
        Inventory = GameObject.Find("Inventory");

        AluminumCount = Inventory.transform.Find("AluminumCount").GetComponent<Text>();
        GlassCount = Inventory.transform.Find("GlassCount").GetComponent<Text>();
        PlasticCount = Inventory.transform.Find("PlasticCount").GetComponent<Text>();

        // Initialize with saved data if any
        curAluminumItems = PersistentGameManager.Instance.CurAluminumItems;
        curGlassItems = PersistentGameManager.Instance.CurGlassItems;
        curPlasticItems = PersistentGameManager.Instance.CurPlasticItems;
    }

    void Update() {
        AluminumCount.text = curAluminumItems.ToString();
        GlassCount.text = curGlassItems.ToString();
        PlasticCount.text = curPlasticItems.ToString();
    }

    public void PickItem(string type) {
        if (type == "Aluminum" && curGlassItems == 0 && curPlasticItems == 0) {
            curAluminumItems++;
            AluminumCount.text = curAluminumItems.ToString();
        }
        else if (type == "Glass" && curAluminumItems == 0 && curPlasticItems == 0) {
            curGlassItems++;
            GlassCount.text = curGlassItems.ToString();
        }
        else if (type == "Plastic" && curAluminumItems == 0 && curGlassItems == 0) {
            curPlasticItems++;
            PlasticCount.text = curPlasticItems.ToString();
        }
    }

    public void DropItem(string type) {
        if (type == "Aluminum" && curAluminumItems > 0) {
            curAluminumItems--;
            AluminumCount.text = curAluminumItems.ToString();
        }
        else if (type == "Glass" && curGlassItems > 0) {
            curGlassItems--;
            GlassCount.text = curGlassItems.ToString();
        }
        else if (type == "Plastic" && curPlasticItems > 0) {
            curPlasticItems--;
            PlasticCount.text = curPlasticItems.ToString();
        }
    }

    public int GetCurAluminumItems() {
        return curAluminumItems;
    }

    public void SetCurAluminumItems(int curAluminumItems) {
        this.curAluminumItems = curAluminumItems;
    }

    public int GetCurGlassItems() {
        return curGlassItems;
    }

    public void SetCurGlassItems(int curGlassItems) {
        this.curGlassItems = curGlassItems;
    }

    public int GetCurPlasticItems() {
        return curPlasticItems;
    }

    public void SetCurPlasticItems(int curPlasticItems) {
        this.curPlasticItems = curPlasticItems;
    }
}
