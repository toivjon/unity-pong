using UnityEngine;

public class ResultsText : MonoBehaviour {

    void Awake() {
        // get a reference to game context and text mesh.
        var ctx = GameContext.Instance;
        var textMesh = GetComponent<TextMesh>();

        // specify the end results into the text component.
        textMesh.text = ctx.Player2Score + " - " + ctx.Player1Score;
    }

}
