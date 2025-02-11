using UnityEngine;

public class FlaskAnimation : MonoBehaviour
{
    private Vector3 firstPosition;

    void Start()
    {
        firstPosition = transform.position;
    }

    void Update()
    {
        transform.position = firstPosition;
    }

    // マウスカーソルが対象に乗ったときの処理
    private void OnMouseEnter()
    {
        transform.position = firstPosition + new Vector3(0, 3, 0);
    }

    // マウスカーソルが対象から離れたときの処理
    private void OnMouseExit()
    {
        transform.position = firstPosition;
    }
}
