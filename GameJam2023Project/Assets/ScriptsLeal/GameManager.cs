using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : IPresistentSingleton<GameManager>
{

    private string _currentScene;
    public System.Action<string> OnSceneLoaded;

    [SerializeField]
    private GameState _gameState;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciou State Machine");
        _gameState.OnBegin();
    }

    // Update is called once per frame
    void Update()
    {
        _gameState.OnUpdate();
    }

    public void LoadScene(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        if(asyncOperation != null)
        {
            _currentScene = sceneName;
            asyncOperation.completed += (AsyncOperation) => OnSceneLoaded?.Invoke(_currentScene);
        }
    }


}
