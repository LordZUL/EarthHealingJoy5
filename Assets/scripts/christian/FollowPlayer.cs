using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    void Start() { enabled = false; }

    void LateUpdate()
    {
        Vector3 p = transform.position;
        p.x = player.position.x;
        transform.position = p;
    }
}