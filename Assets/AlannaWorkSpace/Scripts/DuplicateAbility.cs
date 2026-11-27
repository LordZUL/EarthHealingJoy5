using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DuplicateAbility : MonoBehaviour
{
    //ability only original have, because we dont have the duplicate to duplicate you know 
    public PlayerInputRouter router;
    public PlayerController original;
    public float duration = 5f;
    //duplicate object location
    private float spawnDistance = 0.1f;

    private bool _active;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnDuplicate(InputAction.CallbackContext context)
    {
        if (context.performed && !_active) StartCoroutine(DuplicateRoutine());
    }

    IEnumerator DuplicateRoutine()
    {
        _active = true;

        // 1. Spawn the clone
        Vector3 spawnPos = original.transform.position + original.transform.forward * spawnDistance;

        PlayerController clone = Instantiate(
            original,
            spawnPos,
            original.transform.rotation);

        // 2. Freeze the original
        original.rb.linearVelocity = Vector3.zero;
        original.rb.isKinematic = true;

        // 3. Give control to the clone
        router.SetActive(clone);

        yield return new WaitForSeconds(duration);

        // 4. Give control back and clean up
        router.SetActive(original);
        original.rb.isKinematic = false;

        _active = false;
        yield return new WaitForSeconds(duration);
        Destroy(clone.gameObject);

    }
}
