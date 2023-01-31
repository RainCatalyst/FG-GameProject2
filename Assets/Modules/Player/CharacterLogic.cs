using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterLogic : MonoBehaviour
{
    private CharacterMovement characterMovement;
    [SerializeField]
    private int playerNumber = 1;

    private string horizontalAxis;
    private string horizontalAxisJoy;
    private string verticalAxis;
    private string verticalAxisJoy;

    private void Awake()
    {
        horizontalAxis = "Horizontal" + playerNumber;
        horizontalAxisJoy = "HorizontalJoy" + playerNumber;
        verticalAxis = "Vertical" + playerNumber;
        verticalAxisJoy = "VerticalJoy" + playerNumber;

        characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        Vector2 moveDirection;
        moveDirection.x = Input.GetAxis(horizontalAxis) + Input.GetAxis(horizontalAxisJoy);
        moveDirection.y = Input.GetAxis(verticalAxis) + Input.GetAxis(verticalAxisJoy);
        
        characterMovement.Move(moveDirection);
    }

    // public void OnMove(InputAction.CallbackContext ctx)
    // {
    //     characterMovement.Move(ctx.ReadValue<Vector2>());
    // }
}
