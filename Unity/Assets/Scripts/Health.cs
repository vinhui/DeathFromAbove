using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;

    private int _health;

    public int health
    {
        get { return _health; }
        set
        {
            int changed = _health - value;
            _health = Mathf.Min(value, maxHealth);
            _health = Mathf.Max(_health, 0);
            if (onHealthChanged != null)
                onHealthChanged.Invoke(changed);

            if (_health == 0 && onDied != null)
                onDied.Invoke();
        }
    }

    public HealthChangedEvent onHealthChanged;
    public DiedEvent onDied;

    public void Awake()
    {
        health = maxHealth;
    }

    [System.Serializable]
    public class HealthChangedEvent : UnityEvent<int> { }
    [System.Serializable]
    public class DiedEvent : UnityEvent { }
}