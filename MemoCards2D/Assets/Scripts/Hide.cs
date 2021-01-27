using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    public GameObject back;
    public GenerateCards generateCards;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if(back.activeSelf && generateCards.card2 == null)
        {
            back.SetActive(false);
            generateCards.FindMatch(this);
        }
    }

}
