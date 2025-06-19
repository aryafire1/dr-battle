using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplefire : AttackParent
{
    public float bottom, top, frequency;
    List<GameObject> bullets = new List<GameObject>();

    void Start()
    {
        GameManager.main.Event_YourTurn.AddListener(Callback);
    }

    void Callback(bool b)
    {
        //stops turn
        if (b)
        {
            StopAllCoroutines();
            foreach (GameObject g in bullets)
            {
                Destroy(g);
            }
            bullets.Clear();
        }

        //starts turn
        else if (b == false)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        bullets.Add(Instantiate(selfRef, new Vector3(selfRef.transform.position.x, Random.Range(bottom, top), selfRef.transform.position.z), Quaternion.identity));
        yield return new WaitForSeconds(frequency);
        StartCoroutine(Fire());
    }

}
