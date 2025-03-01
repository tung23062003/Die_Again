using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ICharacter
{
    [Header("Character Controller Settings")]
    [SerializeField] private float speed = 200;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed = 30;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.05f;

    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isJumping;
    [HideInInspector] public Rigidbody rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    public void Move(Vector3 direction)
    {
        Vector3 targetVelocity = speed * Time.deltaTime * direction;

        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z);
    }

    public void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void Update()
    {
        GroundCheck();
    }

    private void GroundCheck()
    {
        isGrounded = Physics.Raycast(groundCheckPoint.position, Vector3.up * -1, groundCheckDistance, groundLayer);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(rb.velocity.x, jumpForce, rb.velocity.z, ForceMode.Impulse);
            SFXManager.Instance.PlaySFX("Jump");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(groundCheckPoint.position, -1 * groundCheckDistance * Vector3.up);
        Gizmos.color = Color.red;
    }
}
