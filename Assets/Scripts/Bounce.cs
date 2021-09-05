using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastVel;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        lastVel = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var speed = lastVel.magnitude;
        var direction = Vector3.Reflect(lastVel.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
