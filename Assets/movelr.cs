using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class movelr : MonoBehaviour
{
    public Tilemap tilemap; // 瓦片地图
    public float panSpeed = 50f; // 平移速度
    public float panLimit = 1000f; // 平移限制

    private float originalXPosition;
    private bool movingRight = true; // 初始方向向右

    void Start()
    {
        // 记录初始位置
        originalXPosition = tilemap.transform.position.x;
    }

    void Update()
    {
        // 根据当前方向和速度计算移动量
        float step = movingRight ? panSpeed * Time.deltaTime : -panSpeed * Time.deltaTime;

        // 更新新位置
        tilemap.transform.position += new Vector3(step, 0, 0);

        // 检查是否达到限制
        if (movingRight && tilemap.transform.position.x >= originalXPosition + panLimit)
        {
            movingRight = false; // 切换方向
        }
        else if (!movingRight && tilemap.transform.position.x <= originalXPosition - panLimit)
        {
            movingRight = true; // 切换方向
        }
    }
}
