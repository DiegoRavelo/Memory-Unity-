using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System;
using DG.Tweening;

public class CartShuffle : MonoBehaviour
{
    // Start is called before the first frame update
    [FormerlySerializedAs("CardGrid")] [SerializeField] private int y;

    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private Transform center;

    [SerializeField] private List<GameObject> cardsList = new List<GameObject>();

    [SerializeField] private int x;
    

    public CardMemes cardMemes;
    void Start()
    {
        cardMemes.SetUpCards(x*y);
        
        for (int i = 0; i < x*y; i++)
        {
            GameObject card = Instantiate(cardPrefab, new Vector3(- 2, 0 + (-0.1f * i), -0.542f), Quaternion.identity);

            Sprite sp = cardMemes.GetSprite();

            card.GetComponentInChildren<Card>().SetUp(sp);
            
            cardsList.Add(card);
        }
        
        StartCoroutine("DisplayCards");

    }

    public void MoveCards()
    {
       
        
    }

    public IEnumerator DisplayCards()
    {
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                int cardIndex = (x * i) + j;
                
                cardsList[cardIndex].transform.DOMove(new Vector3(-1 + (1 * j), -1 + (1 * i), -0.542f) , 1);
                
                yield return new WaitForSeconds(0.1f);
                

            }
            
        }
    }

 

  
}
