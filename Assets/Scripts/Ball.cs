using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    /// <summary>The initial velocity of the ball.</summary>
    public float initialVelocity = 10f;

    /// <summary>The maximum velocity of the ball.</summary>
    public float maxVelocity = 20f;

    /// <summary>The amount of velocity to increase on each paddle hit.</summary>
    public float velocityIncrease = 0.5f;

    /// <summary>The current velocity of the ball.</summary>
    private float velocity = 10f;

    /// <summary>A cached reference to ball rigidbody.</summary>
    private Rigidbody2D rigidBody;

    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start() {
        reset();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "LeftPaddle") {
            // calculate the normalized [-1...1] hit point.
            var y = (transform.position.y - collision.transform.position.y)  / collision.collider.bounds.size.y;

            // increase the ball velocity.
            velocity += velocityIncrease;
            velocity = Mathf.Min(velocity, maxVelocity);

            // calculate and set a new direction for the ball.
            var direction = new Vector2(-1, y).normalized;
            rigidBody.velocity = direction * velocity;
        } else if (collision.gameObject.name == "RightPaddle") {
            // calculate the normalized [-1...1] hit point.
            var y = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;

            // increase the ball velocity.
            velocity += velocityIncrease;
            velocity = Mathf.Min(velocity, maxVelocity);

            // calculate and set a new direction for the ball.
            var direction = new Vector2(-1, y).normalized;
            rigidBody.velocity = direction * velocity;
        }
    }

    /// <summary>
    /// <para>
    /// Reset the ball into the default (i.e. starting) state.
    /// </para>
    /// <para>
    /// This function will reset all ball definitions back into the default state.
    /// Useful e.g. to reset the ball state after either player receives a score.
    /// </para>
    /// </summary>
    private void Reset() {
        velocity = initialVelocity;

        rigidBody.position = new Vector2(0, 0);
        rigidBody.velocity = Vector2.right * velocity;
    }

}
