using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefaultMove : MonoBehaviour
{
    [Tooltip("敵の動きの振幅")]
    float amplitude = 0.2f;

    void FixedUpdate()
    {
        UpDown();
    }

    void UpDown()
    {
        float T = 3.0f;
        float F = 1.0f / T;

        // 上下に振動させる
        float posYSin = Mathf.Sin(2.0f * Mathf.PI * F * Time.time);
        iTween.MoveAdd(gameObject, new Vector3(0, amplitude * posYSin, 0), 0.0f);

    }
}