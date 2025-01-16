using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChooseMotion : MonoBehaviour
{
    Vector3 firstPosition;  // 初期位置
    private Animator anim;
    private int myFlaskNumber;
    // Start is called before the first frame update
    void Start()
    {
        firstPosition = transform.position;
        anim = gameObject.GetComponent<Animator>();
        myFlaskNumber = int.Parse(name[5].ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isPlayerTurn)
        {
            transform.position = firstPosition;
        }

        if (myFlaskNumber == LifeManager.flaskNumber && LifeManager.isUsingFlask[myFlaskNumber])
        {
            //Bool型のパラメーターであるblRotをTrueにする
            anim.SetBool("IsUsing", true);
        }
    }

    //マウスカーソルがアイテム、フラスコに乗った時の処理
    private void OnMouseEnter()
    {
        if (GameManager.isPlayerTurn)
        {
            transform.position = new Vector3(firstPosition.x, firstPosition.y + 3, firstPosition.z);
        }
    }

    //マウスカーソルがアイテム、フラスコから離れた時の処理
    private void OnMouseExit()
    {
        if (GameManager.isPlayerTurn)
        {
            transform.position = new Vector3(firstPosition.x, firstPosition.y, firstPosition.z);
        }

    }
}
