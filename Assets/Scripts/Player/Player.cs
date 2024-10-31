using System.Collections;
using System.Collections.Generic;
using Colyseus;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;

    public UnityEvent<int> OnTakeDamage;
    
    public int Health => health;

    public void TakeDamage(int value)
    {
        health -= value;
        OnTakeDamage?.Invoke(health);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
