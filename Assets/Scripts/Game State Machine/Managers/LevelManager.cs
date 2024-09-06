using UnityEngine;
using UnityEngine.SceneManagement;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class LevelManager : MonoBehaviour
{
    [Header("Script References")]
    public GameManager _gameManager;
    public UIManager _uIManager;
    public GameStateManager _gameStateManager;
    public CameraManager _cameraManager;
    public PlayerManager _playerManager;


    public int nextScene;
    //private int currentScene;

    public void Awake()
    {
        // Check for missing script references
        if (_uIManager == null) { Debug.LogError("UIManager is not assigned to LevelManager in the Inspector!"); }        
        if (_gameManager == null) { Debug.LogError("GameManager is not assigned to LevelManager in the Inspector!"); }

        if (_gameStateManager == null) { Debug.LogError("GameStateManager is not assigned to LevelManager in the Inspector!"); }
    }


    public void LoadNextlevel()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene <= SceneManager.sceneCountInBuildSettings)  
        {            
            LoadScene(nextScene);
            _gameStateManager.SwitchToState(_gameStateManager.gameState_GamePlay);
        }

        else if (nextScene > SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("All levels complete!");
        }
    }

    void LoadScene(int sceneId)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneId);
    }

    public void LoadMainMenuScene()
    {
        LoadScene(0);
        _gameStateManager.SwitchToState(_gameStateManager.gameState_GameInit);
    }

    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
        _gameStateManager.SwitchToState(_gameStateManager.gameState_GamePlay);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int LevelCount = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene Loaded: " + scene.name + " Build Index: " + scene.buildIndex);

        if (scene.buildIndex > 0)
        {
            // Set the ball to the current level start position            
            _playerManager.SetPlayerToStartPosition();

            // Set the camera to the current level start position
            //_cameraManager.ResetCameraPosition();

            
            
            // Update the current level # on the UI
            _uIManager.UpdateLevelCount(LevelCount);


        }
        else if (scene.buildIndex == 0)
        {
            // Noting really needed here, buildIndex 0 = MainMenu scene,
            // Which would be loaded with via 'LoadMainMenuScene' which also switches to the GameInitState which handles all the prep/resetting for the MainMenu.
            // Leaving this here in case of debugging or future use.
        }
        // (Unsuscribe) Stop listening for sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    

}



