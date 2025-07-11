using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData : MonoBehaviour
{
    [HideInInspector] public float damage;

    void Awake()
    {
        if (transform.parent.gameObject.TryGetComponent<AttackParent>(out AttackParent parent))
        {
            damage = parent.damage;
        }
    }
}
