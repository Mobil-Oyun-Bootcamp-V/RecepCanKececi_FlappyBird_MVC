using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController
{
    public ObstacleModel _model;
    private ObstacleView _view;
    private Vector2 spawnPosTop;
    private Vector2 spawnPosBot;

    public ObstacleController(ObstacleView view)
    {
        _model = new ObstacleModel();

        _view = view;
        _view.OnMove += ObstacleMove;
        _view.OnGenerate += ObstacleGenerator;
    }

    private void ObstacleMove()
    {
        _view.gameObject.transform.Translate(Vector2.left * _view.obstacleSpeed);
    }

    private void ObstacleGenerator()
    {
        
    }
}
