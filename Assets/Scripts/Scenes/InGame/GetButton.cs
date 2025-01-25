using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GiveButtonClick()
    {
        LifeManager.which = 1;
        Debug.Log("which = 1");
    }
}
