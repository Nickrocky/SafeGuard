using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public Animator animator;
    public Animator safeGuard;
    public Direction direction;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //This Function Updates EVERY FRAME so it updates (ideally) 60 times in 1 sec
    void Update()
    {
        //busy = GameHandler.gameHandler.isPlayerBusy;
        //Calling the method so the player can actually move.
        movePlayer();
    }
    //Method to Move the Player!
    private void movePlayer()
    {
        float moveSpeed = 2f;
        float runSpeed = 4f;

        //If Busy var == false then we will go and allow the player to move.
        if (true)
        {
            //If the player is running make them move faster
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                //Player can move left and right with a joystick and A/D keys respectively
                if (Input.GetAxisRaw("Horizontal") > .05f || Input.GetAxisRaw("Horizontal") < -.05f)
                {
                    transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime, 0f, 0f));

                }
                //Same thing with Y Axis and the W/S keys
                if (Input.GetAxisRaw("Vertical") > .05f || Input.GetAxisRaw("Vertical") < -.05f)
                {
                    transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * runSpeed * Time.deltaTime, 0f));
                }

                animatePlayer();
            }
            else
            {
                //Player can move left and right with a joystick and A/D keys respectively
                if (Input.GetAxisRaw("Horizontal") > .05f || Input.GetAxisRaw("Horizontal") < -.05f)
                {
                    transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));

                }
                //Same thing with Y Axis and the W/S keys
                if (Input.GetAxisRaw("Vertical") > .05f || Input.GetAxisRaw("Vertical") < -.05f)
                {
                    transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                }

                animatePlayer();
            }
        }
    }

    //TODO Make animations actually work.
    private void animatePlayer()
    {

        //JUST A TEST FOR TUTORIAL
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //Debug.Log("Right");
            Debug.Log("Right!");
            direction = Direction.RIGHT;

            //  anim.SetBool("MoveX", true);
            //   anim.SetBool("MoveUp", false);
            //  anim.SetBool("MoveDown", false);
            //  render.flipX = true;
            //  anim.speed = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            // Debug.Log("Left");
            Debug.Log("Left!");
            direction = Direction.LEFT;
            //  anim.SetBool("MoveX", true);
            // anim.SetBool("MoveUp", false);
            //  anim.SetBool("MoveDown", false);
            //  render.flipX = false;
            // anim.speed = 1;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            // Debug.Log("Down");
            Debug.Log("Backward!");
            direction = Direction.BACKWARD;
            //anim.SetBool("MoveX", false);
            // anim.SetBool("MoveUp", false);
            // anim.SetBool("MoveDown", true);
            //  anim.speed = 1;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            // Debug.Log("Up");
            Debug.Log("Forward!");
            direction = Direction.FORWARD;
            // anim.SetBool("MoveX", false);
            //anim.SetBool("MoveUp", true);
            //  anim.SetBool("MoveDown", false);
            // anim.speed = 1;
        }
        else
        {
            Debug.Log("Idling!");
            direction = Direction.IDLE;
        }
        updateSpriteAnimationByDirection();
    }
    private void updateSpriteAnimationByDirection()
    {
        switch (direction)
        {
            case Direction.IDLE:
                animator.SetInteger("Direction", 0);
                safeGuard.SetInteger("Direction", 0);
                break;
            case Direction.FORWARD:
                animator.SetInteger("Direction", 3);
                safeGuard.SetInteger("Direction", 3);
                break;
            case Direction.LEFT:
                animator.SetInteger("Direction", 1);
                safeGuard.SetInteger("Direction", 1);
                Flip(false);
                break;
            case Direction.RIGHT:
                animator.SetInteger("Direction", 1);
                safeGuard.SetInteger("Direction", 1);
                Flip(true);
                break;
            case Direction.BACKWARD:
                animator.SetInteger("Direction", 2);
                safeGuard.SetInteger("Direction", 2);
                break;
            
        }
    }
    private void Flip(bool isRight)
    {
        if(!m_FacingRight && isRight)
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
        else
        {
            if(m_FacingRight && !isRight)
            {
                m_FacingRight = false;
                // Multiply the player's x local scale by -1.
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
    }
}
public enum Direction
{
    FORWARD, LEFT, RIGHT, BACKWARD, IDLE
}
