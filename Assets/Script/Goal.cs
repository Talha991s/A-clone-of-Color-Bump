using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement ball = other.GetComponent<PlayerMovement>();

        if (!ball || GameManager.singleton.GameEnded) return;

        GameManager.singleton.EndGame(true);

        Debug.Log("Reached Goal");
    }

}
