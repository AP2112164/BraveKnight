using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpForce;
    private Rigidbody playerRB;
    //public bool isOnGround = true;
    public bool isOnSurfaces = true;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // player moves with A and D keys on x-axis
        //float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, 0);

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        // turns character to direction on key press
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("isWalking", true);// plays walking animation while moving in both directions
            Quaternion toRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        } else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown("w") && isOnSurfaces)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("isJumping", true);
            //isOnGround = false;
            isOnSurfaces = false;
        }

        if (Input.GetKeyDown("k")) // plays attacking animation
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        if (Input.GetKeyDown("l"))
        {
            animator.SetBool("isBlockingBlow", true);
        }
        else
        {
            animator.SetBool("isBlockingBlow", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.CompareTag("Ground"))
        //{
        //    isOnGround = true;
        //}

        if (collision.gameObject.CompareTag("Surface"))
        {
            isOnSurfaces = true;
        }
    }
}
