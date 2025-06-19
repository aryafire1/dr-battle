using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager main;

    public PlayerData player;
    public EnemyData enemy;

    [HideInInspector] public UnityEvent Event_Open;
    [HideInInspector] public UnityEvent<bool> Event_YourTurn;
    [HideInInspector] public UnityEvent<float> Event_PlayerDamage, Event_EnemyDamage;

    public Animator playerAnim, koviAnim;

    void Awake()
    {
        main = this;

        Event_Open = new UnityEvent();
        Event_YourTurn = new UnityEvent<bool>();

        Event_PlayerDamage.AddListener(PlayerDamage);
        Event_EnemyDamage.AddListener(EnemyDamage);
    }

    void PlayerDamage(float damage)
    {
        player.health -= (int)damage;
        //update ui
    }
    void EnemyDamage(float damage)
    {
        enemy.health -= (int)damage;
        //update ui
    }

}
