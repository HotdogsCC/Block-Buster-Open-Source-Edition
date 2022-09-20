using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelball : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.transform.position.y <= -6f || rb.transform.position.y >= 12f || rb.transform.position.x >= 18f || rb.transform.position.x <= -18f)
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
            Debug.Log("phew..");
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
                canIReset = true;
                resetUI.Show();
            }
            else
            {
                lol = false;
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(WaitForSecs());
    }

   private IEnumerator WaitForSecs()
    {
        yield return new WaitForSeconds(0.05f);
        rb.velocity = new Vector2(rb.velocity.x * 1.009f, rb.velocity.y * 1.009f);
    }

}
