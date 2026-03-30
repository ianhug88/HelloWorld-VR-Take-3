using UnityEngine;

public class checkpoint : MonoBehaviour
{

    public BottomReset2 bottom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (!other.CompareTag("Player")) return;
        bottom.checkpointActivate();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
