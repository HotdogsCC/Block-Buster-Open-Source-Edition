using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetcanvas : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            canvas.enabled = false;
        }
    }

    public void Show()
    {
        canvas.enabled = true;
        StartCoroutine(WaitForSeconds(3));
    }

    IEnumerator WaitForSeconds(int secs)
    {
        yield return new WaitForSeconds(secs);
        canvas.enabled = false;
    }
}
