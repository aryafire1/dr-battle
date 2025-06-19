using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurns : MonoBehaviour
{
    public GameObject flavorText, actionButtons, fightAction, magicOption;
    public UISelection hudReset, magicUI;

    //turn reset whenever it's beginning of turn
    void OnEnable()
    {
        flavorText.SetActive(true);
        actionButtons.SetActive(true);
        fightAction.SetActive(false);
        magicOption.SetActive(false);
    }

    //button voids
    public void Fight()
    {
        flavorText.SetActive(false);
        actionButtons.SetActive(false);
        fightAction.SetActive(true);

        hudReset.SetSelection();
    }
    public void MagicSelect()
    {
        flavorText.SetActive(false);
        actionButtons.SetActive(false);
        magicOption.SetActive(true);

        magicUI.SetSelection();
    }
}
