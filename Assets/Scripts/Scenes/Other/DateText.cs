using UnityEngine;
using UnityEngine.UI;
using System;

public class Datetext : MonoBehaviour
{
    //テキストUIをドラッグ&ドロップ
    [SerializeField] Text DateTimeText;

    //DateTimeを使うため変数を設定
    DateTime TodayNow;

    void Update()
    {
        //時間を取得
        TodayNow = DateTime.Now;

        //テキストUIに月・日・年を表示させる（海外風）
        DateTimeText.text = TodayNow.Month.ToString() + "/" + TodayNow.Day.ToString() + "/" + TodayNow.Year.ToString();
    }
}