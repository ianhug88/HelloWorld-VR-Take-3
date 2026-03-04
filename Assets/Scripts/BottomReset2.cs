using UnityEngine;

public class BottomReset2 : MonoBehaviour
{
    public Transform XR_Rig;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        XR_Rig.position = new Vector3(0, 0, 0);
        XR_Rig.rotation = Quaternion.Euler(0, 0, 0);
    }
}
