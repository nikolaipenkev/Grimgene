using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwFireBall;

    private Rigidbody2D theRB;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask wutIsGround;

    public bool isGrounded;

    private Animator anim;

    public GameObject fireBall;

    public Transform throwPoint;

    public AudioSource fireSound;

	// Use this for initialization
	void Start () {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, wutIsGround);
        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(throwFireBall))
        {

            GameObject ballClone = (GameObject)Instantiate(fireBall, throwPoint.position, throwPoint.rotation);

            ballClone.transform.localScale = transform.localScale;

            anim.SetTrigger("Attack");

            fireSound.Play();
        }

        if(theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }else if(theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
        
    }
}
