using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    public bool hasGameStarted = false;
    public static Rigidbody2D myPos;
    bool canIReset = false;
    bool lol = false;
    Rigidbody2D rb;
    [SerializeField] GameObject paddel;
    [SerializeField] float offset;
    [SerializeField] float ballSpeed;
    [SerializeField] ScenceScript scenething;
    [SerializeField] resetcanvas resetUI;
    public bool isWhite = true;
    private SpriteRenderer sprite;
    [SerializeField] GameLogic logic;

    [SerializeField] private Sprite ballSprite;
    [SerializeField] private Sprite eyeBallSprite;
    [SerializeField] private Sprite kirbyBallSprite;
    [SerializeField] private Sprite eightBallSprite;
    [SerializeField] private Sprite susBallSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        

        if (rb.transform.position.y <= -6f || rb.transform.position.y >= 12f || rb.transform.position.x >=18f || rb.transform.position.x <= -18f)
        {
            scenething.LoadGameOver();
        }
        if (!hasGameStarted)
        {
            rb.transform.position = new Vector2(paddel.transform.position.x, paddel.transform.position.y + offset);
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {
                hasGameStarted = true;
                rb.velocity = new Vector2(ballSpeed/6, ballSpeed);
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && canIReset == true)
        {
            hasGameStarted = false;
            canIReset = false;
            lol = false;
        }

        if(hasGameStarted == true && rb.velocity.y > -0.05f && rb.velocity.y < 0.05f && lol == false)
        {
            Debug.Log("UH OH");
            StartCoroutine(WaitForSeconds());
            lol = true;
        }

        IEnumerator WaitForSeconds()
        {
            yield return new WaitForSeconds(3);
            if (rb.velocity.y > -0.05f && rb.velocity.y < 0.05f)
            {
                Debug.Log("phew...");
                canIReset = true;
                resetUI.Show();
            }
            else
            {
                lol = false;
            }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.ColourFlip();
    }

}
