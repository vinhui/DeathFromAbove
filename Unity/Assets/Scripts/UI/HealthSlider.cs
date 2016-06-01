using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSlider : MonoBehaviour
{
    public Health healthComponent;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        slider.maxValue = healthComponent.maxHealth;
        slider.minValue = 0;
        slider.value = healthComponent.health;

        healthComponent.onHealthChanged.AddListener(HealthChanged);
    }

    public void HealthChanged(int amount)
    {
        slider.value = healthComponent.health;
    }
}