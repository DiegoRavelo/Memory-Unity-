using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    // Start is called before the first frame update
    public static CardHand Instance  { get; private set; }

    [SerializeField] private Card firstCard;

    [SerializeField] private Card secondCard;

    [SerializeField] public bool canFlip;
    
    void Start()
    {
        canFlip = true;
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }

    public void SetHandCards(Card card)
    {
        if (firstCard == null)
        {
            this.firstCard = card;
        }
        else
        {
            this.secondCard = card;
        }

        if (firstCard != null && secondCard != null)
        {
            CheckCards();
        }
        
        
    }

    public void CheckCards()
    {
        if(!canFlip) return;
        
        if(this.firstCard.image.sprite == this.secondCard.image.sprite)
        {
            this.firstCard = null;
            this.secondCard = null;

        }
        else
        {
            StartCoroutine("Flip");

        }
    }

    public IEnumerator Flip()
    {
        canFlip = false;
        
        yield return new WaitForSeconds(0.75f);
        
        Debug.Log("Flip2");
        
        firstCard.anim.Play("Flip2");
        firstCard.locked = false;
            
        secondCard.anim.Play("Flip2");
        secondCard.locked = false;
            
        this.firstCard = null;
        this.secondCard = null;

        canFlip = true;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
