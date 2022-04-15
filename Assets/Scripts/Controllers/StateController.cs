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
    public class StateController
    {
        private string _currentScene = "GameMenu";

        public string CurrentScene { get { return _currentScene; } private set { _currentScene = value; } }
        public void ChangeState(GameState state)
        {
            switch (state)
            {
                case GameState.GameMenu:
                    LoadScene("GameMenu");
                    break;
                case GameState.TestField:
                    LoadScene("TestField");
                    break;
                    default:
                    Debug.Log("Default case");
                    break;
            }
        }

        private async Task LoadScene(string sceneName)
        {
            var asyncOperation = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            await asyncOperation.Task;   

            UnloadScene(CurrentScene);

            CurrentScene = sceneName;
        }


        private async Task UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
