using System.Collections;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public float transitionDelay;
    public AnimationClip start;
    public AnimationClip end;
    public GameObject img;
    string nextScene;

    public void StartAnimation(string scene)
    {
        img.SetActive(true);
        GetComponent<Animation>().clip = start;
        GetComponent<Animation>().Play();
        nextScene = scene;
        StartCoroutine(EndAnimation());
    }

    IEnumerator EndAnimation()
    {
        yield return new WaitForSeconds(transitionDelay);
        GetComponent<_SceneManager>().Change_Scene(nextScene);
        GetComponent<Animation>().clip = end;
        GetComponent<Animation>().Play();
        yield return new WaitForSeconds(transitionDelay);
        img.SetActive(false);
    }
}
