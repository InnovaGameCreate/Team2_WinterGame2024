using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour
{
    Vector3 firstPosition;
    private Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
        firstPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isPlayerTurn)
        {
            transform.position = firstPosition;
        }

        if (LifeManager.IsUsing)
        {
            StartCoroutine(Animation());
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

    IEnumerator Animation()
    {
        animator.SetBool("trigger_using", true);
        yield return new WaitForSeconds(0);
    }
}
