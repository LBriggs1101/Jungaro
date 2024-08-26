using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvasGroup : MonoBehaviour
{

    private bool isFaded = false;

    public float Duration = 0.4f;

    public void Fade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        StartCoroutine(DoFade(canvasGroup, canvasGroup.alpha, isFaded ? 1 : 0));

        isFaded = !isFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }
    }
}
