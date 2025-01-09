using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.Title
{
    public class StartButton : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GameStartClick()
        {
            Debug.Log("ゲームスタート");
            SceneManager.LoadScene("InGame");
        }
    }
}
