using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class Player : MonoBehaviour
{
    public static Player main;
    public PlayerInput inputActions;
    public InputAction move, click;

    public UnityEvent mouseEvent;

    void Awake()
    {
        main = this;
        mouseEvent = new UnityEvent();
        inputActions = new PlayerInput();
    }
    void Start()
    {
        move = inputActions.Soul.Move;
        click = inputActions.Soul.Click;
        GameManager.main.Event_YourTurn.AddListener(MoveSoul);

        click.Enable();
        click.performed += Click;
    }

    void Click(InputAction.CallbackContext context)
    {
        mouseEvent?.Invoke();
    }

    void MoveSoul(bool b)
    {
        if (b == false)
        {
            move.Enable();
        }
        else
        {
            move.Disable();
        }
    }
}
