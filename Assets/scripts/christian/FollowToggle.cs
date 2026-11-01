using UnityEngine;

public class FollowToggle : MonoBehaviour
{
    public FollowPlayer target;
    public bool startFollowing;   // tick on the first box, untick on the second

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponentInParent<Rigidbody>()?.CompareTag("Player") == true)
        {
            target.followX = startFollowing;
        }
    }
}