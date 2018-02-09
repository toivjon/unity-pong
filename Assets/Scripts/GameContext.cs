using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A game context object to hold a cross-scene game definitions.
/// </summary>
public class GameContext : MonoBehaviour {

    /// <summary>
    /// A game mode (i.e. multi- or single player) enumeration.
    /// </summary>
    public enum Mode { SINGLE_PLAYER, MULTIPLAYER };

    // a singleton instance of the context.
    private static GameContext instance;

    /// <summary>
    /// The function to receive a singleton instance of the context.
    /// </summary>
    public static GameContext Instance {
        get { return instance; }
    }

    /// <summary>
    /// The game mode (i.e. multi- or single player) being currently selected.
    /// </summary>
    public Mode GameMode { get; set; }

    void Awake() {
        // ensure that the scene only have a single GO with this script.
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }

        // assign the singleton instance and persist across scenes.
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
