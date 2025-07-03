using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class Player : MonoBehaviour
{
    public static Player main;
    public Transform soul;
    public float movementSpeed;
    public PlayerInput inputActions;
    public InputAction move, click;

    public UnityEvent mouseEvent;

    Vector2 soulStart;

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

        soulStart = soul.position;
    }

    void Click(InputAction.CallbackContext context)
    {
        mouseEvent?.Invoke();
    }

    void MoveSoul(bool b)
    {
        if (b == false)
        {
            soul.position = soulStart;
            move.Enable();
        }
        else
        {
            move.Disable();
        }
    }

    void Update()
    {
        //i hate you void update
        var v = move.ReadValue<Vector2>();
        if (v != Vector2.zero)
        {
            soul.Translate(movementSpeed * Time.deltaTime * v);
        }
    }
}
