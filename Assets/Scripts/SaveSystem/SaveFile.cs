using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveFile : MonoBehaviour
{

    public LevelData level1;
    public LevelData level2;
    public LevelData level3;
    public LevelData level4;
    public LevelData level5;
    public LevelData secretLevel;

    private string directory;

    public void save(int fileNumber)
    {
        if(fileNumber == 1)
        {
            directory = Application.dataPath + "/SaveFolder/Save.txt";
        }
        else if(fileNumber == 2)
        {
            directory = Application.dataPath + "/SaveFolder/Save2.txt";
        }

        File.WriteAllText(directory, 
        
        level1.bonusChallengeComplete + "\n" +
        level1.beatNoDeath + "\n" +
        level1.beatLevel + "\n" +
        level1.coinCount + "\n" +

        level2.bonusChallengeComplete + "\n" +
        level2.beatNoDeath + "\n" +
        level2.beatLevel + "\n" +
        level2.coinCount + "\n" +

        level3.bonusChallengeComplete + "\n" +
        level3.beatNoDeath + "\n" +
        level3.beatLevel + "\n" +
        level3.coinCount + "\n" +

        level4.bonusChallengeComplete + "\n" +
        level4.beatNoDeath + "\n" +
        level4.beatLevel + "\n" +
        level4.coinCount + "\n" +

        level5.bonusChallengeComplete + "\n" +
        level5.beatNoDeath + "\n" +
        level5.beatLevel + "\n" +
        level5.coinCount + "\n" +

        secretLevel.bonusChallengeComplete + "\n" +
        secretLevel.beatNoDeath + "\n" +
        secretLevel.beatLevel + "\n" +
        secretLevel.coinCount + "\n"
        );
    }

    public void load(int fileNumber)
    {
        string[] fileText = loadFile(fileNumber);

        level1.bonusChallengeComplete = bool.Parse(fileText[0]); 
        level1.beatNoDeath = bool.Parse(fileText[1]); 
        level1.beatLevel = bool.Parse(fileText[2]); 
        level1.coinCount = int.Parse(fileText[3]);

        level2.bonusChallengeComplete = bool.Parse(fileText[4]); 
        level2.beatNoDeath = bool.Parse(fileText[5]); 
        level2.beatLevel = bool.Parse(fileText[6]); 
        level2.coinCount = int.Parse(fileText[7]);

        level3.bonusChallengeComplete = bool.Parse(fileText[8]); 
        level3.beatNoDeath = bool.Parse(fileText[9]); 
        level3.beatLevel = bool.Parse(fileText[10]); 
        level3.coinCount = int.Parse(fileText[11]);

        level4.bonusChallengeComplete = bool.Parse(fileText[12]); 
        level4.beatNoDeath = bool.Parse(fileText[13]); 
        level4.beatLevel = bool.Parse(fileText[14]); 
        level4.coinCount = int.Parse(fileText[15]);

        level5.bonusChallengeComplete = bool.Parse(fileText[16]); 
        level5.beatNoDeath = bool.Parse(fileText[17]); 
        level5.beatLevel = bool.Parse(fileText[18]); 
        level5.coinCount = int.Parse(fileText[19]);

        secretLevel.bonusChallengeComplete = bool.Parse(fileText[20]); 
        secretLevel.beatNoDeath = bool.Parse(fileText[21]); 
        secretLevel.beatLevel = bool.Parse(fileText[22]); 
        secretLevel.coinCount = int.Parse(fileText[23]);
    }

    public string[] loadFile(int fileNumber)
    {

        if(fileNumber == 1)
        {
            directory = Application.dataPath + "/SaveFolder/Save.txt";
        }
        else if(fileNumber == 2)
        {
            directory = Application.dataPath + "/SaveFolder/Save2.txt";
        }

        Debug.Log(directory);
        StreamReader reader = new StreamReader(directory);
        
        Debug.Log(reader);
        string text = reader.ReadToEnd();

        reader.Close();

        string[] lines = text.Split('\n');

        return lines;
    }

    public void deleteFile(int fileNumber)
    {
        if(fileNumber == 1)
        {
            directory = Application.dataPath + "/SaveFolder/Save.txt";
        }
        else if(fileNumber == 2)
        {
            directory = Application.dataPath + "/SaveFolder/Save2.txt";
        }

        File.WriteAllText(directory, string.Empty);
    }
}
