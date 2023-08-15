using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public List<string> startDialogue;
    public string endDialogue;
    public List<int> delay;
    public List<Sprite> visual;

    public TMP_Text txt;
    public SpriteRenderer sr;

    void Awake() { StartCoroutine(NextStart()); }

    IEnumerator NextStart()
    {
        for(int i = 0; i < startDialogue.Count; i++)
        {
            txt.text = startDialogue[i];
            sr.sprite = visual[i];
            yield return new WaitForSeconds(delay[i]);
        }
    }

    public void NextEnd()
    {
        txt.text = endDialogue;
        sr.sprite = visual[0];
    }
}
