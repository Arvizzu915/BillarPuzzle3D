using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitBall : MonoBehaviour
{
    [SerializeField] float ballSpeed;

    Vector3 hitDirection = Vector3.zero;

    Rigidbody rbBall;

    // Start is called before the first frame update
    void Start()
    {
        rbBall = GetComponent<Rigidbody>();

        hitDirection = Vector3.left;

        rbBall.constraints = RigidbodyConstraints.None;
        rbBall.constraints = RigidbodyConstraints.FreezePositionZ;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (transform.position.x < distance.x) 
        {
            rbBall.velocity = rbBall.velocity;
        }
        else
        {
            rbBall.velocity = Vector3.zero;
        }
        */
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Bumper"))
        {
            rbBall.velocity = Vector3.zero;
        }
    }

    

    public void Hit(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            rbBall.velocity = hitDirection * ballSpeed;
        }
    }




    public void ChangeHitDirection(InputAction.CallbackContext callbackContext)
    {
        Vector2 input = callbackContext.ReadValue<Vector2>();

        if (input == Vector2.right)
        {
            hitDirection = Vector3.left;

            rbBall.constraints = RigidbodyConstraints.None;
            rbBall.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        }

        if (input == Vector2.left)
        {
            hitDirection = Vector3.right;

            rbBall.constraints = RigidbodyConstraints.None;
            rbBall.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        }

        if (input == Vector2.up)
        {
            hitDirection = new Vector3(0, 0, -1);

            rbBall.constraints = RigidbodyConstraints.None;
            rbBall.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
        }

        if (input == Vector2.down)
        {
            hitDirection = new Vector3(0, 0, 1);

            rbBall.constraints = RigidbodyConstraints.None;
            rbBall.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
        }
    }
}
