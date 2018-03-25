using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseMenu : MonoBehaviour {

    
   // private AudioSource PauseSound;
    public GameObject ui;
    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;
    

    //pressing escape or p to pause
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
           // PauseSound = GetComponent<AudioSource>();
            Toggle();
           
        }
        
    }
    //freezing the game - unfreeze it
    public void Toggle()
    {
        
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
            
            
        } else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
       // AudioSource.PlayClipAtPoint(ClickSound, transform.position);
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
       
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
