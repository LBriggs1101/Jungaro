using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/Levels/MainLevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public string levelName;
    public string bonusChallangeDesc;
    public bool bonusChallengeComplete;
    public bool beatNoDeath;
    public bool beatLevel;
    public int coinCount;
}
