using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign in inspector
    public GameObject mainCamera; // Assign in inspector
    public GameObject playerCamera; // Assign in inspector

    void Start()
    {
        videoPlayer.loopPointReached += EndReached; // Subscribe to the loopPointReached event
    }

    void EndReached(VideoPlayer vp)
    {
        mainCamera.SetActive(false); // Disable the main camera
        playerCamera.SetActive(true); // Enable the player camera
    }
}