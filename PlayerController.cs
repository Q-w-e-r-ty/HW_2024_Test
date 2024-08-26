using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float gravity = 30f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float doubleJumpForce = 10f;
    [SerializeField] private float defaultMoveSpeed = 3.5f;

    private Vector3 motionStep;
    private bool jumpTwice = false;
    private float velocity = 0f;
    private float currentSpeed = 0f;
    private CharacterController controller;


    /// <summary>
    /// Enables/disables the ability to move the player character
    /// </summary>
    public bool CanMove { get; set; } = true;

    /// <summary>
    /// Awake is called before start
    /// </summary>
    private void Awake()
    {
        TryGetComponent(out controller);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = defaultMoveSpeed;
    }
    /// <summary>
    /// This maybe called more than once per frame
    /// </summary>
    private void FixedUpdate()
    {
        if (CanMove)
        {
            if (controller.isGrounded)
            {
                velocity = -gravity * Time.deltaTime;
            }
            else
            {
                velocity -= gravity * Time.deltaTime;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            if (controller.isGrounded)
            {
                if (jumpTwice)
                {
                    jumpTwice = false;
                }
                if (Input.GetButtonDown("Jump"))
                {
                    velocity = jumpForce;
                }
            }
            else if (!jumpTwice)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    jumpTwice = true;
                    velocity = doubleJumpForce;
                }
            }
        }
        ApplyMovement();
    }
    private void ApplyMovement()
    {
        motionStep = Vector3.zero;
        motionStep += transform.forward * Input.GetAxisRaw("Vertical");
        motionStep += transform.right * Input.GetAxisRaw("Horizontal");
        motionStep = currentSpeed * motionStep.normalized;
        motionStep.y += velocity;
        controller.Move(motionStep * Time.deltaTime);
    }

    public void TeleportToPosition(Vector3 position)
    {
        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;

    }
}
