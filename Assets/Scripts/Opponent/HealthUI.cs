using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void SetValue(int value)
    {
        text.text = value.ToString();
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
