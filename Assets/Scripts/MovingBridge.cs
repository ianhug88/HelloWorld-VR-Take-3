using UnityEngine;

public class BridgeCarry : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) //when something (player) enters the collider
    {
        if (other.CompareTag("Player")) //if the other (player), enters the bridge, it'll activate the trigger and check if it's the player
        {
            other.transform.SetParent(transform); // we make the bridge the parent of the player
        }
    }

    private void OnTriggerExit(Collider other) //when the player "leaves" the collider
    {
        if (other.CompareTag("Player")) //we check if it's the player 
        {
            other.transform.SetParent(null); //We unset the bridge as the parent
        }
    }
}