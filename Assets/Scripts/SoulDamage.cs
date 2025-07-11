using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<AttackData>(out AttackData attack))
        {
            GameManager.main.Event_PlayerDamage?.Invoke(attack.damage);
        }
    }
    
    //make iframe stuff over here
}
