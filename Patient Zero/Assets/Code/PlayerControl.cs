﻿using UnityEngine;

// Daniel Letscher

/// <summary>
/// Implements player control of tanks, as well as collision detection.
/// </summary>
public class PlayerControl : MonoBehaviour {
    /// <summary>
    /// How fast to drive
    /// </summary>
    public float ForwardSpeed = 10f;
    public float SprintSpeed = 25f;
    public LayerMask layerMask;
    private Animator animator;

    internal void Start()
    {
        layerMask = ~layerMask;
        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// Checks forward, turning, and fire keys to update tank position, rotation, and spawn projectiles
    /// </summary>
    internal void Update()
    {
        animator.SetBool("movingUp", false);
        animator.SetBool("movingRight", false);
        animator.SetBool("movingLeft", false);
        animator.SetBool("movingDown", false);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            move(SprintSpeed, Vector3.up, "movingUp");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            move(ForwardSpeed, Vector3.up, "movingUp");
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            move(SprintSpeed, Vector3.left, "movingLeft");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move(ForwardSpeed, Vector3.left, "movingLeft");
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            move(SprintSpeed, Vector3.right, "movingRight");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move(ForwardSpeed, Vector3.right, "movingRight");
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            move(SprintSpeed, Vector3.down, "movingDown");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move(ForwardSpeed, Vector3.down, "movingDown");
        }
    }

    private void move(float speed, Vector3 direction, string animationVariable)
    {
        if (Physics2D.Raycast(transform.position, direction, speed*Time.deltaTime, layerMask) == false)
            transform.position += speed*direction*Time.deltaTime;
        animator.SetBool(animationVariable, true);
    }


    internal void OnTriggerEnter2D(Collider2D obj)
    {

    }

}
