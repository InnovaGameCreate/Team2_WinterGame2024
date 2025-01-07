using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefaultMove : MonoBehaviour
{
    [Tooltip("“G‚Ì“®‚«‚ÌU•")]
    [SerializeField] float amplitude = 0.2f;

    void FixedUpdate()
    {
        UpDown();
    }

    void UpDown() // “G‚ğã‰º‚ÉU“®‚³‚¹‚é
    {
        float T = 3.0f;
        float F = 1.0f / T;

        float posYSin = Mathf.Sin(2.0f * Mathf.PI * F * Time.time);
        iTween.MoveAdd(gameObject, new Vector3(0, amplitude * posYSin, 0), 0.0f);

    }
}