using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheck2;
    

    private float horizontal;
    


    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGround;
    private bool isGround2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround2 = Physics2D.OverlapCircle(groundCheck2.position, 0.3f, groundLayer);
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal != 0) 
        {
            Move(horizontal);
        }
        if(isGround && Input.GetKeyDown(KeyCode.UpArrow) || isGround2 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
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
