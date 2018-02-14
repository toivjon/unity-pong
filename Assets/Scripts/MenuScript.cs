using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// <para>
/// A script to handle the main menu functionality.
/// </para>
/// <para>
/// This is the major script to handle the functionality in the game main menu.
/// Script handles the change between the menu item selection when the player
/// toggles between the menu selection and when the desired action is selected.
/// </para>
/// </summary>
public class MenuScript : MonoBehaviour {
    
    /// <summary>An array of all menu items available.</summary>
    public MenuItem[] items;

    /// <summary>The index of the currently selected menu item.</summary>
    private int highlightedIndex = 0;

    void Start() {
        // ensure that the 1-player menu item is initally highlighted.
        Assert.IsTrue(items.Length > 0, "At least one menu item is required!");
        Highlight(highlightedIndex);
    }
    
    /// <summary>
    /// <para>
    /// Check the button press states in each frame update.
    /// </para>
    /// <para>
    /// User must be able to navigate in menu with UP and DOWN arrow keys. The
    /// selection is being confirmed when the user presses the ENTER key, which
    /// also proceeds the player to the next scene.
    /// </para>
    /// </summary>
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Highlight((highlightedIndex + items.Length - 1) % items.Length);
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Highlight((highlightedIndex + 1) % items.Length);
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            GameContext ctx = GameContext.Instance;
            switch (highlightedIndex) {
                case 0:
                    SceneManager.LoadScene("CourtScene");
                    break;
                case 1:
                    Application.Quit();
                    break;
                default:
                    Assert.IsTrue(false, "Invalid index: " + highlightedIndex);
                    break;
            }
        }
    }

    /// <summary>
    /// <para>
    /// Highlight the menu item with the provided index.
    /// </para>
    /// <para>
    /// This function will highlight the menu item with the provided index and
    /// also remove the highlight from all other menu items to keep only single
    /// item to be highlighted at a time.
    /// </para>
    /// </summary>
    /// <param name="index">The index of the target menu item.</param>
    private void Highlight(int index) {
        Assert.IsTrue(index >= 0, "Index must be a positive or zero integer!");
        Assert.IsTrue(index < items.Length, "Index is outside array bounds!");
        for (var i = 0; i < items.Length; i++) {
            items[i].Highlighted = (i == index);
        }
        highlightedIndex = index;
    }

}
