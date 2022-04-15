using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Eli
{
    public class StateController
    {
        public void ChangeState(GameState state)
        {
            switch (state)
            {
                case GameState.GameMenu:
                    Debug.Log(GameState.GameMenu);
                    break;
                case GameState.TestField:
                    Debug.Log(GameState.TestField);
                    break;
                    default:
                    Debug.Log("Default case");
                    break;
            }
        }
    }
}
