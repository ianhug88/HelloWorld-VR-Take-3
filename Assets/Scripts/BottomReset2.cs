using UnityEngine;

public class BottomReset2 : MonoBehaviour
{
    public Transform XR_Rig;

    //public GameObject checkpoint;
    public bool checkpointReached = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkpointActivate()
    {
        checkpointReached = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                reOriginPlayer();  
        }
    }

    private void reOriginPlayer()
    {
        if (checkpointReached == false)
        {
            XR_Rig.position = new Vector3(0, 0, 0);
            XR_Rig.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (checkpointReached == true)
        {
            XR_Rig.position = new Vector3(0, 5, 60);
            XR_Rig.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
