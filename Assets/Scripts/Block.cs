using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    [SerializeField] GameLogic logic;
    [SerializeField] GameObject boom;
    Transform myTransform;
    [SerializeField] private int health;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite injured;
    [SerializeField] Sprite veryinjured;
    public bool isWhite = true;
    [SerializeField] BoxCollider2D boxcol2d;



    private void Start()
    {
        logic.AddBlock();
        myTransform = gameObject.transform;
        sprite = GetComponent<SpriteRenderer>();
        boxcol2d = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health == 0)
        {
            logic.RemoveBlock();
            if (SceneManager.GetActiveScene().buildIndex == 31)
            {
                sprite.enabled = false;
                boxcol2d.enabled = false;
            }
            else
            {
                Destroy(gameObject);
            }           
            
        }
        else if (health == 2)
        {
            sprite.sprite = injured;
        }
        else if (health == 1)
        {
            sprite.sprite = veryinjured;
        }
        
        
    }

    public void ColourFlip()
    {
        isWhite = !isWhite;

        if(isWhite == true)
        {
            sprite.color = new Color(255, 255, 255);
        }

        else if(isWhite == false)
        {
            sprite.color = new Color(0, 0, 0);
        }
    }
}
