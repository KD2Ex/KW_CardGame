using UnityEngine;

public class CardSlot : MonoBehaviour
{
    [SerializeField] private int number;
    
    private DragObject card;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Card")) return;
        
        Debug.Log(other.gameObject.name);

        card = other.GetComponent<DragObject>();
        card.OverSlot(transform, number);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Card")) return;
        Debug.Log("Exit");

        card.ExitSlot();
        card = null;
    }
}
