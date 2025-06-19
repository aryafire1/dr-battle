using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseData : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [HideInInspector] public int health;
    public int attack;

    void Awake()
    {
        health = maxHealth;
    }
}
