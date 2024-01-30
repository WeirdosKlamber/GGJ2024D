using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private List<Transform> anchors;
    private CombatManager manager;

    private void Start()
    {
        manager = GetComponent<CombatManager>();
    }

    public void CardPlacement(GameObject cardTrans)
    {
        //manager.playerHand[0].transform.position = anchors[0].transform.position;
        //manager.playerHand[0].transform.parent = anchors[0].transform;

        //Transform cardTrans = manager.playerHand[0].transform;

        /*
        for (int i = 0; i < anchors.Count; i++)
        {
            if (anchors[i].transform.childCount < 0)
            {
                cardTrans.transform.position = anchors[i].transform.position;
                cardTrans.transform.parent = anchors[i].transform;
            }
        }
        */

        if (anchors[0].transform.childCount <= 0)
        {
            cardTrans.transform.position = anchors[0].transform.position;
            cardTrans.transform.parent = anchors[0].transform;
        }
        else if (anchors[1].transform.childCount <= 0)
        {
            cardTrans.transform.position = anchors[1].transform.position;
            cardTrans.transform.parent = anchors[1].transform;
        }
        else if (anchors[2].transform.childCount <= 0)
        {
            cardTrans.transform.position = anchors[2].transform.position;
            cardTrans.transform.parent = anchors[2].transform;
        }

        Debug.Log(cardTrans);
    }
}
