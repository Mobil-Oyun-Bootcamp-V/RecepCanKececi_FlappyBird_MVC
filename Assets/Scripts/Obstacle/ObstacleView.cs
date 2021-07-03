using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleView : MonoBehaviour
{
    public UnityAction OnMove;
    public UnityAction OnScore;
    public UnityAction OnGenerate;
    public float obstacleSpeed;

    private void Update() 
    {   
        switch (GameManager.manager.CurrentGameState)
        {
            case GameManager.GameState.Prepare:
                break;
            case GameManager.GameState.MainGame:
                ObstacleMove();
                break;
            case GameManager.GameState.FinishGame:
                break;
        }
    }

    public void ObstacleMove()
    {
        obstacleSpeed = GameManager.manager._obstacleController._model.speed * Time.deltaTime;
        //OnMove?.Invoke();
        transform.Translate(Vector2.left * obstacleSpeed);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Trigger"))
        {
            UIController.Instance.ScoreUpdate();

            Vector2 spawnPosTop = new Vector2(GameManager.manager._obstacleController._model.posX, Random.Range(GameManager.manager._obstacleController._model.topPosMinY, 
            GameManager.manager._obstacleController._model.topPosMaxY));
            Vector2 spawnPosBot = new Vector2(GameManager.manager._obstacleController._model.posX, spawnPosTop.y - GameManager.manager._obstacleController._model.gap);
            ObjectPooler.Instance.SpawnFromPool("Obstacle", spawnPosTop, Quaternion.identity);
            ObjectPooler.Instance.SpawnFromPool("Obstacle", spawnPosBot, Quaternion.identity * Quaternion.Euler(180,0,0));
        }     
    }
}
