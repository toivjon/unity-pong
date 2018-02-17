using UnityEngine;

public class Goal : MonoBehaviour {

    // the score limit for the game.
    private const int SCORE_LIMIT = 10;

    void OnCollisionEnter2D(Collision2D collision) {
        if (gameObject.name == "RightGoal") {
            GameContext ctx = GameContext.Instance;
            ctx.Player1Score++;
            if (ctx.Player1Score >= SCORE_LIMIT) {
                // TODO game over!
            }
        } else if (gameObject.name == "LeftGoal") {
            GameContext ctx = GameContext.Instance;
            ctx.Player2Score++;
            if (ctx.Player2Score >= SCORE_LIMIT) {
                // TODO game over!
            }
        }
    }

}
