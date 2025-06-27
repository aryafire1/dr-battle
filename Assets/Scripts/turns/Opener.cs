using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : MonoBehaviour
{
    public GameObject[] objectsToActivate;

    void Awake()
    {
        for (int i = 0; i <= objectsToActivate.Length - 1; ++i)
        {
            if (objectsToActivate[i].activeSelf)
            {
                objectsToActivate[i].SetActive(false);
            }
        }
    }
    void Start()
    {
        GameManager.main.Event_Open.AddListener(Callback);
    }

    void Callback()
    {
        for (int i = 0; i <= objectsToActivate.Length - 1; ++i)
        {
            objectsToActivate[i].SetActive(true);
        }
        
        GameManager.main.Event_YourTurn?.Invoke(true);
    }
}
