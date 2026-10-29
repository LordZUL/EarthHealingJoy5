using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
//I used this link to make physics based controller (rigidbody) because the unity playercontroller is supposedly bad for physics based stuff https://youtu.be/1LtePgzeqjQ?si=E5nXp3k1kET3WuBu
// I also didnt lock mouse, because mouse will be used for ui exploration 
//there is no lookrotation, because camera is fixed third person

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed, sensitivity, maxForce, jumpForce;
    private Vector2 _inputMove, _inputJump;
    public bool grounded;
    //private float lookRotation;

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
        //_direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //find target velocity 
        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 targetVelocity = new Vector3(_inputMove.x, 0.0f, _inputMove.y);
        targetVelocity *= speed;

        //align direction 
        targetVelocity = transform.TransformDirection(targetVelocity);

        //calculate force
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        // right now if you get on slope it doesnt fall
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        //limit force 
        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void Jump()
    {
        Vector3 jumpForces = rb.linearVelocity; 
        if (grounded)
        {
            jumpForces.y = jumpForce;
        }
        rb.linearVelocity = jumpForces;
    }
    
    public void SetGrounded(bool state)
    {
        grounded = state;
    }
}
