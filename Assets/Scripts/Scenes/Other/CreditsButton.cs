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
        Debug.Log("�N���W�b�g��ʂɈړ�");
        FadeManager.Instance.LoadScene("Credits", 1.0f);
    }
}
