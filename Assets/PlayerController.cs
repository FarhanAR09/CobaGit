using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        playerInput = new();
    }

    private void Start()
    {
        rb.velocity = new Vector2(6, 0);
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.PlayerActionMap.Enable();
        playerInput.PlayerActionMap.Jump.performed += Jump;
    }

    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.PlayerActionMap.Disable();
        playerInput.PlayerActionMap.Jump.performed -= Jump;
    }

    private void FixedUpdate()
    {
        float xPos = transform.position.x;
        if (!(Mathf.Abs(xPos) < 8))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }

        if (transform.position.y < -5)
        {
            rb.velocity = new Vector2(rb.velocity.x, 6);
        }
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        rb.velocity = new Vector2(rb.velocity.x, 6);
        Debug.Log("Jump");
    }
}
