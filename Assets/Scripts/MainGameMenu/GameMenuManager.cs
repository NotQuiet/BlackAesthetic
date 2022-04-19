using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Eli
{
    public class GameMenuManager : MonoBehaviour, IRequireController<StateController>, IRequireController<GameManagerController>
    {
        [SerializeField] private Button _startGame;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitGameButton;

        [SerializeField] private CanvasGroup _settingsWindow;
        [SerializeField] private CanvasGroup _exitConfirmationWindow;

        private GameManagerController _gameManagerController;
        private StateController _stateController;


        private void OnEnable()
        {
            _startGame.onClick.AddListener(OnStartGameClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
            _exitGameButton.onClick.AddListener(OnExitButtonClick);

            SetLocalScalesOnPanels();
        }

        private void SetLocalScalesOnPanels()
        {
            _settingsWindow.transform.localScale = Vector2.zero;
            _exitConfirmationWindow.transform.localScale = Vector2.zero;
        }

        private void OnSettingsButtonClick()
        {
            Open(_settingsWindow, 0.3f);
        }

        private void OnExitButtonClick()
        {
            Open(_exitConfirmationWindow, 0.3f);
        }

        private void Open(CanvasGroup panel, float time)
        {
            panel.gameObject.SetActive(true);
            panel.transform.LeanScale(Vector2.one, time).setEaseInBack();
        }

        private void Close(CanvasGroup panel, float time)
        {
            panel.transform.LeanScale(Vector2.zero, time).setEaseInBack();
            panel.gameObject.SetActive(false);
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
