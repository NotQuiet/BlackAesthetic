using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace Eli
{
    public class StateController
    {
        private Dictionary<string, AsyncOperationHandle> _handles;
        public Dictionary<string, AsyncOperationHandle> Handles { get { return _handles; } private set { _handles = value; } }


        private string _currentScene;
        public string CurrentScene { get { return _currentScene; } private set { _currentScene = value; } }


        //public string CurrentScene { get { return _currentScene; } private set { _currentScene = value; } }

        public async void ChangeState(GameState state)
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

            UnloadUnusedScenes();
        }

        private async Task LoadScene(string sceneName)
        {
            var handle = Handles.FirstOrDefault(x => x.Key == sceneName).Value;

            await handle.Task;   

            CurrentScene = sceneName;
        }


        private void UnloadUnusedScenes()
        {
            foreach(var scene in Handles)
            {
                if(scene.Key == CurrentScene)
                {
                    continue;
                }
                else
                {
                    Addressables.UnloadSceneAsync(scene.Value);
                }
                Debug.Log($"Scene \"{scene.Key}\" was unload.");
            }

            
        }

        public void CreateDictionary()
        {
            Handles.Add("GameMenu", Addressables.LoadSceneAsync("GameMenu", LoadSceneMode.Additive));
            Handles.Add("TestField", Addressables.LoadSceneAsync("TestField", LoadSceneMode.Additive));
        }
    }
}
