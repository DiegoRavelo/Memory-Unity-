using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class Card : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update

    public Animator anim;

    public Image image;

    public bool locked = false;

    private bool Locked
    {
        get { return locked; }
        set { locked = value; }
    }

    void Awake()
    {
        anim = this.GetComponent<Animator>();
        
        
        

    }

    public void SetUp(Sprite sprite)
    {
        this.image.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 || locked) return;

            if (CardHand.Instance.canFlip == false)
            {
                return;
            } 
            else if(transform.rotation == Quaternion.identity)
            {
                anim.Play("Flip");
                
                locked = true;
                
                CardHand.Instance.SetHandCards(this);
            }
            
           //else  anim.Play("Flip2");
       
            Debug.Log("Card clicked");
        }
    }
}
