using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed, jumpForce;
    [SerializeField] Rigidbody rb;

    Vector3 moveDirection;

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * playerSpeed;
    }


    public void Move(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            moveDirection = callbackContext.ReadValue<Vector3>();
        }
    }
    
}
