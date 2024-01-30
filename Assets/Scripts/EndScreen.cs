using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject bgd;
    public GameObject winScreen;
    public GameObject loseScreen1;
    public GameObject loseScreen2;
    private float loseTimer = 0f;
    private bool endGame = false;
    private bool wonBool;
    public AK.Wwise.Event winSound;
    public AK.Wwise.Event loseSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cheat keys
        if (Input.GetKey("v"))
        {
            EndGame(true);

        }
        if (Input.GetKey("9"))
        {
            EndGame(false);

        }

        if (endGame && !wonBool)
        {
            loseTimer += Time.deltaTime;
            if (loseTimer>1f)
            {
                loseScreen1.SetActive(false);
                loseScreen2.SetActive(true);
                endGame = false;
            }

        }
    }

    public void EndGame(bool won)
    {

        loseSound.Post(gameObject);
        wonBool = won;
        endGame = true;
        bgd.SetActive(true);
        if (won)
        {
            winScreen.SetActive(true);
        }
        else
        {
            loseScreen1.SetActive(true);
        }

    }
}
