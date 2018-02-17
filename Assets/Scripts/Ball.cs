using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    /// <summary>The movement velocity of the ball.</summary>
    public float velocity = 30f;

    /// <summary>A cached reference to ball rigidbody.</summary>
    private Rigidbody2D rigidBody;

    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start() {
        // start the movement of the ball.
        rigidBody.velocity = Vector2.right * velocity;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "LeftPaddle") {
            // calculate the normalized [-1...1] hit point.
            var y = (transform.position.y - collision.transform.position.y)  / collision.collider.bounds.size.y;

            // calculate and set a new direction for the ball.
            var direction = new Vector2(-1, y).normalized;
            rigidBody.velocity = direction * velocity;
        } else if (collision.gameObject.name == "RightPaddle") {
            // calculate the normalized [-1...1] hit point.
            var y = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;

            // calculate and set a new direction for the ball.
            var direction = new Vector2(-1, y).normalized;
            rigidBody.velocity = direction * velocity;
        }
    }

}
