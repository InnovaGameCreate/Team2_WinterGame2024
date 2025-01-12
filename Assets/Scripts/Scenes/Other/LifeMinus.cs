using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class LifeMinus : MonoBehaviour
{
    void Start()
    {
        // コルーチンを開始
        StartCoroutine(Life());
    }

    private IEnumerator Life()
    {
        // 2秒待つ
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
        // ここに処理を追加
        Debug.Log("2 seconds passed.");
    }
}
