using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 0f;
    public bool isGrounded = true;
    public float jumpForce = 650f;

    private Animator anim;
    private Rigidbody2D rig;

    public LayerMask LayerGround;

    public Transform checkGround;

    public string isGroundedBool = "EChao";
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        MovimentaPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    private void MovimentaPlayer()
    {
        transform.Translate(new Vector3(speed, 0, 0));
        
        
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));
        
        if (Physics2D.OverlapCircle(checkGround.transform.position, 0.2f, LayerGround))
        {
            anim.SetBool(isGroundedBool, true);
            isGrounded = true;
        }
        else
        {
            anim.SetBool(isGroundedBool, false);
            isGrounded = false;
        }

    }

    public void Jump()
    {
        rig.velocity = Vector2.zero;
        rig.AddForce(new Vector2(0,jumpForce));

    }
}