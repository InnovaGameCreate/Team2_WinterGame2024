using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskManager : MonoBehaviour
{
    // 現在アクティブなフラスコの個数（ResetFlasks() 内で決定）
    public int number;
    // インスペクタからフラスコとなる GameObject を8つ登録（各 GameObject には Flask コンポーネントを付与）
    [SerializeField] public GameObject[] flaskArray = new GameObject[8];

    void Start()
    {
        ResetFlasks();
    }

    public void ResetFlasks()
    {
        // ① すべてのフラスコを非アクティブにする
        foreach (GameObject flask in flaskArray)
        {
            flask.SetActive(false);
        }

        // ② ランダムな個数（5～8個）をアクティブにする
        number = Random.Range(5, 9);
        List<int> indices = new List<int>();
        while (indices.Count < number)
        {
            int randIndex = Random.Range(0, flaskArray.Length);
            if (!indices.Contains(randIndex))
            {
                indices.Add(randIndex);
                GameObject flaskObj = flaskArray[randIndex];
                flaskObj.SetActive(true);
                // ③ アクティブになったフラスコの中身を決定する
                Flask flaskComp = flaskObj.GetComponent<Flask>();
                if (flaskComp != null)
                {
                    flaskComp.DetermineContents();
                }
                else
                {
                    Debug.LogWarning("Flask コンポーネントが " + flaskObj.name + " に存在しません！");
                }
            }
        }
    }
}
