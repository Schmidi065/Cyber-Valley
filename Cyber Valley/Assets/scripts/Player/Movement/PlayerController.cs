using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter; 
    public VectorValue startingPosition;
   
    Vector2 MotionVector;
    public Vector2 lastMotionVector;

    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
    }

    private void FixedUpdate()
    {

     float Horizontal = Input.GetAxisRaw("Horizontal");
     float Vertical =  Input.GetAxisRaw("Vertical");

        // If movement input is not 0, try to move
        if ( movementInput != Vector2.zero ) {
            bool success = TryMove(movementInput);

            if(!success) {
                success = TryMove(new Vector2(movementInput.x, 0));
            
                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }

        }
        //motion Vector for other scripts
        MotionVector = new Vector2(
            Horizontal,
            Vertical
            );

        if (Horizontal != 0 || Vertical != 0)
        {
            lastMotionVector = new Vector2(
              Horizontal,
              Vertical  
            ).normalized;
        }

    }

    private bool TryMove(Vector2 direction) {
        // Check for potential collisions
        int count = rb.Cast(
            direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
            movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
            castCollisions, // List of collisions to store the found collisions into after the Cast is finished
            moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movemenent plus an offset
         
        if( count == 0 ) {

            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else {
            return false;
        } 
    }

    void OnMove( InputValue movementValue )
    {
        movementInput = movementValue.Get<Vector2>();
    }
}