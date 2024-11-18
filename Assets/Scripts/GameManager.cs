using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    // inherited MonoSingleton. Don't static.
    // **if you're going to use Awake method, it would be to use 'override'** By Chamsol.

    public override void Awake()
    {
        base.Awake();
    }
}
