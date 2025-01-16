using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChooseMotion : MonoBehaviour
{
    Vector3 firstPosition;  // �����ʒu
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
            //Bool�^�̃p�����[�^�[�ł���blRot��True�ɂ���
            anim.SetBool("IsUsing", true);
        }
    }

    //�}�E�X�J�[�\�����A�C�e���A�t���X�R�ɏ�������̏���
    private void OnMouseEnter()
    {
        if (GameManager.isPlayerTurn)
        {
            transform.position = new Vector3(firstPosition.x, firstPosition.y + 3, firstPosition.z);
        }
    }

    //�}�E�X�J�[�\�����A�C�e���A�t���X�R���痣�ꂽ���̏���
    private void OnMouseExit()
    {
        if (GameManager.isPlayerTurn)
        {
            transform.position = new Vector3(firstPosition.x, firstPosition.y, firstPosition.z);
        }

    }
}
