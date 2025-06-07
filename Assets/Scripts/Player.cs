using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player main;

    public UnityEvent mouseEvent;

    void Awake()
    {
        main = this;
        mouseEvent = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseEvent?.Invoke();
        }
    }
}
