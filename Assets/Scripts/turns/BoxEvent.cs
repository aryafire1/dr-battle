using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEvent : MonoBehaviour
{
    public GameHandler handler;

    public void Event()
    {
        handler.SetPlayerUI();
    }
}
