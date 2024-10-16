using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInThanks : MonoBehaviour
{

    public FadeCanvasGroup fadeCanvasGroup;

    public void fadeThanks()
    {
        fadeCanvasGroup.Fade();
    }
}
