using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollision : MonoBehaviour
{

    PlayerDeath playerDeath;

    private void Start()
    {
    }

    private void OnParticleCollision(GameObject other)
    {
        playerDeath = other.gameObject.GetComponent<PlayerDeath>();
        Debug.Log("Trail hit");

        if (playerDeath != null)
        {
            playerDeath.KillPlayer();

        }


    }
}
