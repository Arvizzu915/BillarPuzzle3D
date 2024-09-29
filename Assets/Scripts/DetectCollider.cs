using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!HitBall.instance.moving &&  other.gameObject.CompareTag("Player"))
        {
            HitBall.instance.playerInRange = true;
            HitBall.instance.hitDirection = -transform.localPosition;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HitBall.instance.playerInRange = false;
        }
    }
}
