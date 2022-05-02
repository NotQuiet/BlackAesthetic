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
        public async Task ChangeStateAsync(GameState state)
        {
            switch (state)
            {
                case GameState.GameMenu:
                    await LoadScene("GameMenu");
                    break;
                case GameState.TestField:
                    await LoadScene("TestField");
                    break;
                    default:
                    Debug.Log("Default case");
                    break;
            }
        }

        private async Task LoadScene(string sceneName)
        {
            var asyncOperation = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            await asyncOperation.Task;   

            //UnloadScene(CurrentScene);

            //CurrentScene = sceneName;
        }


        private void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
