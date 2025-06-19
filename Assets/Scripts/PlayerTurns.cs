using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurns : MonoBehaviour
{
    public GameObject flavorText, actionButtons, fightAction, magicOption;

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
    }
    public void MagicSelect()
    {
        flavorText.SetActive(false);
        actionButtons.SetActive(false);
        magicOption.SetActive(true);
    }
}
