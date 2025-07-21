using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager main;

    public PlayerData player;
    public EnemyData enemy;
    public Slider playerHealthUI, enemyHealthUI;
    [SerializeField] float turnDelay;

    [HideInInspector] public UnityEvent Event_Open;
    [HideInInspector] public UnityEvent<bool> Event_YourTurn;
    [HideInInspector] public UnityEvent<float> Event_PlayerDamage, Event_EnemyDamage;
    [HideInInspector] public bool phase1, phase2;

    public Animator playerAnim, koviAnim;

    void Awake()
    {
        main = this;

        Event_Open = new UnityEvent();
        Event_YourTurn = new UnityEvent<bool>();
        Event_EnemyDamage = new UnityEvent<float>();
        Event_PlayerDamage = new UnityEvent<float>();

        Event_PlayerDamage.AddListener(PlayerDamage);
        Event_EnemyDamage.AddListener(EnemyDamage);

        phase1 = true;
        phase2 = false;
    }

    void Start()
    {
        playerHealthUI.maxValue = player.health;
        playerHealthUI.value = player.health;

        enemyHealthUI.maxValue = enemy.health;
        enemyHealthUI.value = enemy.health;
    }

    void PlayerDamage(float damage)
    {
        player.health -= (int)damage * enemy.attack;
        playerHealthUI.value = player.health; //ui update
    }
    void EnemyDamage(float damage)
    {
        enemy.health -= (int)damage;
        koviAnim.SetTrigger("hurt");
        enemyHealthUI.value = enemy.health; //ui update

        //percent check
        //make this trigger once....
        if (enemyHealthUI.value <= 300) //i love hardcoding!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            Debug.Log("bool swap");
            phase1 = false;
            phase2 = true;
        }

        StartCoroutine(TurnDelay());
    }

    IEnumerator TurnDelay()
    {
        yield return new WaitForSeconds(turnDelay);
        Event_YourTurn?.Invoke(false);
    }

}
