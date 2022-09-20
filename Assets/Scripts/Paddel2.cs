using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddel2 : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mousePos;
    bool arrows = false;
    [SerializeField] float speed = 0.5f;
    [SerializeField] AudioClip brap;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(arrows == false)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            rb.transform.position = new Vector2(rb.transform.position.x, mousePos.y);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrows = true;
        }

        if(arrows == true)
        {
            var moveInput = Input.GetAxisRaw("Horizontal");
            rb.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y + moveInput * speed);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Change This
        if (SceneManager.GetActiveScene().name == "Sus")
        {
            AudioSource.PlayClipAtPoint(brap, new Vector3(0, 0, -10f));
        }
            
    }
}
