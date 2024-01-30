using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    ///3 phases
    ///prepare (draw cards)
    ///play (place cards)
    ///attack (read card values)

    /*
    [Header("Table Grid")]
    [SerializeField] private GameObject columnLeft;
    [SerializeField] private GameObject columnMiddle;
    [SerializeField] private GameObject columnRight;
    */

    [Header("Cards")]
    [SerializeField] private CardLibrary cardLibrary;
    [SerializeField] private GameObject cardObject;
    [SerializeField] private Transform playerHandTrans;
    [SerializeField] private PlayerCombat combat;
    public List<Card> playerDeck;
    public List<GameObject> playerHand;
    private GameObject tempItem;
    public GameObject HAND1;
    public GameObject HAND1DOWN;

    public GameObject HAND2;
    public GameObject HAND2DOWN;

    public GameObject Counter1;
    public GameObject Counter2;
    public GameObject Counter3;

    public GameObject King;
    public GameObject Jester;
    public GameObject Monk;


    private void Start()
    {
        ///Find how many cards are in the deck
        ///Randomly generate which cards to pull

        playerDeck = cardLibrary.cards;

        Debug.Log("Your deck is " + playerDeck.Count + " cards long.");

        StartMatch();
    }


    // Update is called once per frame
    void Update()
    {
        //DEMO KEYS
        if (Input.GetKey("1"))
        {
            HAND1.SetActive(true);

        }
        if (Input.GetKey("2"))
        {
            HAND1.SetActive(false);
            HAND1DOWN.SetActive(true);

        }
        if (Input.GetKey("3"))
        {
            Counter1.SetActive(true);
            Counter2.SetActive(true);
            Counter3.SetActive(true);

            Counter1.SendMessage("PickUp");
            Counter2.SendMessage("PickUp");
            Counter3.SendMessage("PickUp");

        }
        if (Input.GetKey("4"))
        {
            King.SendMessage("Sad");
            Monk.SendMessage("Sick");
            Jester.SendMessage("Laugh");

        }
        if (Input.GetKey("5"))
        {
            HAND2.SetActive(true);
            HAND1DOWN.SetActive(false);

        }
        if (Input.GetKey("6"))
        {
            HAND2.SetActive(false);
            HAND2DOWN.SetActive(true);

        }
        if (Input.GetKey("7"))
        {
            Counter1.SendMessage("PickUp");
            Counter2.SendMessage("PickUp");
            Counter3.SendMessage("PickUp");

        }
        if (Input.GetKey("8"))
        {
            King.SendMessage("Shocked");
            Monk.SendMessage("Sad");
            Jester.SendMessage("Win");

        }


    }


        private void StartMatch()
    {
        Invoke("DrawCard", 0.2f);
        Invoke("DrawCard", 0.6f);
        Invoke("DrawCard", 1f);
    }

    private void DrawCard()
    {
        GameObject go;
        go = Instantiate(cardObject, transform.position, transform.rotation) as GameObject;
        //go.transform.parent = playerHandTrans;
        playerHand.Add(go);
        combat.CardPlacement(go);

        Debug.Log("Card Drawn");
    }

    private void SelectCard()
    {
        //animate card on selection
    }

    private void PlaceCard()
    {
        //Place card on card tile
    }
}
