using UnityEngine;
using System.Collections;

public class Animgrabber : MonoBehaviour {
    
    Animator animator;
    public PlayerMovementGrappling MG;
    public GameObject PlayerObj;
    
    // Use this for initialization
    void Start () {
        animator = PlayerObj.GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () {

        if (MG.onthemove == 3)
        {
            animator.SetInteger("AnimState", 3);
        }
        else if (MG.onthemove == 2)
        {
            animator.SetInteger("AnimState", 2);
        }
        else if (MG.onthemove == 1)
        {
            animator.SetInteger("AnimState", 1);
        }
        else 
        {
            animator.SetInteger("AnimState", 0);
        }
    }
}