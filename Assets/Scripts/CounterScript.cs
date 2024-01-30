using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.Counters
{
    public class CounterScript : MonoBehaviour
    {
        public int counterType;
        public GameObject cardHolder1Pos;
        public GameObject cardHolder2Pos;
        public GameObject cardHolder3Pos;
        public GameObject counterHoverPosition;
        public AK.Wwise.Event counterPlacement;


        private bool pickingUp;
        private bool puttingDown;
        private bool testBool;


        // Transforms to act as start and end markers for the journey.
        private Transform startMarker;
        private Transform hoverMarker;
        private Transform endMarker;
        public Vector3 startPos;

        // Movement speed in units per second.
        private float speed = 0.01F;

        // Time when the movement started.
        private float startTime;

        // Total distance between the markers.
        private float journeyLength;


        // Start is called before the first frame update
        void Start()
        {
            startMarker = gameObject.transform; //this moves
            print("START startpos" + startMarker.position);

            hoverMarker = counterHoverPosition.transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (!testBool)
            {
                PickUp();
                testBool = true;
            }
            if (pickingUp)
            {
                // Distance moved equals elapsed time times speed..
                float distCovered = (Time.time - startTime) * speed;

                // Fraction of journey completed equals current distance divided by total distance.
                float fractionOfJourney = distCovered / journeyLength;

                // Set our position as a fraction of the distance between the markers.
                transform.position = Vector3.Lerp(startMarker.position, hoverMarker.position, fractionOfJourney);
                //transform.rotation = Vector3.Lerp(startMarker.rotation, hoverMarker.rotation, fractionOfJourney);

                transform.Rotate(Time.deltaTime * 90f, 0f, 0f);

                if (transform.position == hoverMarker.position)
                {                    
                    pickingUp = false;
                    PutDown(counterType);
                }

            }
            if (puttingDown)
            {

                // Distance moved equals elapsed time times speed..
                float distCovered = (Time.time - startTime) * speed;

                // Fraction of journey completed equals current distance divided by total distance.
                float fractionOfJourney = distCovered / journeyLength;

                // Set our position as a fraction of the distance between the markers.
                transform.position = Vector3.Lerp(hoverMarker.position, endMarker.position, fractionOfJourney);


                if (transform.position == endMarker.position)
                {
                    puttingDown = false;
                    transform.Rotate(-90f, 0f, 0f);
                    ReturnToStart();
                }

            }

        }

        public void ReturnToStart()
        {
            gameObject.transform.localPosition = startPos;

        }

        public void PickUp()
        {

            pickingUp = true;
            startTime = Time.time;
            journeyLength = Vector3.Distance(startMarker.position, hoverMarker.position);
        }

        public void PutDown(int cardHolder)
        {

            puttingDown = true;
            speed *= 150; //no idea why
            startTime = Time.time;
            switch (cardHolder)
            {
                case 1:
                    endMarker = cardHolder1Pos.transform;
                    break;
                case 2:
                    endMarker = cardHolder2Pos.transform;
                    break;
                case 3:
                    endMarker = cardHolder3Pos.transform;
                    break;
            }
            journeyLength = Vector3.Distance(hoverMarker.position, endMarker.position);

        }

    }
}