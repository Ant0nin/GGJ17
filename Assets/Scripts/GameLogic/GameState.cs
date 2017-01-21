using UnityEngine;
using System.Collections;

public class GameState
{
    private GameState()
    {
        // TODO : init
    }

    public static GameState instance;
    public static GameState getInstance()
    {
        if (instance == null)
            instance = new GameState();
        return instance;
    }
}
