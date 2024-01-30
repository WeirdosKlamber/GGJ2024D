using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardHolder : MonoBehaviour
{
    public Card cardSO;
    [SerializeField] private GameObject image;
    [SerializeField] private Material[] cardArt;

    private void Start()
    {
        AssignCard();

        Renderer rend = image.GetComponent<Renderer>();
        rend.materials = cardSO.cardArt;
        
        Debug.Log("Card is: " + cardSO);
    }

    private void AssignCard()
    {
        GameObject main = GameObject.Find("Main");
        CombatManager manager = main.GetComponent<CombatManager>();

        cardSO = manager.playerDeck[0];
        manager.playerDeck.RemoveAt(0);
    }
}
