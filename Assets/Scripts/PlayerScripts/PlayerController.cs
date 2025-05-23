using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce;
    public float rotationSpeed = 10f;
    public Transform cameraTransform;
    public CapsuleCollider playerCollider;
    public bool isGrounded;
    public bool isCollided;
    public float groundedOffset;
    public LayerMask mask;
    private Animator animator;
    private Rigidbody rb;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb= GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        HandleMovementAndRotation();
        HandleJump();
    }

    void HandleMovementAndRotation()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(v) > 0)
        {
            animator.SetFloat("Vertical", v);
        }
        else if (Mathf.Abs(h) > 0)
        {
            animator.SetFloat("Vertical", h);
        }
        else
        {
            animator.SetFloat("Vertical", 0);
        }
        

        // Flatten camera directions to XZ plane
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // Movement input relative to camera
        Vector3 move = Vector3.zero;

        // Stops wall sticking
        if (!isGrounded && isCollided)
        {

            move = new Vector3(0, rb.velocity.y,0);
         
        }
        else
        {
            move = camRight * h + camForward * v;
        }
        
        rb.velocity = new Vector3(move.x * moveSpeed,rb.velocity.y,move.z * moveSpeed);

        // Handle rotation only when moving
        if (move.magnitude > 0.01f && isGrounded)
        {

            Vector3 targetDirection = Vector3.zero;

            if (h > 0) targetDirection = camRight;         // D key
            else if (h < 0) targetDirection = -camRight;        // A key
            else if (v > 0) targetDirection = camForward;       // W key (optional)
            else if (v < 0) targetDirection = -camForward;      // S key (optional)

            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    void HandleJump()
    {
        CheckGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        float yVel = Mathf.Clamp(rb.velocity.y, -1, 1);
        animator.SetFloat("Jump", yVel);
        animator.SetBool("Grounded", isGrounded);


    }

    void CheckGrounded()
    {
        
        if (Physics.OverlapSphere(transform.position,playerCollider.radius*transform.localScale.x*0.75f,mask).Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        isCollided = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isCollided = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerCollider.radius* transform.localScale.x * 0.5f);
    }
}
