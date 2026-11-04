using UnityEngine;

public class AltCam : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "boundry"){
            if(other.name == "bound1")
            {
                if (transform.position.x < other.transform.position.x)
                {
                    cam1.SetActive(true);
                    cam2.SetActive(false);
                }
                else
                {
                    cam2.SetActive(true);
                    cam1.SetActive(false);
                }
            }
            else if(other.name == "bound2")
            {
                if (transform.position.z < other.transform.position.z)
                {
                    cam2.SetActive(true);
                    cam3.SetActive(false);
                }
                else
                {
                    cam3.SetActive(true);
                    cam2.SetActive(false);
                }
            }
            else if (other.name == "bound3")
            {
                if (transform.position.x < other.transform.position.x)
                {
                    cam4.SetActive(false);
                    cam2.SetActive(true);
                }
                else
                {
                    cam2.SetActive(false);
                    cam4.SetActive(true);
                }
            }
        }
    }
}
