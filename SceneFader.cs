using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;
    //makes the scene fade in and fade out when loading
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            // while t is larger than 0 decrease it by time. when it reaches zero the scene is loaded.
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            // skip to the next frame
            yield return 0;
        }
    }
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t > 1f)
        {
            // while t is larger than 0 decrease it by time. when it reaches zero the scene is loaded.
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            // skip to the next frame
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}
