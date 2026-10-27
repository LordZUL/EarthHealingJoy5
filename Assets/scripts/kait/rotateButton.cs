using UnityEngine;

public class rotateButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked()
    {
        transform.Rotate(Vector3.forward * 60* Time.deltaTime);
    }
}
