using UnityEngine;

public class setElectricEnvironment : MonoBehaviour
{
    public DuplicateAbility duplicateAbility; // drag in the PlayerInput object
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();
        if (player == null) return;

        if (player != duplicateAbility.original) return;
        duplicateAbility.sparks = true;
    }
    
}
