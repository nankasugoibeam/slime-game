using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smashsound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 当与瓦片地图碰撞时触发
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查碰撞对象是否为瓦片地图
        if (collision.gameObject.CompareTag("Tilemap"))
        {
            // 播放音效
            audioSource.Play();
        }
    }
}
