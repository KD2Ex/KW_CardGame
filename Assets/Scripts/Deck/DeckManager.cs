using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private CardData[] Deck;
    [SerializeField] private Card cardPrefab;

    [SerializeField] private List<Card> Cards = new();

    [SerializeField] private Transform Canvas;
    [SerializeField] private Transform[] HandPoints;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var cardData in Deck)
        {
            for (int i = 0; i < cardData.Number; i++)
            {
                var inst = Instantiate(cardPrefab, Canvas);
                inst.gameObject.SetActive(false);
                inst.data = cardData;
                Cards.Add(inst);
            }
        }
        
        InitialDraw();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialDraw()
    {
        for (int i = 0; i < 4; i++)
        {
            var index = Random.Range(0, Cards.Count);
            var card = Cards[index];
            Cards.Remove(card);

            card.transform.position = HandPoints[i].position;
            card.gameObject.SetActive(true);
            
            
        }
    }
}
