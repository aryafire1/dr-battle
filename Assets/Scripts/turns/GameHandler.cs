using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public GameObject playerHUD, playerBox, soul;
    public TurnData[] phase1, phase2;
    public TMP_Text flavorText;
    public int index = 0;

    bool gameStart;
    Animator boxAnim;

    void Awake()
    {
        boxAnim = playerBox.GetComponent<Animator>();

        playerHUD.SetActive(false);
        playerBox.SetActive(false);
        soul.SetActive(false);

        for (int i = 0; i <= phase1.Length - 1; ++i)
        {
            phase1[i].attack.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.main.Event_YourTurn.AddListener(PlayerTurn);
        flavorText.text = phase1[0].flavorText;
    }

    void PlayerTurn(bool b)
    {
        if (b)
        {
            if (gameStart == false)
            {
                SetPlayerUI();
                gameStart = true;
                soul.SetActive(false);
            }
            else
            {
                GameManager.main.koviAnim.SetTrigger("escape");
                boxAnim.SetTrigger("turnDone"); //triggers setplayerui in anim event
                soul.SetActive(false);
            }
        }
        else if (b == false)
        {
            playerBox.SetActive(!b);
            soul.SetActive(!b);
            playerHUD.SetActive(b);

            //start attack
            GameManager.main.koviAnim.SetTrigger("attack");
            GameManager.main.playerAnim.SetTrigger("idle");

            //phases controlled in manager
            if (GameManager.main.phase1)
            {
                PhaseControl(phase1);
            }
            else if (GameManager.main.phase2)
            {
                PhaseControl(phase2);
            }
        }
    }

    public void SetPlayerUI()
    {
        playerBox.SetActive(false);
        playerHUD.SetActive(true);
    }

    void PhaseControl(TurnData[] phase)
    {
        flavorText.text = phase[index].flavorText;
        phase[index].attack.SetActive(true);
        if (index >= phase.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }
}
