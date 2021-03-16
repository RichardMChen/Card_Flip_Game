using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipCard : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public bool isCardPressed;
    public bool isFlipped;
    public Color newColor;
    private Vector3 targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        isCardPressed = false;
        isFlipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCardPressed)
        {
            if (gameObject.transform.rotation.y < 1)
            {
                //transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
                RotateCard();
                //Debug.Log(gameObject.transform.rotation.y);
            }
            else
            {
                isFlipped = true;
            }

            if (gameObject.transform.rotation.y >= 0.5)
            {
                ColorBlock flippedButtonColor = gameObject.GetComponent<Button>().colors;
                flippedButtonColor.normalColor = newColor;
                gameObject.GetComponent<Button>().colors = flippedButtonColor;

                Text cardText = gameObject.GetComponentInChildren<Text>();
                cardText.enabled = true;
            }
        }
    }

    public void CardPressed()
    {
        isCardPressed = true;
        targetRotation = transform.eulerAngles + 180.0f * Vector3.up;
        Debug.Log("Card pressed");
    }

    public void RotateCard()
    {
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
