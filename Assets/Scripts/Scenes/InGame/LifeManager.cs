using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [Tooltip("Ž©•ª‚Ì‘Ì—Í")]
    public GameObject[] myLifeArray = new GameObject[4];
    private int myLifePoint = 4;

    [Tooltip("“G‚Ì‘Ì—Í")]
    public GameObject[] enemyLifeArray = new GameObject[4];
    private int enemyLifePoint = 4;

    [Tooltip("ƒtƒ‰ƒXƒR")]
    public GameObject[] flaskArray = new GameObject[8];
    private int flaskPoint = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetMouseButtonDown(0) && myLifePoint < 4)
        {
            myLifePoint++;
            myLifeArray[myLifePoint - 1].SetActive(true);
        }

        else if (Input.GetMouseButtonDown(1) && myLifePoint > 0)
        {
            myLifeArray[myLifePoint - 1].SetActive(false);
            myLifePoint--;
        }

        if (Input.GetMouseButtonDown(0) && enemyLifePoint < 4)
        {
            enemyLifePoint++;
            enemyLifeArray[enemyLifePoint - 1].SetActive(true);
        }

        else if (Input.GetMouseButtonDown(1) && enemyLifePoint > 0)
        {
            enemyLifeArray[enemyLifePoint - 1].SetActive(false);
            enemyLifePoint--;
        }

        if (Input.GetMouseButtonDown(0) && flaskPoint < 8)
        {
            flaskPoint++;
            flaskArray[flaskPoint - 1].SetActive(true);
        }

        else if (Input.GetMouseButtonDown(1) && flaskPoint > 0)
        {
            flaskArray[flaskPoint - 1].SetActive(false);
            flaskPoint--;
        }*/
    }
}
