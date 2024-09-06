﻿using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class GameManager : MonoBehaviour
{
    // with the refactor GameManager Doesn't really manager anything anymore...
    // it does hold the ShotsLeft varialble but thats it..


    [Header("Gameplay Info")]
    public int shotsLeft = 0;

    [Header("Per Level Info")]

    public GameObject startPosition;


    [Header("Script References")]
    public GameStateManager _gameStateManager;
    public LevelManager _levelManager;
    public UIManager _uIManager;
    public CameraManager _cameraManager;


  






}
