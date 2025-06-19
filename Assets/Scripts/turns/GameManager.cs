using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager main;

    [HideInInspector] public UnityEvent Event_Open;
    [HideInInspector] public UnityEvent<bool> Event_YourTurn;

    void Awake()
    {
        main = this;

        Event_Open = new UnityEvent();
        Event_YourTurn = new UnityEvent<bool>();
    }

    public void Temp()
    {
        Event_YourTurn?.Invoke(false);
        Debug.Log("temp test");
    }

}
