using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Eli
{
    public class LocalAssetLoader
    {
        // I think it should be a massif

        private GameObject _cachedObject;

        // Load and add to cache asset, async, with Addressables (protected)
        protected async Task<T> LoadInternal<T> (string assetID)
        {
            var handle = Addressables.InstantiateAsync(assetID);
            _cachedObject = await handle.Task;

            if(_cachedObject.TryGetComponent(out T load) == false)
            {
                throw new NullReferenceException($"Object of type {typeof(T)} is null on attempt to load it from Addressables"); 
            }

            return load;
        }

        // Unload cached object with Addressables (protected)
        protected void UnloadInternal()
        {
            if(_cachedObject == null)
            {
                return;
            }

            _cachedObject.SetActive(false);
            Addressables.ReleaseInstance(_cachedObject);
            _cachedObject = null;
        }

        ////Weird...
        //public void UnloadInternal(string assetID)
        //{
        //    if (_cachedObject == null)
        //    {
        //        return;
        //    }
        //    else if (_cachedObject.name == assetID)
        //    {
        //        _cachedObject.SetActive(false);
        //        Addressables.ReleaseInstance(_cachedObject);
        //        _cachedObject = null;
        //    }
        //    else
        //    {
        //        _cachedObject = GameObject.Find(assetID);
        //        _cachedObject.SetActive(false);
        //        Addressables.ReleaseInstance(_cachedObject);
        //        _cachedObject = null;
        //    }   
        //}
    }
}
