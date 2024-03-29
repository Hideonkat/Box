using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform WallCheck;
    [SerializeField] LayerMask wallLayer;

    private float horizontal;
    private bool isWallSlide;
    private float wallSlideSpeed = 1.0f;


    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal != 0) 
        {
            Move(horizontal);
        }
        if(isGround && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        WallSlide();
       

    }
    private bool isWall()
    {
        return Physics2D.OverlapCircle(WallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (isWall() && !isGround && horizontal != 0 )
        {
            isWallSlide = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }
        else
        {
            isWallSlide = false;
        }
    }
    private void Move(float horizontal)
    {
        rb.velocity = new Vector2 (horizontal * moveSpeed,rb.velocity.y);

    }
    void Jump()
    {
        rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
    }
}
