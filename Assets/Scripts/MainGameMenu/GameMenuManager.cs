using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Eli
{
    public class GameMenuManager : MonoBehaviour, IRequireController<StateController>, IRequireController<GameManagerController>
    {
        [SerializeField] private Button _startGame;

        private GameManagerController _gameManagerController;
        private StateController _stateController;


        private void OnEnable()
        {
            _startGame.onClick.AddListener(OnStartGameClick);
        }

        private void OnStartGameClick()
        {
            _ = _stateController.ChangeStateAsync(GameState.TestField);
        }

        public void AssignController(StateController controller)
        {
            _stateController = controller;
        }

        public void AssignController(GameManagerController controller)
        {
            _gameManagerController = controller;
        }
    }
}
