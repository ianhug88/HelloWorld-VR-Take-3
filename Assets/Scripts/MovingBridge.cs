using UnityEngine;

public class MovingBridge : MonoBehaviour{

    private Transform player;


    private void OnTriggerEnter(Collider other)
    {
        OVRPlayerController controller = other.GetComponentInParent<OVRPlayerController>();

        if (controller != null)
        {
            player = controller.transform;
            player.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OVRPlayerController controller = other.GetComponentInParent<OVRPlayerController>();

        if (controller != null && player != null)
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
