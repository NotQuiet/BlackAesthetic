using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Eli
{
    internal class StartPoint : MonoBehaviour
    {
        //Models


        //Controllers
        private GameManagerController _gameManagerController;

        private void Awake()
        {
            Debug.Log("StartPoint awake");
            CreateModels();
            CreateControllers();
            InjectToControllers();
            InjectToMenus();
            //SetMainScene();
        }

        private void CreateModels()
        {

        }

        private void CreateControllers()
        {
            _gameManagerController = new GameManagerController();
        }

        private void InjectToMenus()
        {
            MonoBehaviour[] items = FindObjectsOfType<MonoBehaviour>();

            for(int i = 0; i < items.Length; i++)
            {
                DependencyInjection(items[i]);
            }
        }

        private void InjectToControllers()
        {
            DependencyInjection(_gameManagerController);
        }    

        public void DependencyInjection(object view)
        {
            if(view is IRequireController<GameManagerController> gameManagerController)
            {
                gameManagerController.AssignController(_gameManagerController);
            }
        }

        private void SetMainScene()
        {
            _gameManagerController.LoadScene("MainScene");
        }

    }
}
