using UnityEngine;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    public Material fadeMaterial;
    public float fadeDuration = 0.5f;

    private Coroutine currentFade;

    public void Start()
    {
        StartFade(0f);
    }

    public void FadeIn() // fade to visible (death)
    {
        StartFade(1f);
    }

    public void FadeOut() // fade back to transparent (respawn)
    {
        StartFade(0f);
    }

    void StartFade(float targetAlpha)
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(FadeRoutine(targetAlpha));
    }

    IEnumerator FadeRoutine(float targetAlpha)
    {
        float startAlpha = fadeMaterial.color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);

            Color color = fadeMaterial.color;
            color.a = alpha;
            fadeMaterial.color = color;

            yield return null;
        }

        Color finalColor = fadeMaterial.color;
        finalColor.a = targetAlpha;
        fadeMaterial.color = finalColor;
    }
}