using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Button jumpBtn;

    Vector2 moveInputVector = Vector2.zero;
    PlayerMovement playerMovement;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerMovement = GetComponent<PlayerMovement>();

#if UNITY_ANDROID || UNITY_IOS
        jumpBtn.onClick.AddListener(() => { playerController.Jump(); });
#endif
    }

#if UNITY_ANDROID || UNITY_IOS
    private void OnDestroy()
    {
        jumpBtn.onClick.RemoveAllListeners();
    }
#endif

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
        moveInputVector.x = joystick.Horizontal;
        moveInputVector.y = joystick.Vertical;
#endif
        playerMovement.SetMoveInputVector(moveInputVector);
    }
}
