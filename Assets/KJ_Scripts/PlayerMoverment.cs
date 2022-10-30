using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForrce = 5f;

    [SerializeField] Transform groudCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;
    public float rotationspeed =720;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (rb.velocity != Vector3.zero || !IsGrounded() )
        {
            Quaternion toRotation = Quaternion.LookRotation(rb.velocity);
            rb.MoveRotation(toRotation);
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

    }

    bool Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForrce, rb.velocity.z);
        jumpSound.Play();
        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Hat"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groudCheck.position, .1f, ground);
    }
}
