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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        // Keyboard Input 
        float keyboardInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(keyboardInput) > 0.01f)
        {
            moveInput = keyboardInput;
        }

        rb.linearVelocity = new Vector3(moveInput * moveSpeed, rb.linearVelocity.y, 0f);

        // Jump (Space Button) Logic
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // UI Button Functions 
    public void MoveLeft()
    {
        moveInput = -1f;
    }

    public void MoveRight()
    {
        moveInput = 1f;
    }

    public void StopMovement()
    {
        moveInput = 0f;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            //animator.SetTrigger("Jump"); 
        }
    }
}

//using UnityEngine; 
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using UnityEngine.InputSystem;

//public class PlayerController : MonoBehaviour 
//{ 
//    public float moveSpeed = 5f; 
//    public float jumpForce = 6f; 

//    private Rigidbody rb; 
//    private Animator animator; 
//    private bool isGrounded; 

//    void Start() 
//    { 
//        rb = GetComponent<Rigidbody>(); 
//        //animator = GetComponent<Animator>(); 
//    } 

//    void Update() 
//    { 
//        // Keyboard Input 
//        float moveInput = Input.GetAxis("Horizontal"); 
//        rb.linearVelocity = new Vector3(moveInput * moveSpeed, rb.linearVelocity.y, 0f);

//        // Animation Logic 
//        //if (Mathf.Abs(moveInput) > 0.1f) 
//        //{ 
//        //    animator.SetBool("isRunning", true); 
//        //} 
//        //else 
//        //{ 
//        //    animator.SetBool("isRunning", false); 
//        //} 
//        // Jump (Space Button) Logic
//        if (Input.GetButtonDown("Jump")) 
//        { 
//            Jump();
//        } 


//        //animator.SetBool("isGrounded", isGrounded); 
//    } 

//    void OnCollisionEnter(Collision collision) 
//    { 
//        if (collision.gameObject.CompareTag("Ground")) 
//        { 
//            isGrounded = true; 
//        } 
//    } 

//    // UI Button Functions 
//    public void MoveLeft() 
//    { 
//        rb.linearVelocity = new Vector3(-moveSpeed, rb.linearVelocity.y, 0f); 
//        //animator.SetBool("isRunning", true); 
//    } 

//    public void MoveRight() 
//    { 
//        rb.linearVelocity = new Vector3(moveSpeed, rb.linearVelocity.y, 0f); 
//        //animator.SetBool("isRunning", true); 
//    } 

//    public void StopMovement() 
//    { 
//        rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f); 
//        //animator.SetBool("isRunning", false); 
//    } 

//    public void Jump() 
//    { 
//        if (isGrounded) 
//        { 
//            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
//            isGrounded = false; 
//            //animator.SetTrigger("Jump"); 
//        } 
//    } 
//}

