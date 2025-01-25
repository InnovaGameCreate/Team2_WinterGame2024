using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveButton : MonoBehaviour
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
        LifeManager.which = 2;
        Debug.Log("which = 2");
    }
}
