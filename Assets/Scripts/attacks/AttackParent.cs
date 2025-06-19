using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackParent : MonoBehaviour
{
    public int attackLength;

    [HideInInspector]
    public GameObject selfRef;

    void Awake()
    {
        selfRef = this.gameObject;
    }

    void Start()
    {
        GameManager.main.Event_YourTurn.AddListener(Callback);
    }

    void Callback(bool b)
    {
        //activated by false yourturn callback
        if (b == false)
        {
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(attackLength);
        GameManager.main.Event_YourTurn?.Invoke(true);
    }
}
