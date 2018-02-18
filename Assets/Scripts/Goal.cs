using UnityEngine;
using UnityEngine.Assertions;

public class Goal : MonoBehaviour {

    // the score limit for the game.
    private const int SCORE_LIMIT = 10;

    void OnCollisionEnter2D(Collision2D collision) {
        if (gameObject.name == "RightGoal") {
            GameContext ctx = GameContext.Instance;
            ctx.Player1Score++;
            if (ctx.Player1Score >= SCORE_LIMIT) {
                // TODO game over!
            } else {
                ResetBall(collision.collider.gameObject);
            }
        } else if (gameObject.name == "LeftGoal") {
            GameContext ctx = GameContext.Instance;
            ctx.Player2Score++;
            if (ctx.Player2Score >= SCORE_LIMIT) {
                // TODO game over!
            } else {
                ResetBall(collision.collider.gameObject);
            }
        }
    }

    /// <summary>
    /// Reset the ball position and start movement countdown.
    /// </summary>
    /// <param name="ballGameObject">A reference to the ball game object.</param>
    void ResetBall(GameObject ballGameObject) {
        Assert.IsNotNull(ballGameObject, "The ball game object cannot be null!");

        // reset the ball position and start movement countdown.
        Ball ball = ballGameObject.GetComponent<Ball>();
        Assert.IsNotNull(ball, "Other ball game object does not have a Ball script!");
        StartCoroutine(ball.Reset());
    }

}
