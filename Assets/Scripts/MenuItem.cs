using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

/// <summary>
/// <para>
/// A script that handles a single main menu item functionality.
/// </para>
/// <para>
/// Each main menu item can be highlighted, which indicates that the item is
/// being currently selected. Main menu should also ensure that only one item
/// can be highlighted at a time to avoid confusion about the selection.
/// </para>
/// </summary>
public class MenuItem : MonoBehaviour {

    /// <summary>The color used to highlight the item. </summary>
    private readonly Color HIGHLIGHT_COLOR = Color.green;
    /// <summary>The color used when the item is not highlighted.</summary>
    private readonly Color NORMAL_COLOR = Color.white;

    /// <summary>A scale used to highlight the item.</summary>
    private readonly Vector3 HIGHLIGHT_SCALE = new Vector3(1.1f, 1.1f, 1.0f);
    /// <summary>A scale used to when the item is not highlighted.</summary>
    private readonly Vector3 NORMAL_SCALE = new Vector3(1.0f, 1.0f, 1.0f);

    /// <summary>A reference to the text component.</summary>
    private Text text;
    /// <summary>The definition whether the item is highlighted.</summary>
    private bool highlighted;

    /// <summary>
    /// A definition whether the menu item is being highlighted.
    /// </summary>
    public bool Highlighted {
        set {
            highlighted = value;
            if (highlighted) {
                text.color = HIGHLIGHT_COLOR;
                text.transform.localScale = HIGHLIGHT_SCALE;
            } else {
                text.color = NORMAL_COLOR;
                text.transform.localScale = NORMAL_SCALE;
            }
        }
        get {
            return highlighted;
        }
    }
    
    void Awake() {
        // get and assert that the parent Text component.
        text = gameObject.GetComponent<Text>();
        Assert.IsNotNull(text, "Parent GO must have a Text component!");

        // ensure that the component is initially not highlighted.
        Highlighted = false;
    }

}
