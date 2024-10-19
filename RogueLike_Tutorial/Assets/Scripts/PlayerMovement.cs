using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D rb;
    public float lastHorizontalVector;
    public float lastVerticalVector;
    public Vector2 moveDir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
        
    }
    void FixedUpdate(){
        Move();
    }
    void InputManagement(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX,moveY).normalized;
        if(moveDir.x !=0){
            lastHorizontalVector = moveDir.x;
        }
        if(moveDir.y !=0){
            lastHorizontalVector = moveDir.y;
        }
    }
    void Move(){
        rb.velocity = new Vector2 (moveDir.x*speed, moveDir.y*speed);
    }

}
