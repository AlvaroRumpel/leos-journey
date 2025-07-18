using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fill;

    public void SetHealth(float current, float max)
    {
        fill.fillAmount = current / max;
    }

    private void Start()
    {
        SetHealth(100, 100);
    }
}
