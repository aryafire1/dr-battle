using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RememberLastSelection : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject lastSelection;

    void Reset()
    {
        eventSystem = FindObjectOfType<EventSystem>();

        if (eventSystem == null)
        {
            Debug.Log("No Event System in scene");
            return;
        }

        lastSelection = eventSystem.firstSelectedGameObject;
    }

    void Update()
    {
        if (!eventSystem)
        {
            return;
        }

        if (eventSystem.currentSelectedGameObject && lastSelection != eventSystem.currentSelectedGameObject)
        {
            lastSelection = eventSystem.currentSelectedGameObject;
        }

        if (!eventSystem.currentSelectedGameObject && lastSelection)
        {
            eventSystem.SetSelectedGameObject(lastSelection);
        }
    }
}
