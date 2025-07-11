using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSlider : MonoBehaviour
{
    public float sliderSpeed;
    public Slider sliderBar;
    public float target;

    void OnEnable()
    {
        sliderBar.value = 0.5f;
        StartCoroutine(SlideDown());
        if (Player.main != null)
        {
            Player.main.mouseEvent.AddListener(Callback);
        }
    }
    void OnDisable()
    {
        StopAllCoroutines();
        if (Player.main != null)
        {
            Player.main.mouseEvent.RemoveListener(Callback);
        }
    }

    IEnumerator SlideDown()
    {
        yield return new WaitForSeconds(sliderSpeed);
        sliderBar.value -= 0.01f;
        if (sliderBar.value > 0)
        {
            StartCoroutine(SlideDown());
        }
        else if (sliderBar.value <= 0)
        {
            Damage(sliderBar.value);
        }
    }

    void Callback()
    {
        Debug.Log("callback");
        StopAllCoroutines();
        Damage(sliderBar.value);
    }

    void Damage(float value)
    {
        GameManager.main.playerAnim.SetTrigger("attack");
        int damage = GameManager.main.player.attack;

        if (target < value + 0.011f && target > value - 0.011f)
        {
            damage = (int)(damage * ((1-value) * 10));
            Debug.Log($"crit: {damage}");
        }
        else if (value > target)
        {
            damage = (int)(damage * ((1 - value) * 8));
            Debug.Log($"hit high: {damage}");
        }
        else if (value < target)
        {
            Debug.Log($"hit low: {damage}");
        }

        GameManager.main.Event_EnemyDamage?.Invoke(damage);
        this.gameObject.SetActive(false);
    }
}
