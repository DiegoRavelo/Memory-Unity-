using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Memes")]
public class CardMemes : ScriptableObject
{
    // Start is called before the first frame update
    public List<Sprite> MemesLibrary = new List<Sprite>();

    public List<Sprite> MemesDisplayer = new List<Sprite>();

    private Queue<Sprite> MemesQueue = new Queue<Sprite>();
    

    public void SetUpCards(int grid)
    {
        MemesDisplayer.Clear();
        
        for(int i = 0; i < grid; i++)
        {
            if (i >= MemesLibrary.Count) return;
            
            MemesDisplayer.Add(MemesLibrary[i]);
            MemesDisplayer.Add(MemesLibrary[i]);

            
        }
        
        ShuffleCards();
        
    }

    public Sprite GetSprite()
    {
        int i = Random.Range(0 , MemesDisplayer.Count);

        Sprite sp = MemesDisplayer[i];

        MemesDisplayer.RemoveAt(i);
        
        return sp;
        
    }

    public void ShuffleCards()
    {
        System.Random rng = new System.Random();
        
        MemesDisplayer.Sort((x, y) => rng.Next(-1, 2));
        
    }

    
}
