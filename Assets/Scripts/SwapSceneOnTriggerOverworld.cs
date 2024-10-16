using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSceneOnTriggerOverworld : MonoBehaviour
{

    public string newScene;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("SceneLoadManager").GetComponent<ChangeScene>().changeScene(newScene);
        }
    }
}
