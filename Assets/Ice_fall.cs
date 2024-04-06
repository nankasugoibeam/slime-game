using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_fall : MonoBehaviour
{
    public float fallSpeed = 5f; // 尖刺的掉落速度
    public LayerMask playerLayer; // 指定一个LayerMask，用于射线只检测玩家层
    public float detectionDistance = 10f; // 尖刺检测玩家的垂直距离

    private Rigidbody2D rb;
    private bool hasHitGround = false;
    private bool hasDetectedPlayer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // 初始不受重力影响，静止在空中
    }

    void Update()
    {
        if (!hasHitGround && !hasDetectedPlayer)
        {
            // 使用射线检测下方是否有玩家
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, detectionDistance, playerLayer);
            if (hit.collider != null)
            {
                // 如果检测到玩家
                hasDetectedPlayer = true;
                rb.gravityScale = 1; // 或者 rb.velocity = new Vector2(0, -fallSpeed);
            }
        }
        else if (hasDetectedPlayer && !hasHitGround)
        {
            // 更新尖刺位置
            rb.velocity = new Vector2(0, -fallSpeed);
        }
        else if (hasHitGround)
        {
            // 如果尖刺已经碰到地面或平台，停止移动
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0; // 停止受重力影响
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            // 如果尖刺碰到了地面或平台，停止移动
            hasHitGround = true;
        }
        else if (collision.gameObject.tag == "Player")
        {
            // 如果尖刺碰到了玩家，触发相应效果
            Debug.Log("Player hit by spike");
            // 这里可以添加影响玩家的代码
        }
    }
}
