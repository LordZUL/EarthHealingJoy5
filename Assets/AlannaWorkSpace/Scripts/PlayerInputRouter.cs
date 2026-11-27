using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputRouter : MonoBehaviour
{
    //router is needed because currently playerInput uses the specific control on a specific character model, clone made with instantiate isnt in that list so it would not get the input 
    //point move and jump events at script instead of character --> router decide which controller is active

    //I asked claude for help "in unity 6.0, is it possible to spawn character duplication, freeze the original character controls, and control the duplicated character for 5 seconds? But what if I use playerInput. Right now I have player input as its own object, but it uses the event for gameplay and you manually put in a character controller script"
    public PlayerController activeController;
    public void OnMove(InputAction.CallbackContext context)
    {
        if (activeController != null) activeController.OnMove(context);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (activeController != null) activeController.OnJump(context);
    }

    public void SetActive(PlayerController newController)
    {
        // Stop the old one from sliding with its last stored input
        if (activeController != null) activeController.ClearInput();
        activeController = newController;
    }
}
