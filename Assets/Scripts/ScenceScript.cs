using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScenceScript : MonoBehaviour
{
    static string sceneToLoad;
    public TMPro.TextMeshProUGUI level;


    // Start is called before the first frame update
    void Start()
    {
        level.text = sceneToLoad.ToString();
    }

    // Update is called once per frame
    

    public void LoadMainMenu()
    {
        GameLogic.brokenBlocks = 0;
        GameLogic.totalBlocks = 0;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadHome()
    {
        GameLogic.brokenBlocks = 0;
        GameLogic.totalBlocks = 0;
        SceneManager.LoadScene("Home Page");
    }

    public void LoadWinScreen()
    {        
        SceneManager.LoadScene("Win Screen");
    }

    public void LoadGameOver()
    {
        sceneToLoad = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Game Over");
    }

   

    public void LoadMonochrome()
    {
        SceneManager.LoadScene("Monochrome");
    }

    public void LoadHell()
    {
        SceneManager.LoadScene("Hell");
    }

    public void LoadCheckers()
    {
        SceneManager.LoadScene("Checkers");
    }

    public void LoadRainbow()
    {
        SceneManager.LoadScene("Rainbow");
    }

    public void Retry()
    {
        GameLogic.brokenBlocks = 0;
        GameLogic.totalBlocks = 0;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadTeleport()
    {
        SceneManager.LoadScene("Teleport");
    }

    public void LoadSus()
    {
        SceneManager.LoadScene("Sus");
    }

    public void LoadFenced()
    {
        SceneManager.LoadScene("Fenced");
    }

    public void LoadCore()
    {
        SceneManager.LoadScene("Core");
    }

    public void LoadPaddels()
    {
        SceneManager.LoadScene("Paddels");
    }

    public void LoadTorture()
    {
        SceneManager.LoadScene("Torture");
    }

    public void LoadAcceleration()
    {
        SceneManager.LoadScene("Acceleration");
    }

    public void LoadPills()
    {
        SceneManager.LoadScene("Pills");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

    public void LoadLeaderboards()
    {
        SceneManager.LoadScene("Leaderboards");
    }

    public void LoadInvert()
    {
        SceneManager.LoadScene("Invert");
    }

    public void LoadFade()
    {
        SceneManager.LoadScene("Fade");
    }

    public void LoadReverse()
    {
        SceneManager.LoadScene("Reverse");
    }



    
}
