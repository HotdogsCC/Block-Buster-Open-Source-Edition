using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telebloc : MonoBehaviour
{
    [SerializeField] GameLogic logic;
    public int health = 30;
    Rigidbody2D rb;
    [SerializeField] TMPro.TextMeshProUGUI score;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite injured;
    [SerializeField] Sprite veryinjured;

    private void Start()
    {
        logic.AddBlock();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if(health <= 0)
        {
            logic.RemoveBlock();
            Destroy(gameObject);
        }
        else
        {
            rb.transform.position = new Vector2(Random.Range(-7, 7), Random.Range(0, 3));
        }
        
    }

    private void Update()
    {
        score.text = health.ToString();

        if(health == 20)
        {
            sprite.sprite = injured;
        }
        if (health == 10)
        {
            sprite.sprite = veryinjured;
        }
    }

}
