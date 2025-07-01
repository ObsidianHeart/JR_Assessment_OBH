using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 6f;

    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded;

    // Add this variable to track movement input
    private float moveInput = 0f;
    private bool isButtonMoving = false; // Track if UI button is controlling movement

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Keyboard Input only if not using UI buttons
        if (!isButtonMoving)
        {
            float keyboardInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(keyboardInput) > 0.01f)
            {
                moveInput = keyboardInput;
                animator.SetBool("isWalking", true);
                animator.SetBool("isIdle", false);
            }
            else
            {
                moveInput = 0f;
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", true);
            }
        }

        rb.linearVelocity = new Vector3(moveInput * moveSpeed, rb.linearVelocity.y, 0f);

        // Keyboard Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    // UI Button Functions 
    public void MoveLeft()
    {
        isButtonMoving = true;
        moveInput = -1f;
        animator.SetBool("isWalking", true);
        animator.SetBool("isJumping", false);
        animator.SetBool("isIdle", false);
    }

    public void MoveRight()
    {
        isButtonMoving = true;
        moveInput = 1f;
        animator.SetBool("isWalking", true);
        animator.SetBool("isJumping", false);
        animator.SetBool("isIdle", false);
    }

    public void StopMovement()
    {
        isButtonMoving = false;
        moveInput = 0f;
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", true);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}