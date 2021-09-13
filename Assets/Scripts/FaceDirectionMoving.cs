using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirectionMoving : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.normalized != Vector3.zero)
        {
            transform.forward = rb.velocity.normalized;
            transform.SetPositionAndRotation(transform.position, new Quaternion(0, transform.rotation.y, transform.rotation.z, transform.rotation.w));
        }
    }
}
