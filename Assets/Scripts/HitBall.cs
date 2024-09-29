using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitBall : MonoBehaviour
{
    [SerializeField] float ballSpeed;

    public bool moving = false;
    public bool playerInRange = false;

    public Vector3 hitDirection = Vector3.zero;

    Rigidbody rbBall;

    public static HitBall instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rbBall = GetComponent<Rigidbody>();

        hitDirection = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        if (moving) 
        {
            rbBall.isKinematic = false;
            //rbBall.constraints = RigidbodyConstraints.None;
            rbBall.velocity = hitDirection * ballSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            rbBall.velocity = Vector3.zero;
            transform.position = transform.position + (-hitDirection * .05f);
            rbBall.isKinematic = true;
            moving = false;
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            rbBall.velocity = Vector3.zero;
            transform.position = transform.position + (-hitDirection * .05f);
            rbBall.isKinematic = true;
            moving = false;
            Ball ballScript = collision.gameObject.GetComponent<Ball>();
            ballScript.moving = true;
            ballScript.direction = hitDirection;
        }
    }


    public void Hit(InputAction.CallbackContext callbackContext)
    {
        if (playerInRange && callbackContext.performed)
        {
            moving = true;
        }
    }

}
