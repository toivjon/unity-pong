using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    // A color for the selected menu item.
    public Color selectionColor;
    // A color for the normal (non-selected) menu items.
    public Color normalColor;

    public Text onePlayerMenuItem;
    public Text twoPlayerMenuItem;
    
    void Start() {
        Assert.AreNotEqual(selectionColor, normalColor, "Selected and normal colors cannot be same!");
        Select(onePlayerMenuItem);
    }
    
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log("Detected an UP-arrow key press.");
            SwapSelection();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Debug.Log("Detected an DOWN-arrow key press.");
            SwapSelection();
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("Detected an ENTER-arrow key press.");
            // TODO ...
        }
    }
    
    private void Select(Text item) {
        Assert.IsNotNull(item, "The item cannot be null!");
        if (item.Equals(onePlayerMenuItem)) {
            Highlight(onePlayerMenuItem);
            Normalize(twoPlayerMenuItem);
        } else {
            Normalize(onePlayerMenuItem);
            Highlight(twoPlayerMenuItem);
        }
    }

    private void Highlight(Text item) {
        Assert.IsNotNull(item, "The item cannot be null!");
        item.color = selectionColor;
        item.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
    }

    private void Normalize(Text item) {
        Assert.IsNotNull(item, "The item cannot be null!");
        item.color = normalColor;
        item.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    
    private void SwapSelection() {
        if (IsOnePlayerSelected()) {
            Select(twoPlayerMenuItem);
        } else {
            Select(onePlayerMenuItem);
        }
    }
    
    private bool IsOnePlayerSelected() {
        return (onePlayerMenuItem.color == selectionColor);
    }
    
    private bool IsTwoPlayerSelected() {
        return (twoPlayerMenuItem.color == selectionColor);
    }

}
