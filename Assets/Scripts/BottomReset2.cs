using UnityEngine;

using System.Collections;

public class BottomReset2 : MonoBehaviour
{
    public Transform XR_Rig;

    public enableFall enableFall;

    public ScreenFade screenFade;

    //public GameObject checkpoint;
    public bool checkpoint1Reached = false;
    public bool checkpoint2Reached = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkpoint1Activate()
    {
        checkpoint1Reached = true;
    }

    public void checkpoint2Activate()
    {
        checkpoint2Reached = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reOriginPlayer();
            StartCoroutine(HandleDeath());
            enableFall.resetPlayer();
        }
    }

    private void reOriginPlayer()
    {
        if (checkpoint1Reached == false)
        {
            XR_Rig.position = new Vector3(0, 0, 0);
            XR_Rig.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (checkpoint1Reached == true && checkpoint2Reached == false)
        {
            XR_Rig.position = new Vector3(0, 5, 60);
            XR_Rig.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (checkpoint2Reached == true)
        {
            XR_Rig.position = new Vector3(-3, 7, 121);
            XR_Rig.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
    IEnumerator HandleDeath()
    {
        screenFade.FadeIn();

        yield return new WaitForSeconds(1.2f); // let fade complete

        screenFade.FadeOut();
    }






}
