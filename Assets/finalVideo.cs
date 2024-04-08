using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finalVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign in inspector
    public GameObject mainCamera; // Assign in inspector
    public GameObject playerCamera; // Assign in inspector
    public GameObject EndScreen;

    public bool triggered = false;

    void Start()
    {
        videoPlayer.loopPointReached += EndReached; 
    }

    void EndReached(VideoPlayer vp)
    {
        mainCamera.SetActive(false); // Disable the main camera
        playerCamera.SetActive(true); // Enable the player camera
        EndScreen.gameObject.SetActive(true);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !triggered )
        {
            videoPlayer.Play();
            playerCamera.SetActive(false); // Enable the player camera
            mainCamera.SetActive(true); // Disable the main camera
            triggered = true;
        }
    }
}
