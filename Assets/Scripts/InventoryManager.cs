using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

    public Sprite[] CanSprites;
    public Image Inventory;
    public int MaxItems;
    private int CurrentItems;

    // Use this for initialization
    void Start() {
        CurrentItems = 0;
    }

    // Update is called once per frame
    void Update() {
        Inventory.sprite = CanSprites[CurrentItems];
    }

    public void PickItem() {
        if (CurrentItems < MaxItems)
            CurrentItems++;
    }

    public void DropItem() {
        if (CurrentItems > 0)
            CurrentItems--;
    }
}
