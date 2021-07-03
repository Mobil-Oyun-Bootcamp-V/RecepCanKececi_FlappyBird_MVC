using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerView : MonoBehaviour
{
    // PlayerView detect gameplay updates and sends events
    public UnityAction OnDead;
    public UnityAction OnJumpButton;
    public UnityAction OnJumpPrepare;
    public UnityAction OnGameStart;
    public bool isKinem = true;

    public Rigidbody2D playerRb;

    private void Update() 
    {
        switch (GameManager.manager.CurrentGameState)
            {
                case GameManager.GameState.Prepare:
                    GameStart();
                    break;
                case GameManager.GameState.MainGame:
                    JumpPrepare();
                    JumpAction();
                    GameDifficulty();
                    break;
                case GameManager.GameState.FinishGame:
                    break;
            }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            OnDead?.Invoke();
        }
        
    }

    private void JumpAction()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnJumpButton?.Invoke();
        }
    }
    private void JumpPrepare()
    {
        OnJumpPrepare?.Invoke();
    }

    private void GameStart()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnGameStart?.Invoke();
        }      
    }

    private void GameDifficulty()
    {
        GameManager.manager._obstacleController._model.gap -= (Time.deltaTime / 2f);
        if (GameManager.manager._obstacleController._model.gap <= 40f)
        {
            GameManager.manager._obstacleController._model.gap += (Time.deltaTime / 4f);
            if (GameManager.manager._obstacleController._model.gap <= 35f)
            {
                GameManager.manager._obstacleController._model.gap = 35f;
            }
        }
    }
}
