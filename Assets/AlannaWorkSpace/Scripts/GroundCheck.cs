using UnityEngine;
//https://www.youtube.com/watch?v=z3dequX5g_E&t=13s semikoder suggests using slope angle and ground surface normal to see if ground is not wall etc, potato uses physics materials to solve I think,
public class GroundCheck : MonoBehaviour
{
    public PlayerController playerController;
    //public float maxSlopeAngle = 30f;
    // when hit ground, grounded == true
    private void OnTriggerEnter(Collider other)
    {
        //if object collided is ourself, exit
        if (other.gameObject == playerController.gameObject)
        {
            return;
        }
        playerController.SetGrounded(true);
    }
    // when leave ground, set to false
    private void OnTriggerExit(Collider other)
    {
        //if object collided is ourself, exit
        if (other.gameObject == playerController.gameObject)
        {
            return;
        }
        playerController.SetGrounded(false);
    }
    //while on ground, keep grounded = true
    private void OnTriggerStay(Collider other)
    {
        //if object collided is ourself, exit
        if (other.gameObject == playerController.gameObject)
        {
            return;
        }
        playerController.SetGrounded(true);
    }
}
