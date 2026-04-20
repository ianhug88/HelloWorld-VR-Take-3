using System;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuitGame();
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
