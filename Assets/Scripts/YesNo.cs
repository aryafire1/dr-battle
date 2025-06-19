using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNo : DialogueInteract
{
    [Header("Class Specific Variables")]
    public DialogueData[] yesData;
    public DialogueData[] noData, no2Data;
    DialogueData[] baseData;
    public GameObject choiceObject;
    bool yes, no, no2;

    public override void Start()
    {
        baseData = base.sentences;
        choiceObject.SetActive(false);
        base.Start();
    }

    public override void StartText()
    {
        base.StartText();
    }

    public override void TypeSkip()
    {
        choiceObject.SetActive(false);


        if (yes == false && base.text.text == base.sentences[base.Index].text)
        {
            if (base.Index >= base.sentences.Length - 1)
            {
                choiceObject.SetActive(true);
            }
        }
        if (yes && base.text.text == base.sentences[base.Index].text)
        {
            if (base.Index >= base.sentences.Length - 1)
            {
                base.sentences = baseData;
                yes = false;
                no = false;
                base.Reset();
                GameManager.main.Event_Open?.Invoke();
                return;
            }
        }

        base.TypeSkip();
    }

    //button ui voids
    public void Yes()
    {
        yes = true;
        base.sentences = yesData;
        choiceObject.SetActive(false);
        Invoke("StartText", 0.01f);
    }
    public void No()
    {
        if (no)
        {
            no2 = true;
        }
        no = true;
        if (no && no2)
        {
            base.sentences = no2Data;
        }
        else
        {
            base.sentences = noData;
        }
        choiceObject.SetActive(false);
        Invoke("StartText", 0.01f);
    }
}
