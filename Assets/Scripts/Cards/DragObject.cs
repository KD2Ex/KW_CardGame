using UnityEngine;

[RequireComponent(typeof(Card))]
public class DragObject : MonoBehaviour
{
    private bool inSlot;
    private bool dragging;
    
    private Transform slot;
    private int slotNumber;

    private Vector3 origin;

    private Card card;
    
    private void Awake()
    {
        card = GetComponent<Card>();
    }

    void Update()
    {
        if (!dragging) return;

        transform.position = Input.mousePosition;
    }

    public void StartDrag()
    {
        if (inSlot) return;
        if (!GameManager.instance.PlayerTurn) return;
        
        dragging = true;
        origin = transform.position;
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
    }

    public void EndDrag()
    {
        if (!GameManager.instance.PlayerTurn) return;
        
        dragging = false;
        if (slot)
        {
            inSlot = true;
            transform.position = slot.position;
            
            card.PlacedOnDesk(slotNumber);
        }
        else
        {
            transform.position = origin;
        }
    }

    public void OverSlot(Transform slot, int number)
    {
        this.slot = slot;
        slotNumber = number;
    }

    public void ExitSlot()
    {
        slot = null;
        slotNumber = -1;
    }
}
