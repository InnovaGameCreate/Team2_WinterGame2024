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
    public static GameObject[] flaskArray = new GameObject[8];
    public static int[] flaskStatus = new int[8];
    public static int itemNumber = 3;
    // 0=水、1=毒、2=アイテム、5=フラスコが存在しない

    public float distance = 100f;

    public static GameObject GiveButton;     // 相手に飲ませるボタン
    public static GameObject GetButton;      // 自分が飲むボタン
    public static GameObject[] itemArray = new GameObject[3];        // アイテム
    [SerializeField] private GameObject PoisonText;
    [SerializeField] private GameObject WaterText;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 8 ; i++)
        {
            flaskStatus[i] = Random.Range(0, itemNumber - 1);   // ランダムに効果格納
            flaskArray[i] = GameObject.Find($"flask{i + 1}"); // フラスコをシーン内から取得
        }
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

                        // 飲むか飲ませるかの条件式を追加

                        if (flaskStatus[flaskNumber - 1] == 1 && myLifePoint > 0)
                        {
                            Debug.Log("毒だった");
                            StartCoroutine(sleep(PoisonText,1.0f));
                            flaskArray[flaskNumber - 1].SetActive(false);
                            flaskStatus[flaskNumber - 1] = 5;
                            myLifeArray[myLifePoint - 1].SetActive(false);
                            myLifePoint--;
                            if (myLifePoint <= 0)
                            {
                                Debug.Log("ゲームオーバー！");
                                FadeManager.Instance.LoadScene("Result", 0.3f);
                            }
                        }

                        else if (flaskStatus[flaskNumber - 1] == 0)
                        {
                            Debug.Log("水だった");
                            StartCoroutine(sleep(WaterText, 1.0f));
                            flaskArray[flaskNumber - 1].SetActive(false);
                            flaskStatus[flaskNumber - 1] = 5;
                        }

                        // ↓ランダム効果

                        else if (flaskStatus[flaskNumber - 1] == 2)
                        {
                            Debug.Log("ランダム効果1発動");
                            flaskArray[flaskNumber - 1].SetActive(false);
                            flaskStatus[flaskNumber - 1] = 5;
                        }

                        else if (flaskStatus[flaskNumber - 1] == 3)
                        {
                            Debug.Log("ランダム効果2発動");
                            flaskArray[flaskNumber - 1].SetActive(false);
                            flaskStatus[flaskNumber - 1] = 5;

                        }

                        GameManager.isPlayerTurn = false;
                    }

                }
            }
        }
    }

    IEnumerator sleep(GameObject textObject, float x)
    {
        textObject.SetActive(true);
        // x秒待つ
        yield return new WaitForSeconds(x);
        textObject.SetActive(false);
    }
}
