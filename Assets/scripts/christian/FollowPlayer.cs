using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public bool followX = false;   

    void LateUpdate()
    {
        Vector3 p = transform.position;
        if (followX) p.x = player.position.x;   
        p.z = player.position.z;                
        transform.position = p;                 
    }
}