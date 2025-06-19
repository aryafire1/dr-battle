using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle : MonoBehaviour
{
    Selectable self;

    void Awake()
    {
        if (TryGetComponent<Selectable>(out Selectable s))
        {
            self = s;
        }

        self.interactable = false;
    }

    void OnEnable()
    {
        self.interactable = true;
    }

    void OnDisable()
    {
        self.interactable = false;
    }

}
