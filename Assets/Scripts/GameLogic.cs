using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] int blocks = 0;
    [SerializeField] ScenceScript scenething;
    public static int totalBlocks = 0;
    public static int brokenBlocks = 0;
    [SerializeField] AudioClip vineBoom;
    [SerializeField] AudioClip music;
    [SerializeField] AudioClip blockBreakSFX;
    [SerializeField] Block[] blocksToColourFlip;
    [SerializeField] Ball ballToColourFlip;
    [SerializeField] Cam camToColourFlip;
    [SerializeField] Paddel paddelToColourFlip;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Sus")
        {
            StartCoroutine(Music());
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (blocks <= 0)
        {
            scenething.LoadWinScreen();
        }
    }

    public void AddBlock()
    {
        blocks++;
        totalBlocks++;
    }

    public void RemoveBlock()
    {
        blocks--;
        brokenBlocks++;
        AudioSource.PlayClipAtPoint(blockBreakSFX, new Vector3(0, 0, -10));

        if(SceneManager.GetActiveScene().name == "Sus")
        {
            AudioSource.PlayClipAtPoint(vineBoom, new Vector3(0, 0, -10));
        }
        
        
    }
    IEnumerator Music()
    {
        AudioSource.PlayClipAtPoint(music, new Vector3(0, 0, -10));
        yield return new WaitForSeconds(18);
        StartCoroutine(Music());
    }

    public void ColourFlip()
    {
        ballToColourFlip.ColourFlip();
        camToColourFlip.ColourFlip();
        foreach(var block in blocksToColourFlip)
        {
            block.ColourFlip();
        }
      
    }
}
