using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackParent : MonoBehaviour
{
    public int attackLength;
    public float bulletSpeed, damage;

    [HideInInspector] public GameObject selfRef;

    void Awake()
    {
        selfRef = this.gameObject;
        
    }

    protected void OnEnable()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(attackLength);
        GameManager.main.Event_YourTurn?.Invoke(true);
        selfRef.SetActive(false);
    }
}
