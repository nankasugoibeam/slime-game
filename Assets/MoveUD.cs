using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveUD : MonoBehaviour
{
    public Tilemap tilemap; // 瓦片地图
    public float panSpeed = 50f; // 平移速度
    public float panLimit = 1000f; // 平移限制

    private float originalYPosition;
    private bool movingUp = true; // 初始方向向上

    void Start()
    {
        // 记录初始位置
        originalYPosition = tilemap.transform.position.y;
    }

    void Update()
    {
        // 根据当前方向和速度计算移动量
        float step = movingUp ? panSpeed * Time.deltaTime : -panSpeed * Time.deltaTime;

        // 更新新位置
        tilemap.transform.position += new Vector3(0, step, 0);

        // 检查是否达到限制
        if (movingUp && tilemap.transform.position.y >= originalYPosition + panLimit)
        {
            movingUp = false; // 切换方向
        }
        else if (!movingUp && tilemap.transform.position.y <= originalYPosition - panLimit)
        {
            movingUp = true; // 切换方向
        }
    }
}
