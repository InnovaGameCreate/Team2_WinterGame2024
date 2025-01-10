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
        Debug.Log("ƒ‹[ƒ‹à–¾‰æ–Ê‚ÉˆÚ“®");
        FadeManager.Instance.LoadScene("Rule", 1.0f);
    }
}
