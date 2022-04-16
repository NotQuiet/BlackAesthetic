using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Eli
{
    public class PauseModel : MonoBehaviour
    {
        [SerializeField] private Button _test;

        PauseMenuProvider _pauseProvider;

        private void OnEnable()
        {
            _test.onClick.AddListener(TestOnClick);
        }

        private void TestOnClick()
        {
            _pauseProvider.Unload();
        }
    }
}
