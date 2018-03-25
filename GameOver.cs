using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameOver : MonoBehaviour {

    
    public Text roundsText;

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }
    //retry button in game over menu
    public void Retry()
    {
        foreach (Enemy e in GameObject.FindObjectsOfType<Enemy>())
           e.Die();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); //restart the currently loaded scene
    }
    //going back to menu(button) in game over menu
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
