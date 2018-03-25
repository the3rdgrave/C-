using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
    //method for speeding up the game and set it back to normal time
   public void Button()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 2.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

    }
}
