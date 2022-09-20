using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image image;
    private string direction = "up";
    [SerializeField] float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if(image.color.a >= 1)
        {
            direction = "down";
        }
        else if(image.color.a <= 0)
        {
            direction = "up";
        }

        if(direction == "up")
        {
            image.color = new Color(0, 0, 0, fadeSpeed * Time.deltaTime + image.color.a);
        }
        else if(direction == "down")
        {
            image.color = new Color(0, 0, 0, image.color.a - (fadeSpeed * Time.deltaTime));
        }
    }
}
