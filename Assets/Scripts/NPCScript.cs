using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    private int health = 2; // 2 is neutral
    public int preferredActionType;
    public int dislikedActionType;
    public int preferredTone;
    public int dislikedTone;
    public GameObject[] characterSprites;
    private bool laughing = false;
    private bool laughToggle = false;
    private bool won = false;
    private bool wonToggle = false;

    private float laughTimer = 0f;
    private float wonTimer = 0f;

    private float jumpSpeed = 10f;
    public AK.Wwise.Event neutralEvent;
    public AK.Wwise.Event angryEvent;
    public AK.Wwise.Event shockedEvent;
    public AK.Wwise.Event nauseaEvent;
    public AK.Wwise.Event laughterEvent;
    public AK.Wwise.Event winEvent;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DEMO KEYS
        //if (Input.GetKey("0"))
        //{
        //    Neutral();

        //}
        //if (Input.GetKey("2"))
        //{
        //    Sad();

        //}
        //if (Input.GetKey("3"))
        //{
        //    Shocked();

        //}
        //if (Input.GetKey("4"))
        //{
        //    Sick();

        //}
        //if (Input.GetKey("5"))
        //{
        //    Laugh();

        //}
        //if (Input.GetKey("6"))
        //{
        //    Win();

        //}
        if (laughing)
        {
            laughTimer += Time.deltaTime;
            if (laughTimer > 0.3f)
            {
                laughToggle = !laughToggle;
                showSprite(laughToggle ? 5 : 6);
                laughTimer = 0f;
            }
        }
        if (won)
        {
            wonTimer += Time.deltaTime;
            if (wonTimer > 0.5f)
            {
                wonToggle = !wonToggle;

                if (wonToggle)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + jumpSpeed, transform.position.z);
                }
                else
                { 
                    transform.position = new Vector3(transform.position.x, transform.position.y - jumpSpeed, transform.position.z);

                }

                wonTimer = 0f;

            }
        }
    }

    //* 0 = neutral, 1= sad 2= shocked 3= sick 4 = win 5 = laugh1 6=laugh2 */
    void showSprite(int spriteNumber)
    {
        print("Shwsprits + " + spriteNumber);
        for (int i = 0; i < characterSprites.Length; i++)
        {
            if(i == spriteNumber)
            {
                characterSprites[i].SetActive(true);
            }
            else
            {
                characterSprites[i].SetActive(false);
            }
        }
    }


    public void Neutral()
    {
        laughing = false;
        showSprite(0);
        neutralEvent.Post(gameObject);
    }

    public void Sad()
    {
        laughing = false;
        showSprite(1);
        angryEvent.Post(gameObject);
    }

    public void Shocked()
    {
        laughing = false;
        showSprite(2);
        shockedEvent.Post(gameObject);
    }

    public void Sick()
    {
        laughing = false;
        showSprite(3);
        nauseaEvent.Post(gameObject);
    }

    public void Win()
    {
        laughing = true;
        showSprite(4);
        won = true;
        winEvent.Post(gameObject);
    }

    public void Laugh()
    {
        laughing = true;
        showSprite(5);
        laughterEvent.Post(gameObject);
    }

    public int AddHealth(int amount)
    {
        health += amount;
        if (health > 3)
        {
            health = 3;
        }
        return health;
    }

    public int ReduceHealth(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            health = 0;
        }
        return health;
    }

    public int getHealth()
    {
        return health;
    }

}
