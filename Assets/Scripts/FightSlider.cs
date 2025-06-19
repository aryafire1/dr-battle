using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSlider : MonoBehaviour
{
    public float sliderSpeed;
    public Slider sliderBar;

    void OnEnable()
    {
        sliderBar.value = 0.5f;
        StartCoroutine(SlideDown());
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SlideDown()
    {
        yield return new WaitForSeconds(sliderSpeed);
        sliderBar.value -= 0.01f;
        if (sliderBar.value > 0)
        {
            StartCoroutine(SlideDown());
        }
    }
}
