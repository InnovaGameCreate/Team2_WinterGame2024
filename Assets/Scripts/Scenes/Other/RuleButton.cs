using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RuleStartClick()
    {
        Debug.Log("ルール説明画面に移動");
        FadeManager.Instance.LoadScene("Rule", 1.0f);
    }
}
