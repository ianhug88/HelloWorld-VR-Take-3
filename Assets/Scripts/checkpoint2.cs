using UnityEngine;

public class checkpoint2 : MonoBehaviour
{

    public BottomReset2 bottom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //if (!other.CompareTag("Player")) return;
        bottom.checkpoint2Activate();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
