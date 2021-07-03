using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    // PlayerController listens view events and controls the player according to these events
    private PlayerModel _model;
    private PlayerView _view;

    public PlayerController(PlayerView view)
    {
        _model = new PlayerModel();


        _view = view;
        _view.OnJumpButton += Jump;
        _view.OnJumpPrepare += JumpPreparePC;
    }

    private void Jump()
    {
        _view.playerRb.velocity = (_model.jumpVector * _model.jumpPower);
    }
    private void JumpPreparePC()
    {
        _view.isKinem = false;
        _view.playerRb.isKinematic = false;
    }
}
