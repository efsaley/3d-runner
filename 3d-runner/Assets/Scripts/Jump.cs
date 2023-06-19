using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpHeight = 7f;
    public bool isGrounded;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     if (isGrounded)
      {
        if (Input.GetButtonDown("Jump"))
         {
           rb.AddForce(Vector3.up * jumpHeight);
         }
       }
    }
    void OnCollisionEnter(Collision other)
{
    if (other.gameObject.tag == "Ground")
    {
        isGrounded = true;
    }
}

void OnCollisionExit(Collision other)
{
    if (other.gameObject.tag == "Ground")
    {
        isGrounded = false;
    }
}
}
