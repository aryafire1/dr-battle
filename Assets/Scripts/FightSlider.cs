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
        if (target < value + 0.01f && target > value - 0.01f)
        {
            Debug.Log("crit");
        }
        else if (value > target)
        {
            Debug.Log("hit high");
        }
        else if (value < target)
        {
            Debug.Log("hit low");
        }
    }
}
