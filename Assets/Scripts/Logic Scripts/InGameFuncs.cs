using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameFuncs : MonoBehaviour
{
    public Player playermove;
    public GameObject Player;
   
    void Start()
    {
        playermove = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }
    public void Home()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Pause()
    {
        playermove.cantmove();
       
    }
    public void Resume()
    {
        playermove.canmove();
    }

  
}
