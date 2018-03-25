using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public AudioClip LoseSound;
    public static bool gameEnded;
  
    // static moves to next scene public static bool gameEnded = false; 
    public GameObject gameOverUI;
   
    void Start()
    {
        Time.timeScale = 1f;
        gameEnded = false;
        
    }
	// Update is called once per frame
	void Update()
    {




              if (gameEnded)
                       return;

            
        
               if (PlayerStats.Lives <= 0)
                  {
            
            EndGame();


                   }
           }
   //enabling game over UI + sound
	void EndGame()
	{
		gameEnded = true;
        gameOverUI.SetActive(true);
        AudioSource.PlayClipAtPoint(LoseSound, transform.position);
    }

   

}