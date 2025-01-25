using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
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
        public static GameObject[] flaskArray = new GameObject[8];
        public static int[] flaskStatus = new int[8];
        public static int itemNumber = 3;
        // 0=水、1=毒、2=ランダム効果、5=フラスコが存在しない

        public float distance = 100f;
        public static int which = 0; // 1 = player, 2 = enemy

        public GameObject GiveButton;     // 相手に飲ませるボタン
        public GameObject GetButton;      // 自分が飲むボタン
        public static GameObject[] itemArray = new GameObject[3];        // アイテム

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 8; i++)
            {
                flaskStatus[i] = Random.Range(0, itemNumber);   // ランダムに効果格納
                flaskArray[i] = GameObject.Find($"flask{i + 1}"); // フラスコをシーン内から取得
            }

            which = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.isPlayerTurn)
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
                        GameObject thatFlask = GameObject.Find($"flask{flaskNumber}");
                        Vector3 currentPosition = thatFlask.transform.position; // 現在の座標を取得
                        thatFlask.transform.position = new Vector3(currentPosition.x, currentPosition.y + 5, currentPosition.z); // y座標を3増加

                        GiveButton.SetActive(true);
                        GetButton.SetActive(true);
                        StartCoroutine(ChooseFlask(flaskNumber));

                            thatFlask.transform.position = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z); // 座標を戻す
                            GiveButton.SetActive(false);
                            GetButton.SetActive(false);
                        }
                    }
                }
            }

            // 敵のターン
            if(GameManager.isEnemyTurn)
            {
                int flaskNumber;
                do
                {
                    flaskNumber = Random.Range(1, 9);
                } while (flaskStatus[flaskNumber - 1] == 5);
                
                int temp = Random.Range(1, 6); // 敵を有利に
                if (temp ==  1)
                {
                    if (flaskStatus[flaskNumber - 1] == 1) which = 1; // 毒
                    else which = 2;
                }
                else
                {
                    which = Random.Range(1, 3);
                }

                if (which == 1)
                {
                    MyFlaskResult(flaskNumber);
                }
                else if (which == 2)
                {
                    EnemyFlaskResult(flaskNumber);
                }

                GameManager.isEnemyTurn = false;
                which = 0;
            }

            // 敗北
            if (myLifePoint <= 0)
            {
                GameManager.isWin = 1;  // 敗北
            }

            // 勝利
            if (enemyLifePoint <= 0)
            {
                GameManager.isWin = 2;  // 勝利
            }
        }

        void MyFlaskResult(int flaskNumber)
        {
            if (flaskStatus[flaskNumber - 1] == 1 && myLifePoint > 0)
            {
                Debug.Log("毒だった");
                StartCoroutine(GameManager.InfoDisplay("- Poison -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
                myLifeArray[myLifePoint - 1].SetActive(false);
                myLifePoint--;
            }

            else if (flaskStatus[flaskNumber - 1] == 0)
            {
                Debug.Log("水だった");
                StartCoroutine(GameManager.InfoDisplay("- Water -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
            }

            // ↓ランダム効果

            else if (flaskStatus[flaskNumber - 1] == 2)
            {
                Debug.Log("ランダム効果発動");
                StartCoroutine(GameManager.InfoDisplay("- Random Effect -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
            }
        }

        void EnemyFlaskResult(int flaskNumber)
        {
            if (flaskStatus[flaskNumber - 1] == 1 && enemyLifePoint > 0)
            {
                Debug.Log("毒だった");
                StartCoroutine(GameManager.InfoDisplay("- Poison -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
                enemyLifeArray[enemyLifePoint - 1].SetActive(false);
                enemyLifePoint--;
            }

            else if (flaskStatus[flaskNumber - 1] == 0)
            {
                Debug.Log("水だった");
                StartCoroutine(GameManager.InfoDisplay("- Water -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
            }

            // ↓ランダム効果

            else if (flaskStatus[flaskNumber - 1] == 2)
            {
                Debug.Log("ランダム効果発動");
                StartCoroutine(GameManager.InfoDisplay("- Random Effect -", 1));
                flaskArray[flaskNumber - 1].SetActive(false);
                flaskStatus[flaskNumber - 1] = 5;
            }
        }

    IEnumerator ChooseFlask(int flaskNumber)
    {

        which = 0;
        yield return new WaitUntil(() => which != 0);
        if (which == 1)
            {
                StartCoroutine(GameManager.InfoDisplay($"- You -", 3));
                MyFlaskResult(flaskNumber);
            }
            else if (which == 2)
            {
                StartCoroutine(GameManager.InfoDisplay($"- Enemy -", 3));
                EnemyFlaskResult(flaskNumber);
            }
        GameManager.isPlayerTurn = false;
        yield break;
    }
}
