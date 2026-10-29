using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
//I used this link to make physics based controller (rigidbody) because the unity playercontroller is supposedly bad for physics based stuff https://youtu.be/1LtePgzeqjQ?si=E5nXp3k1kET3WuBu
// I also didnt lock mouse, because mouse will be used for ui exploration 
//there is no lookrotation, because camera is fixed third person

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed, sensitivity, maxForce;
    private Vector2 _input;
    //private float lookRotation;

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("Player moving!");
        _input = context.ReadValue<Vector2>();
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
        Vector3 targetVelocity = new Vector3(_input.x, 0.0f, _input.y);
        targetVelocity *= speed;

        //align direction 
        targetVelocity = transform.TransformDirection(targetVelocity);

        //calculate force
        Vector3 velocityChange = (targetVelocity - currentVelocity);

        //limit force 
        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
    
}
