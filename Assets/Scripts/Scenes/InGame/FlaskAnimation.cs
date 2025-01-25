using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskAnimation : MonoBehaviour
{
    Vector3 firstPosition;
    // Start is called before the first frame update
    void Start()
    {
        firstPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isPlayerTurn)
        {
            transform.position = firstPosition;
        }
    }

    //マウスカーソルがSphereに乗った時の処理
    private void OnMouseEnter()
    {
        if (GameManager.isPlayerTurn)
        {
            transform.position = new Vector3(firstPosition.x, firstPosition.y + 3, firstPosition.z);
        }
    }

    //マウスカーソルがSphereの上から離れた時の処理
    private void OnMouseExit()
    {
        if (GameManager.isPlayerTurn)
        {
            transform.position = new Vector3(firstPosition.x, firstPosition.y, firstPosition.z);
        }

    }
}
