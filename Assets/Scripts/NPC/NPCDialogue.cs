using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public List<string> dialogue;
    public List<int> delay;
    public List<Sprite> visual;

    public TMP_Text txt;
    public SpriteRenderer sr;
    int current_dialogue;

    void Awake()
    {
        StartCoroutine(Next(delay[current_dialogue]));
    }

    void Update()
    {
        txt.text = dialogue[current_dialogue];
        sr.sprite = visual[current_dialogue];
    }

    IEnumerator Next(int d)
    {
        yield return new WaitForSeconds(d);
        current_dialogue += 1;
        if(current_dialogue < (dialogue.Count -1)) StartCoroutine(Next(delay[current_dialogue]));
    }
}
