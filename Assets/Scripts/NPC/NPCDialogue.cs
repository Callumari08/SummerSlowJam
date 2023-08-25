using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public TMP_Text txt;
    public SpriteRenderer sr;
    public SpriteRenderer faceEyes;
    public SpriteRenderer faceMouth;

    [System.Serializable]
    public struct startDialogue
    {
        public List<string> dialogue;
        public List<Sprite> visual;
        public List<int> delay;
        public List<Sprite> eyes;
        public List<Sprite> mouth;
    }

    [System.Serializable]
    public struct endDialogue
    {
        public string dialogue;
        public Sprite visual;
    }

    public startDialogue _startDialogue;
    public endDialogue _endDialogue;

    void Awake() => StartCoroutine(NextStart());

    IEnumerator NextStart()
    {
        for(int i = 0; i < _startDialogue.visual.Count; i++)
        {
            sr.sprite = _startDialogue.visual[i];
        }

        for(int i = 0; i < _startDialogue.dialogue.Count; i++)
        {
            txt.text = _startDialogue.dialogue[i];
            yield return new WaitForSeconds(_startDialogue.delay[i]);

            for(int o = 0; o < _startDialogue.eyes.Count; o++)
            {
                faceEyes.sprite = _startDialogue.eyes[o];
            }

            for(int o = 0; o < _startDialogue.mouth.Count; o++)
            {
                faceMouth.sprite = _startDialogue.mouth[o];
            }
        }
    }

    public void NextEnd()
    {
        txt.text = _endDialogue.dialogue;
        sr.sprite = _endDialogue.visual;
    }
}
