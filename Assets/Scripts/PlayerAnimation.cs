using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        SetPlayerAnimation();
    }

    private void SetPlayerAnimation()
    {
        animator.SetBool(Animator.StringToHash("isGrounded"), playerController.isGrounded);
        animator.SetBool(Animator.StringToHash("isMoving"), new Vector3(playerController.rb.velocity.x, 0, playerController.rb.velocity.z).magnitude >= 0.1f && playerController.isGrounded);
    }
}
