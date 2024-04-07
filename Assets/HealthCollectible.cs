using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectSound; // 收集音效

    void OnTriggerEnter2D(Collider2D other)
    {
        GrapplingHook controller = other.GetComponent<GrapplingHook>();
        if (controller != null)
        {
            controller.changeHealth(1);

            PlaySound(collectSound); // 播放收集音效

            Destroy(gameObject); // 销毁当前游戏对象
        }
    }

    void PlaySound(AudioClip clip)
    {
        // 创建一个新的游戏对象来播放音效
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.playOnAwake = false;
        audioSource.Play();

        // 音效播放完毕后销毁音效游戏对象
        Destroy(soundGameObject, clip.length);
    }
}
