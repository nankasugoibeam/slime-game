using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public Transform rotationPoint; // 旋转中心点
    public float rotationSpeed = 50f; // 旋转速度

    private void Start()
    {
        // 开始旋转协程
        StartCoroutine(RotateObject());
    }

    IEnumerator RotateObject()
    {
        // 无限循环
        while (true)
        {
            // 从左到右旋转180度
            float rotationAmount = 0f;
            while (rotationAmount < 270f)
            {
                float step = rotationSpeed * Time.deltaTime;
                transform.RotateAround(rotationPoint.position, Vector3.forward, step);
                rotationAmount += step;
                yield return null;
            }

            // 等待2秒
            yield return new WaitForSeconds(2);

            // 从右向左旋转180度回到原来位置
            rotationAmount = 0f; // 重置旋转量
            while (rotationAmount < 270f)
            {
                float step = rotationSpeed * Time.deltaTime;
                transform.RotateAround(rotationPoint.position, Vector3.forward, -step);
                rotationAmount += step;
                yield return null;
            }

            // 再次等待2秒，然后循环重复
            yield return new WaitForSeconds(2);
        }
    }
}
