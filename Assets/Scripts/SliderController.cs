using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public ConveyorBeltAnimation[] beltAnimations;
    public ConveyorBeltLarge[] beltMovements;
    public Slider slider;

    private void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        for (int i = 0; i < beltAnimations.Length; i++)
        {
            beltAnimations[i].scrollSpeed = value;
        }
        for (int i = 0; i < beltMovements.Length; i++)
        {
            beltMovements[i].conveyorSpeed = value;
        }
    }
}




