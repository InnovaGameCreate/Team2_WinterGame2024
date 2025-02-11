using UnityEngine;

// フラスコの種類（毒／水／ランダム効果）
public enum FlaskType
{
    Poison,
    Water,
    RandomEffect
}

public class Flask : MonoBehaviour
{
    // 現在のフラスコの中身
    public FlaskType flaskType;
    // ランダム効果の場合、どの効果か（※詳細は RandomEffect 列挙体を参照）
    public RandomEffect randomEffect;

    /// <summary>
    /// フラスコの中身を決定する。
    /// まず50%の確率で「水」とし、残りは「毒」とする。
    /// 「水」となった場合、さらに30%の確率でランダム効果（中身 RandomEffect）に変更する。
    /// </summary>
    public void DetermineContents()
    {
        // 50%で水（true）／毒（false）を決定
        bool isWater = Random.value < 0.5f;
        if (isWater)
        {
            // 水の場合、さらに30%の確率でランダム効果
            if (Random.value < 0.3f)
            {
                flaskType = FlaskType.RandomEffect;
                // RandomEffect 列挙体からランダムに効果を選ぶ
                var effects = System.Enum.GetValues(typeof(RandomEffect));
                randomEffect = (RandomEffect)effects.GetValue(Random.Range(0, effects.Length));
            }
            else
            {
                flaskType = FlaskType.Water;
            }
        }
        else
        {
            flaskType = FlaskType.Poison;
        }
        Debug.Log($"{gameObject.name} の中身: {flaskType}" +
                  (flaskType == FlaskType.RandomEffect ? $" ({randomEffect})" : ""));
    }
}
