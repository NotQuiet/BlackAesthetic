using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Eli
{
    public class GameManagerController 
    {
        public GameManagerController() { }

        public void StartGame()
        {
            Debug.Log("StartGame2");
        }

        public void LoadScene(string sceneName)
        {
            Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }
}
