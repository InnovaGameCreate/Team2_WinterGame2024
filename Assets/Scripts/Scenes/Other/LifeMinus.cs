using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class LifeMinus : MonoBehaviour
{
    void Start()
    {
        // �R���[�`�����J�n
        StartCoroutine(Life());
    }

    private IEnumerator Life()
    {
        // 2�b�҂�
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
        // �����ɏ�����ǉ�
        Debug.Log("2 seconds passed.");
    }
}
