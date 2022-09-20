using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hellpaddeladon : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float spinSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Quaternion.identity.z + spinSpeed;
        rb.transform.rotation = new Quaternion(Quaternion.identity.x, Quaternion.identity.y, x, Quaternion.identity.w);
    }
    
}
