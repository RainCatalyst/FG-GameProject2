using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;
    private Vector2 movementDirection;
    private Rigidbody rb;

    public void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(movementDirection.x, 0, movementDirection.y) * speed;
    }



}
