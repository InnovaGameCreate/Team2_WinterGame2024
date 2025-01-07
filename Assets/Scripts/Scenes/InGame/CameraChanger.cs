using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [Tooltip("���C���J����")]
    public GameObject mainCamera;
    [Tooltip("�A�C�e���I�����̃J����")]
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
