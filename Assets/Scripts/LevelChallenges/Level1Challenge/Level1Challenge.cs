using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Challenge : LevelChallenge
{

    public bool collectedItem = false;

    public override bool beatChallengeValue()
    {
        return collectedItem;
    }

    public void collectTooth()
    {
        collectedItem = true;
    }
}
