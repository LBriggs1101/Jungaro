using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevel : MonoBehaviour
{

    private ChangeScene changeScene;
    public GameObject endTransition;
    public string newSceneName;
    public float waitTime = 1f;

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
            StartCoroutine(transitionStuff());
        }
    }

    private IEnumerator transitionStuff()
    {
        endTransition.SetActive(true);
        yield return new WaitForSecondsRealtime(waitTime);
        changeScene.changeScene(newSceneName);
    }
}
