using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{

    public IntVector2 posInGrid;

    private Vector3 cardStartPosition;

    public int cardValue;
    public string cardColour;
    public string cardType;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        cardStartPosition = transform.position;
    }

    //Referenced https://www.youtube.com/watch?v=JrNl8JN3_H4
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7);
        Vector3 cardPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = cardPosition;
    }

    void OnMouseUp()
    {
        Vector3 currentPos = transform.position;

        transform.position = new Vector3(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y), Mathf.Round(currentPos.z + 1));
          
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<CardController>() == null)
        {
            transform.position = cardStartPosition;
        }
    }
}
