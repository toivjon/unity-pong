using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

/// <summary>
/// A script that handles the goal behaviour in the game.
/// </summary>
public class Goal : MonoBehaviour {

    // the score limit for the game.
    private const int SCORE_LIMIT = 10;

    /// <summary>A reference to right paddle.</summary>
    public Paddle rightPaddle;
    /// <summary>A reference to left paddle.</summary>
    public Paddle leftPaddle;

    /// <summary>A reference to right score.</summary>
    public TextMesh rightScore;
    /// <summary>A reference to left score.</summary>
    public TextMesh leftScore;

    void OnCollisionEnter2D(Collision2D collision) {
        if (gameObject.name == "RightGoal") {
            GameContext ctx = GameContext.Instance;
            ctx.Player1Score++;
            if (ctx.Player1Score >= SCORE_LIMIT) {
                SceneManager.LoadScene("EndGame");
            } else {
                rightScore.text = ctx.Player1Score.ToString();
                ResetPaddles();
                ResetBall(collision.collider.gameObject);
            }
        } else if (gameObject.name == "LeftGoal") {
            GameContext ctx = GameContext.Instance;
            ctx.Player2Score++;
            if (ctx.Player2Score >= SCORE_LIMIT) {
                SceneManager.LoadScene("EndGame");
            } else {
                leftScore.text = ctx.Player2Score.ToString();
                ResetPaddles();
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

    /// <summary>
    /// Reset the paddles back into the default positions.
    /// </summary>
    void ResetPaddles() {
        rightPaddle.Reset();
        leftPaddle.Reset();
    }

}
