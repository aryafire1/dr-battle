using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public GameObject playerHUD;
    public TurnData[] turnList;
    public TMP_Text flavorText;
    public int index = 0;

    void Awake()
    {
        if (playerHUD.activeSelf)
        {
            playerHUD.SetActive(false);
        }

        for (int i = 0; i <= turnList.Length - 1; ++i)
        {
            turnList[i].attack.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.main.Event_YourTurn.AddListener(PlayerTurn);
    }

    void PlayerTurn(bool b)
    {
        if (b)
        {
            playerHUD.SetActive(b);
            if (index >= turnList.Length)
            {
                index = 0;
            }
            flavorText.text = turnList[index].flavorText;
        }
        else if (b == false)
        {
            playerHUD.SetActive(b);
        }
    }
}
