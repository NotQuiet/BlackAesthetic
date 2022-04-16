using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Eli
{
    public class PauseScreenProvider : LocalAssetLoader
    {
        public Task<PauseScreen> Load()
        {
            Debug.Log("We are in provider");
            return LoadInternal<PauseScreen>("PauseMenu");
        }

        public void Unload()
        {
            UnloadInternal();
        }
    }
}
