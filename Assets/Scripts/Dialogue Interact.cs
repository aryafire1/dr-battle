using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueInteract : MonoBehaviour
{
    public DialogueData[] sentences;
    public string animBoolTag;
    public TMP_Text text;
    public float typingSpeed;
    public GameObject npcTextBox;
    public Image npcSprite;

    [SerializeField]
    int index;
    public int Index { get {return index;} }
    Animator anim;

#region mono

    public virtual void Start() {
        text.text = "";
        StartText();
    }

#endregion

#region typing voids

    public virtual void StartText() {
        Player.main.mouseEvent.AddListener(TypeSkip);

        if (index != 0)
        {
            index = 0;
        }

        npcTextBox.SetActive(true);
        StartCoroutine(Typing());

        if (anim != null) {
        anim.SetBool(animBoolTag, true);
        }
    }

    IEnumerator Typing() {
        text.text = "";

            
            npcSprite.sprite = sentences[index].image;
        
        foreach(char letter in sentences[index].text) {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public virtual void TypeSkip() {

        if (text.text != sentences[index].text) {
            StopAllCoroutines();
            text.text = sentences[index].text;
        }
        else if (text.text == sentences[index].text) {
            if (index < sentences.Length - 1) {
                //moves to next chunk
                index++;
                StartCoroutine(Typing());
            }
            else {
                //dialogue ends here
                Reset();
            }
        }
    }

    public void Reset() {
        Player.main.mouseEvent.RemoveListener(TypeSkip);

        text.text = "";

        npcTextBox.SetActive(false);
        index = 0;

        if (anim != null) {
        anim.SetBool(animBoolTag, false);
        }
    }

#endregion

}
