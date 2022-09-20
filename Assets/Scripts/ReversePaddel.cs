using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePaddel : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mousePos;
    bool arrows = false;
    [SerializeField] float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arrows == false)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            rb.transform.position = new Vector2(-mousePos.x, rb.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrows = true;
        }

        if (arrows == true)
        {
            var moveInput = Input.GetAxisRaw("Horizontal");
            rb.transform.position = new Vector2(rb.transform.position.x -moveInput * speed, rb.transform.position.y);
        }
    }
}
