using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipCard : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public bool isCardPressed;
    public bool isFlipped;

    [Space(10)]
    [Header("Flipped Color Block")]
    public ColorBlock flippedColorBlock;
    [Space(10)]

    [Header("Unflipped Color Block")]
    public ColorBlock unFlippedColorBlock;
    [Space(10)]

    public FlipCardManager flipCardManager;

    //private Vector3 targetRotation;
    private Quaternion targetRotation;
    public bool flipFaceDown;   // The card is to be flipped back over to face down

    // Start is called before the first frame update
    void Start()
    {
        isCardPressed = false;
        isFlipped = false;
        flipFaceDown = false;
        flipCardManager = GameObject.FindObjectOfType<FlipCardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCardPressed)
        {
            gameObject.GetComponent<Button>().interactable = false;
            if (gameObject.transform.rotation.y > -1)
            //if (Mathf.Approximately(gameObject.transform.rotation.y, -1) )
            //if (gameObject.transform.rotation.eulerAngles.y < 180)
            {
                //transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
                RotateCard();
                //Debug.Log(gameObject.transform.rotation.y);
            }
            else
            {
                isFlipped = true;
                isCardPressed = false;
            }

            if (gameObject.transform.rotation.y <= -0.5)
            {
                ColorBlock flippedButtonColor = gameObject.GetComponent<Button>().colors;
                flippedButtonColor = flippedColorBlock;
                gameObject.GetComponent<Button>().colors = flippedButtonColor;

                Text cardText = gameObject.GetComponentInChildren<Text>();
                cardText.enabled = true;
            }
        }

        if (flipFaceDown)
        {
            //Debug.Log("Angle Difference: " + Quaternion.Angle(gameObject.transform.rotation, targetRotation));
            if (gameObject.transform.rotation.y < 0)
            //if (gameObject.transform.rotation.eulerAngles.y > 0)
            {
                RotateCard();
                //Debug.Log(gameObject.transform.rotation.eulerAngles.y + " | " + Mathf.Round(gameObject.transform.rotation.y));
            }
            else
            {
                isFlipped = false;
                flipFaceDown = false;
                gameObject.GetComponent<Button>().interactable = true;
                Debug.Log("Not flipped");
            }

            /*Debugging*/
            //if (Quaternion.Angle(gameObject.transform.rotation, targetRotation) < 0)  // -> Try using Mathf.DeltaAngle and just getting the y rotation
            //{
            //    RotateCard();
            //}
            //else
            //{
            //    Debug.Log("Set up the face down state");
            //    isFlipped = false;
            //    flipFaceDown = false;
            //    gameObject.GetComponent<Button>().interactable = true;
            //}

            if (gameObject.transform.rotation.y <= 0.5)
            {
                ColorBlock unFlippedButtonColor = gameObject.GetComponent<Button>().colors;
                unFlippedButtonColor = unFlippedColorBlock;
                gameObject.GetComponent<Button>().colors = unFlippedButtonColor;

                Text cardText = gameObject.GetComponentInChildren<Text>();
                cardText.enabled = false;
            }
        }

        //Debug.Log(gameObject.transform.eulerAngles.y);
        //Debug.Log(Mathf.Ceil(gameObject.transform.rotation.y));
        //Debug.Log(transform.rotation);
    }

    public void CardPressed()
    {
        isCardPressed = true;
        //targetRotation = transform.eulerAngles + 180.0f * Vector3.up;
        //targetRotation = new Vector3(0.0f, 180.0f, 0.0f);
        targetRotation = new Quaternion(0.0f, -1.0f, 0.0f, 0.0f);
        //Debug.Log(targetRotation);
        if (!isFlipped)
        {
            flipCardManager.AddCardToList(this);
            //flipCardManager.currentNumFlippedCards++;
        }
    }

    public void FlipCardFaceDown()
    {
        //targetRotation = new Vector3(0.0f, 0.0f, 0.0f);
        targetRotation = Quaternion.identity;
        //targetRotation = new Quaternion(0.0f, 1.0f, 0.0f, 0.0f);
        flipFaceDown = true;
    }

    public void RotateCard()
    {
        // If statement still a work in progress.
        //if (isFlipped)
        //{
        //    //targetRotation = transform.eulerAngles - 180.0f * Vector3.up;
        //    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed * Time.deltaTime);
        //}
        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed * Time.deltaTime);

        //Work on
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }    
}
