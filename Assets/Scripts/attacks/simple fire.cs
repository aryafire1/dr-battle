using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplefire : AttackParent
{
    public float bottom, top, frequency;
    public List<GameObject> bullets = new List<GameObject>();
    int index;

    void OnEnable()
    {
        base.OnEnable();

        index = 0;
        foreach (GameObject g in bullets)
        {
            g.SetActive(false);
        }
        StartCoroutine(Fire());
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Fire()
    {
        bullets[index].SetActive(true);
        bullets[index].transform.position = new Vector2(selfRef.transform.position.x, Random.Range(bottom, top));
        bullets[index].GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
        if (index >= bullets.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        yield return new WaitForSeconds(frequency);
        StartCoroutine(Fire());
    }

}
