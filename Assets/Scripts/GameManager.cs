using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoSingleton<GameManager>
{
    // inherited MonoSingleton. Don't static.
    // **if you're going to use Awake method, it would be to use 'override'** By Chamsol.

    private bool _isGamePlaying = true;
    
    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        
    }

    public void PauseGame()
    {
        if (_isGamePlaying)
        {
            Time.timeScale = 0;
            _isGamePlaying = false;
            // todo: Pop up the pauseUI that used UIManager.
        }
        else
        {
            Time.timeScale = 1;
            _isGamePlaying = true;
            // todo: Close the pauseUI
        }
    }
}
