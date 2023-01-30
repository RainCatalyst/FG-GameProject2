using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogic : MonoBehaviour
{
    private CharacterMovement characterMovement;
    [SerializeField]
    private int playerNumber = 1;

    private string horizontalAxis;
    private string verticalAxis;

    private void Awake()
    {
        horizontalAxis = "Horizontal" + playerNumber;
        verticalAxis = "Vertical" + playerNumber;

        characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        Vector2 moveDirection;
        moveDirection.x = Input.GetAxis(horizontalAxis);
        moveDirection.y = Input.GetAxis(verticalAxis);

        characterMovement.Move(moveDirection);
    }

}
