using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    [Tooltip("自分の体力")]
    public GameObject[] myLifeArray = new GameObject[4];
    public static int myLifePoint = 4;

    [Tooltip("敵の体力")]
    public GameObject[] enemyLifeArray = new GameObject[4];
    public static int enemyLifePoint = 4;

    [Tooltip("フラスコ")]
    public GameObject[] flaskArray = new GameObject[8];
    public static int[] flaskStatus = new int[8];
    // 0...水、1...毒、2...アイテム、5...フラスコが存在しない

    public float distance = 100f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 8 ; i++)
        {
            flaskStatus[i] = Random.Range(0, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックを取得
        if (Input.GetMouseButtonDown(0))
        {
            // クリックしたスクリーン座標をrayに変換
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Rayの当たったオブジェクトの情報を格納する
            RaycastHit hit = new RaycastHit();
            // オブジェクトにrayが当たった時
            if (Physics.Raycast(ray, out hit, distance))
            {
                // rayが当たったオブジェクトの名前を取得
                string objectName = hit.collider.gameObject.name;
                Debug.Log(objectName);

                if (objectName.Contains("flask"))
                {
                    char temp = objectName[5];
                    int flaskNumber = int.Parse(temp.ToString());

                    if (flaskStatus[flaskNumber - 1] == 1 && myLifePoint > 0)
                    {
                        Debug.Log("毒だった");
                        flaskArray[flaskNumber - 1].SetActive(false);
                        flaskStatus[flaskNumber - 1] = 5;
                        myLifeArray[myLifePoint - 1].SetActive(false);
                        myLifePoint--;
                        if (myLifePoint <= 0)
                        {
                            Debug.Log("ゲームオーバー！");
                            SceneManager.LoadScene("Result");
                        }
                    }

                    else if (flaskStatus[flaskNumber - 1] == 0)
                    {
                        Debug.Log("水だった");
                        flaskArray[flaskNumber - 1].SetActive(false);
                        flaskStatus[flaskNumber - 1] = 5;
                    }

                    else if (flaskStatus[flaskNumber - 1] == 2)
                    {
                        Debug.Log("ランダム効果発動");
                        flaskArray[flaskNumber - 1].SetActive(false);
                        flaskStatus[flaskNumber - 1] = 5;
                    }
                }
            }

        }
    }

    /*
    public void OnPointerClick(PointerEventData eventData)
    {
        print($"{name}をクリックした");

        CameraChanger.CameraChange();
    }
    */
}
