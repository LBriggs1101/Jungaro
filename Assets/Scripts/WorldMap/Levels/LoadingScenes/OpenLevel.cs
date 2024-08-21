using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevel : MonoBehaviour
{

    private ChangeScene changeScene;
    public string newSceneName;

    // Start is called before the first frame update
    void Start()
    {
        changeScene = GameObject.Find("SceneLoadManager").GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            changeScene.changeScene(newSceneName);
        }
    }
}
