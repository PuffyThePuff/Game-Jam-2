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
            this.transform.forward = rb.velocity.normalized;
            this.transform.eulerAngles = new Vector3(0, transform.rotation.y, transform.rotation.z);
        }
    }
}
