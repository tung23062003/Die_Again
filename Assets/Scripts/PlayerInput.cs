using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    Vector2 moveInputVector = Vector2.zero;
    PlayerMovement playerMovement;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        //Move input
        moveInputVector.x = Input.GetAxis("Horizontal");
        moveInputVector.y = Input.GetAxis("Vertical");

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
            playerController.Jump();
#elif UNITY_ANDROID || UNITY_IOS
        //Move input
        moveInputVector.x = floatingJoystick.Horizontal;
        moveInputVector.y = floatingJoystick.Vertical;
#endif
        playerMovement.SetMoveInputVector(moveInputVector);
    }
}
