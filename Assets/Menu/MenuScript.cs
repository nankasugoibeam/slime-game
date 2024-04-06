using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void play(){
        SceneManager.LoadScene("LevelSelect");
    }

    public void quit(){
        Application.Quit();
    }
}
