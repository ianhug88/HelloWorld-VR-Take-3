using UnityEngine;

public class MovingBridge : MonoBehaviour{

    private Transform player;


    private void BeginningBridge(Collider other)
    {
        if (other.GetComponent<OVRPlayerController>())
        {
            player = other.transform;
            player.SetParent(transform);
        }
    }

    private void EndBridge(Collider other)
    {
        if (other.GetComponent<OVRPlayerController>())
        {
            player.SetParent(null);
            player = null;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
