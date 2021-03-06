﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A script that handles the end game description and proceedings.
/// </summary>
public class Endgame : MonoBehaviour {

    void Start() {
        // get a reference to game context and text mesh.
        var ctx = GameContext.Instance;
        var textMesh = GetComponent<TextMesh>();

        // update the text based on the winner.
        if (ctx.Player1Score > ctx.Player2Score) {
            textMesh.text = "RIGHT PLAYER";
        } else {
            textMesh.text = "LEFT PLAYER";
        }
    }

    void Update() {
        // proceed back to main menu after enter is pressed.
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Welcome");
        }
    }

}
