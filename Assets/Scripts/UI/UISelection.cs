using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISelection : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] Selectable selectable;

    void Reset()
    {
        eventSystem = FindObjectOfType<EventSystem>();

        if (eventSystem == null)
        {
            Debug.Log("No Event System in scene");
        }
    }

    void OnEnable()
    {
        SetSelection();
    }

    public void SetSelection()
    {
        if (eventSystem != null && selectable != null)
        {
            eventSystem.SetSelectedGameObject(selectable.gameObject);
        }
    }
}
