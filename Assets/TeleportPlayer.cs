using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeleportPlayer : MonoBehaviour
{
    public Transform targetPosition; // Set this in the Unity Editor to the position you want to teleport the player to

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Make sure your player has the tag "Player"
        {
            other.transform.position = targetPosition.position; 
        }
    }
}


