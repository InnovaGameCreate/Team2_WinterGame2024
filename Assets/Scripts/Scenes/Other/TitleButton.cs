using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TitleStartClick()
    {
        Debug.Log("タイトル画面に戻った");
        FadeManager.Instance.LoadScene("Title", 1.0f);
        GameManager.ResetGame();
    }
}
