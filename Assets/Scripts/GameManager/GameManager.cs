using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;


namespace Eli
{
    internal class GameManager : MonoBehaviour, IRequireController<GameManagerController>
    {
        private GameManagerController _gameManagerController;

        public void AssignController(GameManagerController controller)
        {
            _gameManagerController = controller;
        }
    }
}
