using UnityEngine;

// Daniel Letscher

/// <summary>
/// Implements player control of tanks, as well as collision detection.
/// </summary>
public class TankControl : MonoBehaviour {
    /// <summary>
    /// How fast to drive
    /// </summary>
    public float ForwardSpeed = 20f;
    public float SprintSpeed = 20f;
    public LayerMask layerMask;

    internal void Start()
    {
        layerMask = ~layerMask;
    }
    /// <summary>
    /// Checks forward, turning, and fire keys to update tank position, rotation, and spawn projectiles
    /// </summary>
    internal void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            if (Physics2D.Raycast(transform.position, Vector3.up, SprintSpeed * Time.deltaTime, layerMask) == false)
                transform.position += SprintSpeed * Vector3.up * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (Physics2D.Raycast(transform.position, Vector3.up, ForwardSpeed * Time.deltaTime, layerMask) == false)
                transform.position += ForwardSpeed * Vector3.up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            if (Physics2D.Raycast(transform.position, Vector3.left, SprintSpeed * Time.deltaTime, layerMask) == false)
                transform.position += SprintSpeed * Vector3.left * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Physics2D.Raycast(transform.position, Vector3.left, ForwardSpeed * Time.deltaTime, layerMask) == false)
                transform.position += ForwardSpeed * Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            if (Physics2D.Raycast(transform.position, Vector3.right, SprintSpeed * Time.deltaTime, layerMask) == false)
                transform.position += SprintSpeed * Vector3.right * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Physics2D.Raycast(transform.position, Vector3.right, ForwardSpeed * Time.deltaTime, layerMask) == false)
                transform.position += ForwardSpeed * Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            if (Physics2D.Raycast(transform.position, Vector3.down, SprintSpeed * Time.deltaTime, layerMask) == false)
                transform.position += SprintSpeed * Vector3.down * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Physics2D.Raycast(transform.position, Vector3.down, ForwardSpeed * Time.deltaTime, layerMask) == false)
                transform.position += ForwardSpeed * Vector3.down * Time.deltaTime;
        }
    }

    internal void OnTriggerEnter2D(Collider2D obj)
    {

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
