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
        Debug.Log("ƒ^ƒCƒgƒ‹‰æ–Ê‚É–ß‚Á‚½");
        FadeManager.Instance.LoadScene("Title", 1.0f);
        GameManager.ResetGame();
    }
}
