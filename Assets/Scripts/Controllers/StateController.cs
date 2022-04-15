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
            var asuncOperation = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            await asuncOperation.Task;
        }
    }
}
