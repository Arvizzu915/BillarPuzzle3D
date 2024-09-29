using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    public Vector3 direction;
    public bool moving = false;

    private void FixedUpdate()
    {
        if (moving)
        {
            rb.isKinematic = false;
            rb.velocity = direction * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper") | collision.gameObject.CompareTag("Ball"))
        {
            rb.velocity = Vector3.zero;
            transform.position = transform.position + (-direction * .05f);
            rb.isKinematic = true;
            moving = false;
        }
    }
}
