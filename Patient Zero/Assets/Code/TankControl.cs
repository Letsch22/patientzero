using UnityEngine;

// Daniel Letscher

/// <summary>
/// Implements player control of tanks, as well as collision detection.
/// </summary>
public class TankControl : MonoBehaviour {
    /// <summary>
    /// How fast to drive
    /// </summary>
    public float ForwardSpeed = 5f;

    public float SprintSpeed = 10f;

    /// <summary>
    /// Checks forward, turning, and fire keys to update tank position, rotation, and spawn projectiles
    /// </summary>
    internal void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += SprintSpeed * Vector3.up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += ForwardSpeed*Vector3.up*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += SprintSpeed * Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += ForwardSpeed * Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += SprintSpeed * Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += ForwardSpeed * Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += SprintSpeed * Vector3.down * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += ForwardSpeed * Vector3.down * Time.deltaTime;
        }
    }

    internal void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag.Equals("Projectile"))
        {
            ScoreManager.IncreaseScore(obj.gameObject.GetComponent<Projectile>().Creator, 10);
            Destroy(obj.gameObject);
        }
        if (obj.tag.Equals("Mine"))
        {
            ScoreManager.IncreaseScore(gameObject, -20);
            Destroy(obj.gameObject);
        }
    }

    /// <summary>
    /// Current rotation of the tank (in degrees).
    /// We need this because Unity's 2D system is built on top of its 3D system and so they don't
    /// give you a method for finding the rotation that doesn't require you to know what a quaternion
    /// is and what Euler angles are.  We haven't talked about those yet.
    /// </summary>
    private float Rotation {
        get
        {
            return transform.rotation.eulerAngles.z;
        }
        set {
            transform.rotation = Quaternion.Euler(new Vector3 (0, 0, value)); // don't worry about this just yet
        }
    }
}
