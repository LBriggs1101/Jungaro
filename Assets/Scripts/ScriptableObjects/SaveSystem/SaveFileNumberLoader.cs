using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveFileNumberLoader", menuName = "ScriptableObjects/SaveData/SaveFileNumberLoader", order = 1)]
public class SaveFileNumberLoader : ScriptableObject
{
    public int currentSaveFileNumber;
}
