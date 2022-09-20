using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddel : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mousePos;
    bool arrows = false;
    [SerializeField] float speed = 0.5f;
    [SerializeField] AudioClip brap;
    private bool isWhite = true;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(arrows == false)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            rb.transform.position = new Vector2(mousePos.x, rb.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrows = true;
        }

        if(arrows == true)
        {
            var moveInput = Input.GetAxisRaw("Horizontal");
            rb.transform.position = new Vector2(rb.transform.position.x + moveInput * speed, rb.transform.position.y);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Change this
        if (SceneManager.GetActiveScene().name == "Sus")
        {
            AudioSource.PlayClipAtPoint(brap, new Vector3(0, 0, -10f));
        }
            
    }
    public void ColourFlip()
    {
        isWhite = !isWhite;

        if (isWhite == true)
        {
            sprite.color = new Color(255, 255, 255);
        }

        else if (isWhite == false)
        {
            sprite.color = new Color(0, 0, 0);
        }
    }
}
