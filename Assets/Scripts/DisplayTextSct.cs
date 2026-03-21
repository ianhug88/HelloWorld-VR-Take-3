using UnityEngine;

public class DisplayTextSct : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter(Collider other)//when pressing the platform 
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true); //set the text to active
        }
    }

    private void OnTriggerExit(Collider other) { 
        if (other.CompareTag("Player"))
        {
            text.SetActive(false); //otherwise to false 
        }
    
    }


}
