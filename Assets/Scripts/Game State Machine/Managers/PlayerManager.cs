using System.Collections;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class PlayerManager : MonoBehaviour
{
    [Header("References")]
    public GameObject player;  

    [Header("Script References")]
    public UIManager _uIManager;
    public GameManager _gameManager;
    public GameStateManager _gameStateManager;
    public CameraManager _CameraManager;
    public InputManager _inputManager;
    public PlayerLocomotionHandler _playerLocomotionHandler;

    [SerializeField, Header("Debug Output (read only)")]
    private float playerVelocityMagnitude;

    public void Awake()
    {
        // Check for missing script references
        if (_uIManager == null) { Debug.LogError("UIManager is not assigned to BallManager in the Inspector!"); }
        if (_gameManager == null) { Debug.LogError("GameManager is not assigned to BallManager in the Inspector!"); }
        if (_gameStateManager == null) { Debug.LogError("GameStateManager is not assigned to BallManager in the Inspector!"); }
        if (_CameraManager == null) { Debug.LogError("CameraManager is not assigned to BallManager in the Inspector!"); }
    }



    private void Start()
    {
        
    }

 
    void Update()
    {
        _inputManager.HandleAllInputs();
        _playerLocomotionHandler.HandleAllPlayerMovement();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GoalTrigger")
        {
            // Change tag to level end
        }

        else if (other.gameObject.tag == "ResetTrigger") 
        {
            SetPlayerToStartPosition();
        }
    }

    

    public void SetPlayerToStartPosition()
    {
        // TODO: lock out Character controller while move is performed...
        
        // Find Start Position object in current scene
        Transform startPosition = GameObject.FindWithTag("PlayerSpawnPosition").transform;
    }



}
