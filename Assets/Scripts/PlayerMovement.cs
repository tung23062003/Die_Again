using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;
    private Vector3 moveInput;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        //Move
        Vector3 moveDirection = new(moveInput.x, 0, moveInput.y);
        moveDirection.Normalize();
        playerController.Move(moveDirection);
        playerController.Rotate(moveDirection);

    }

    public void SetMoveInputVector(Vector2 moveInput)
    {
        this.moveInput = moveInput;
    }
}
