using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rule2Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rule2StartClick()
    {
        Debug.Log("操作説明画面に移動");
        FadeManager.Instance.LoadScene("Rule2", 1.0f);
    }
}
