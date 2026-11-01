using UnityEngine;

public class FollowToggle : MonoBehaviour
{
    public FollowPlayer target;
    public bool startFollowing;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{name} touched by {other.name} (tag: {other.tag})");

        if (other.CompareTag("Player") || other.GetComponentInParent<Rigidbody>()?.CompareTag("Player") == true)
        {
            target.enabled = startFollowing;
            Debug.Log($"Follow set to {startFollowing}");
        }
    }
}