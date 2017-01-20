﻿using System;
using UnityEngine;
using TinyRoar.Framework;

public class MatchManager : Singleton<MatchManager>
{
    public void Init()
    {
        Events.Instance.OnGameplayStatusChange += GameplayStatusChange;
    }

    void GameplayStatusChange(GameplayStatus oldMatchStatus, GameplayStatus newMatchStatus)
    {

        switch (newMatchStatus)
        {
            case GameplayStatus.MatchStart:

                // Start Timer
                GameplayTimer.Instance.Enable();

                // TODO Spawn Players

                break;
            case GameplayStatus.MatchStop:

                // Stop Timer
                GameplayTimer.Instance.Disable();

                // TODO Disable or Destroy Players
                break;
        }

    }


}
