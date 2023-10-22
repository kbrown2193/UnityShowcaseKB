using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTrigger : MonoBehaviour
{
    [SerializeField]
    private string cinematicKey;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered CinematicTrigger");
        if (other.CompareTag("Player")) // Assuming the player has the tag "Player"
        {
            Debug.Log("Player entered CinematicTrigger");
            PeformCinematicTrigger();
        }
    }

    public void PeformCinematicTrigger()
    {
        CinematicsManager.Instance.PlayCinematic(cinematicKey);
    }
}
