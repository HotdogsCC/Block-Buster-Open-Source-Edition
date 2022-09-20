using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = GameLogic.brokenBlocks + "/" + GameLogic.totalBlocks + " Blocks Busted";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
