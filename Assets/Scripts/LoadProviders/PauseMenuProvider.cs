using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Eli
{
    public class PauseMenuProvider : LocalAssetLoader
    {
        public Task<PauseModel> Load()
        {
            Debug.Log("We are in provider");
            return LoadInternal<PauseModel>("PauseMenu");
        }

        public void Unload()
        {
            UnloadInternal();
        }
    }
}
