using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreditsStartClick()
    {
        Debug.Log("クレジット画面に移動");
        FadeManager.Instance.LoadScene("Credits", 1.0f);
    }
}
