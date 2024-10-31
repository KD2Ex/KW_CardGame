using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData data;
    [SerializeField] private TextMeshProUGUI healthUI;
    [SerializeField] private TextMeshProUGUI damageUI;
    [SerializeField] private TextMeshProUGUI nameUI;

    private void Awake()
    {
        healthUI.text = data.Health.ToString();
        damageUI.text = data.Damage.ToString();
        nameUI.text = data.Name;
    }

    public void PlacedOnDesk(int slot)
    {
        GameManager.instance.AddCardOnDesk(this, slot);
        GameManager.instance.Turn();
    }
}