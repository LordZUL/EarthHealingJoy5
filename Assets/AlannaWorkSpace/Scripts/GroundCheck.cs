using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController playerController;
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
