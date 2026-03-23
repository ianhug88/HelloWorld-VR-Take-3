using System.Collections;
using UnityEngine;

public class mazeFloorDelete : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    //public GameObject button;
    public GameObject floor;
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
            floor.SetActive(false);
            StartCoroutine(floorReturnDelay(3f));
          
        }
    }

    IEnumerator floorReturnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        floor.SetActive(true);
    }

}
