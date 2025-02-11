using System.Collections;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] FlaskManager flaskManager;
    int which;

    public IEnumerator EnemyTurn()
    {
        // 敵が選ぶフラスコ：盤上に残る中からランダムに選択
        do
        {
            which = Random.Range(0, flaskManager.flaskArray.Length);
        } while (!flaskManager.flaskArray[which].activeSelf);

        // 敵の選択ロジック（有利な選択を一定確率で行う等、詳細は未定）
        int randomBias = Random.Range(1, 6);

        yield return new WaitForSeconds(2f);
    }
}
