using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicksound : MonoBehaviour
{
    private AudioSource audioSource; // 用于播放音效的AudioSource组件

    void Start()
    {
        // 获取该游戏对象上的AudioSource组件
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 检查玩家是否点击了鼠标左键
        if (Input.GetMouseButtonDown(0)) // 0 表示鼠标左键
        {
            // 播放音效
            audioSource.Play();
        }
    }
}
