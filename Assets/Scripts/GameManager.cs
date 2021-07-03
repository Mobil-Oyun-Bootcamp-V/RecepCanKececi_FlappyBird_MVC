using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager operates as a state machine and holds view and controller class references
    public static GameManager manager;

    public PlayerView _playerView;
    public ObstacleView _obstacleView;
    private PlayerController _playerController;
    public ObstacleController _obstacleController;

    public enum GameState 
        {
            Prepare,
            MainGame,
            FinishGame,
        }
    
    private GameState _currentGameState;

    public GameState CurrentGameState
    {
        get { return _currentGameState;}
        set
        {
            switch (value)
            {
                case GameState.Prepare:
                    break;
                case GameState.MainGame:                       
                    break;
                case GameState.FinishGame:                       
                    break;
            }
            _currentGameState = value;
        }           
    }
    private void Awake() 
    {
        manager = this;
    }

    private void Start() 
    {
        _playerController = new PlayerController(_playerView);
        _obstacleController = new ObstacleController(_obstacleView);
    }
    // In update method, GameManager switch game states
    private void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.Prepare:
                _playerView.OnGameStart += ToMainGame;
                break;
            case GameState.MainGame:
                _playerView.OnDead += ToFinishGame;
                break;
            case GameState.FinishGame:
                break;
        }
    }
    private void ToMainGame()
    {
        _currentGameState = GameState.MainGame;
    }
    private void ToFinishGame()
    {
        _currentGameState = GameState.FinishGame;
    }
    
}
