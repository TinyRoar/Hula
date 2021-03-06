﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour {

    public GameObject WaveParticlesPrefab;

    public Transform LeftFootTransform;
    public Transform RightFootTransform;

    public bool menu = false;
    public float addHeight = 0;

    private Vector3 spawnPos = Vector3.zero;

    public void LeftFoot ()
    {
        spawnPos = LeftFootTransform.position;
        spawnPos.y = 0;
        spawnPos.y += addHeight;

        DoStep();

        if (menu)
            return;

        this.transform.parent.GetComponent<Player>().TrySetValueToSkill<Movement>(4);

    }

    public void RightFoot()
    {
        spawnPos = RightFootTransform.position;
        spawnPos.y = 0;
        spawnPos.y += addHeight;

        DoStep();

        if (menu)
            return;

        this.transform.parent.GetComponent<Player>().TrySetValueToSkill<Movement>(5);

    }

    private void DoStep()
    {
        bool stepAllowed = true;

        if (!menu)
        {
            // if player 2 && visible >= 0.5
            float invisibleVal = this.transform.parent.GetComponent<Player>().TryGetValueFromSkill<Invisibility>(0);

            if (invisibleVal != -1)
            {
                if (invisibleVal <= 0.5)
                {
                    stepAllowed = false;
                }
            }
        }

        if (stepAllowed)
            Instantiate(WaveParticlesPrefab, spawnPos, Quaternion.identity);
    }

}
