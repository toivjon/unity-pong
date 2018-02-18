using UnityEngine;

public class Paddle : MonoBehaviour {

    /// <summary>The velocity of the paddle movement.</summary>
    public float velocity = 30f;

    /// <summary>The name of the axis controlling this script.</summary>
    public string axisName = "Left Player";

    /// <summary>A reference to rigid body.</summary>
    private Rigidbody2D rigidBody;
    
    void Awake() {
        // cache the rigidbody reference to be used in updates.
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        // update rigidbody velocity based on the axis value.
        var axis = Input.GetAxisRaw(axisName);
        rigidBody.velocity = new Vector2(0, axis) * velocity;
    }

    /// <summary>
    /// Reset the paddle position back to default position.
    /// </summary>
    public void Reset() {
        rigidBody.position = new Vector2(rigidBody.position.x, 0);
    }

}
