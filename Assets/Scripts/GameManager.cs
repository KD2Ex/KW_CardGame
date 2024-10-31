using System.Collections.Generic;
using Colyseus;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerType
{
    PLAYER,
    OPPONENT
}

[System.Serializable]
public struct CardOnDesk
{
    public Card Card;
    public int Slot;

    public CardOnDesk(Card card, int slot)
    {
        Card = card;
        Slot = slot;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player Opponent;
    public List<CardOnDesk> PlayerCards;

    public bool PlayerTurn { get; private set; } = true;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            Turn();
        }
    }

    public void DrawPlayer()
    {
        
    }

    public void DrawOpponent()
    {
        
    }

    public void Drop()
    {
        
    }

    public void Turn()
    {
        Attack();
        
        PlayerTurn = !PlayerTurn;
        // opponents turn
    }

    private void Attack()
    {
        foreach (var playerCard in PlayerCards)
        {
            Opponent.TakeDamage(playerCard.Card.data.Damage);
        }
    }

    public void AddCardOnDesk(Card card, int slot)
    {
        PlayerCards.Add(new CardOnDesk(card, slot));
    }
}
