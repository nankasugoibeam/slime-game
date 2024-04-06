using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextLevelChange : MonoBehaviour
{
    public int nextSceneLoad;
    public GameObject EndScreen;
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Debug.Log("aeaae");
            EndScreen.gameObject.SetActive(true);

            //SceneManager.LoadScene(nextSceneLoad);
            //
            //if(nextSceneLoad > PlayerPrefs.GetInt("levelAt")){
            //    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            //    Debug.Log(PlayerPrefs.GetInt("levelAt"));
            //}
        }
    }

    public void nextScene(){
        SceneManager.LoadScene(nextSceneLoad);
            
        if(nextSceneLoad > PlayerPrefs.GetInt("levelAt")){
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }

    public void returnMenu(){
        if(nextSceneLoad > PlayerPrefs.GetInt("levelAt")){
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
        SceneManager.LoadScene(0);
    }
}
