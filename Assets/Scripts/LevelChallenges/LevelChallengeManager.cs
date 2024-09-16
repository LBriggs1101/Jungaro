using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChallengeManager : MonoBehaviour
{

    [SerializeField] public LevelChallenge thisLevelChallenge;

    void Start()
    {
        Debug.Log(thisLevelChallenge.beatChallengeValue());
    }

    public bool returnChallengeComplete()
    {
        Debug.Log(thisLevelChallenge.beatChallengeValue());
        return thisLevelChallenge.beatChallengeValue();
    }
}
