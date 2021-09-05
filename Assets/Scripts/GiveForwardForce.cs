using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveForwardForce : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float x = 0;
    [SerializeField] private float y = 0;
    [SerializeField] private float z = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(x, y, z);
    }
}
