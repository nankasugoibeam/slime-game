using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Movelup : MonoBehaviour

{
    public Tilemap tilemap; // Tilemap reference
    public float panSpeed = 50f; // Panning speed
    public float panLimit = 1000f; // Panning boundary

    private float originalYPosition;
    private bool movingUp = true; // Initial direction upwards

    void Start()
    {
        // Record initial Y position for vertical panning
        originalYPosition = tilemap.transform.position.y;
    }

    void Update()
    {
        // Calculate movement amount based on the current direction and speed
        float step = movingUp ? panSpeed * Time.deltaTime : -panSpeed * Time.deltaTime;

        // Update the new position for vertical movement
        tilemap.transform.position += new Vector3(0, step, 0);

        // Check if the limit has been reached
        if (movingUp && tilemap.transform.position.y >= originalYPosition + panLimit)
        {
            movingUp = false; // Change direction downwards
        }
        else if (!movingUp && tilemap.transform.position.y <= originalYPosition - panLimit)
        {
            movingUp = true; // Change direction upwards
        }
    }
}
