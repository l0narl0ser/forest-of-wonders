using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public async void LoadScene(AssetReference scene)
    {
        AsyncOperationHandle<SceneInstance> handle =
            Addressables.LoadSceneAsync(scene, LoadSceneMode.Single);
        await handle.Task;
        
    }
}