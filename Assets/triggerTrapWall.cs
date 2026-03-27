using UnityEngine;

public class triggerTrapWall : MonoBehaviour
{
    public trapWallPush trap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        trap.activate();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
}
