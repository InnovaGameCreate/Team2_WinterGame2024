using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [Tooltip("メインカメラ")]
    public GameObject mainCamera;
    [Tooltip("アイテム選択時のカメラ")]
    public GameObject chooseCamera;

    private static CameraChanger instance;

    void Awake()
    {
        instance = this;
    }

    public static void CameraChange()
    {
        if (instance != null)
        {
            instance.SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        if (mainCamera.activeSelf)
        {
            mainCamera.SetActive(false);
            chooseCamera.SetActive(true);
        }
        else
        {
            mainCamera.SetActive(true);
            chooseCamera.SetActive(false);
        }
    }
}
