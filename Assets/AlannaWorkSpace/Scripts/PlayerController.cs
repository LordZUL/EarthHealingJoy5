using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
//I used this link to make physics based controller (rigidbody) because the unity playercontroller is supposedly bad for physics based stuff https://youtu.be/1LtePgzeqjQ?si=E5nXp3k1kET3WuBu
//Improvement to rigidbody: https://www.youtube.com/watch?v=z3dequX5g_E&t=13s I updated this code according to suggestions from Semikoder on YouTube
// I also didnt lock mouse, because mouse will be used for ui exploration 
//there is no lookrotation, because camera is fixed third person

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed, sensitivity, maxForce, jumpForce;
    private Vector2 _inputMove;
    public bool grounded;
    //private float lookRotation;

    public bool lockedDirection;

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("Player moving!");
        _inputMove = context.ReadValue<Vector2>();
        //_direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("Player moving!");
        Jump();
        //JumpVersion2();
        //_direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    private void FixedUpdate()
    {
        Move();

        //MoveVer2();
    }

    void Move()
    {
        if (lockedDirection == true)
        {
            if (!grounded)
            {
                return;
            }
        }
        //find target velocity 
        // needs to be updated; you should not set velocity every physics frame because it breaks rigid built in physics, ned to add force.mode.velocity when adding force to rigidbody
        //need to solve slip
        // need to have seperate ground check system

        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 targetVelocity = new Vector3(_inputMove.x, 0.0f, _inputMove.y);
        targetVelocity *= speed;

        //align direction 
        targetVelocity = transform.TransformDirection(targetVelocity);

        //calculate force
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        // right now if you get on slope it doesnt fall
        //velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);
        velocityChange.y = 0f;


        //limit force 
        velocityChange = Vector3.ClampMagnitude(velocityChange, maxForce);

        //rb.AddForce(velocityChange, ForceMode.VelocityChange);
        //rb.AddForce(new Vector3(0, forceMagnitude, 0), ForceMode.VelocityChange);

        rb.AddForce(new Vector3(velocityChange.x, 0.0f, velocityChange.z), ForceMode.VelocityChange);
    }

    /*void MoveVer2()
    {
        //find target velocity 
        // needs to be updated; you should not set velocity every physics frame because it breaks rigid built in physics, ned to add force.mode.velocity when adding force to rigidbody
        //need to solve slip
        // need to have seperate ground check system
        if (lockedDirection == true)
        {
            if (!grounded)
            {
                return;
            }
        }

        

        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 targetVelocity = new Vector3(_inputMove.x, 0.0f, _inputMove.y);
        targetVelocity *= speed;

        //align direction 
        targetVelocity = transform.TransformDirection(targetVelocity);

        //calculate force
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        // right now if you get on slope it doesnt fall
        //velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);
        velocityChange.y = 0f;


        //limit force 
        velocityChange = Vector3.ClampMagnitude(velocityChange, maxForce);

        //rb.AddForce(velocityChange, ForceMode.VelocityChange);
        //rb.AddForce(new Vector3(0, forceMagnitude, 0), ForceMode.VelocityChange);

        rb.AddForce(new Vector3(velocityChange.x, 0.0f, velocityChange.z), ForceMode.VelocityChange);
    }*/
    void Jump()
    {
        Debug.Log("Jump pressed. Grounded: " + grounded);

        if (lockedDirection == true)
        {
            if (!grounded)
            {
                return;
            }
        }

        Vector3 jumpForces = rb.linearVelocity; 
        if (grounded)
        {
            jumpForces.y = jumpForce;
        }
        rb.linearVelocity = jumpForces;
        //if (rb.linearVelocity.y < 0)
        //{
            //rb.gravityScale = Data.gravityScale * 1.5f;
        //}
    }

    /*
    void JumpVersion2()
    {
        if (!grounded)
        {
            return;
        }

        Vector3 jumpForces = rb.linearVelocity;
        if (grounded)
        {
            jumpForces.y = jumpForce;
        }
        rb.linearVelocity = jumpForces;
        grounded = false;
        //if (rb.linearVelocity.y < 0)
        //{
        //rb.gravityScale = Data.gravityScale * 1.5f;
        //}
    }
    */
    public void SetGrounded(bool state)
    {
        grounded = state;
    }
}
