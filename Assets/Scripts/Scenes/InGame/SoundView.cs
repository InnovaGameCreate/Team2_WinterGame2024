using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SoundView : MonoBehaviour
{
    public void FlaskDrink() { 
    //フラスコを飲む効果音
    
    }

    public void PoisonDrink() { 
    //毒を飲んだ効果音
    }

    public void RandomDrink() { 
        //ランダムを飲んだ効果音
    }

    public void UseAloe() { 
        //アロエを使ったとき
    }

    public void UseSerum() { 
        //血清を使用
    }

    public void UseSleepingPill() { 
        //睡眠薬を使用
    }

    public void DecreaseHp() { 
        //HP減少時
    }

    public void RoundChange() { 
        //ラウンド変更時
    }

    public void Victory() { 
        //勝利した時
    }
}
