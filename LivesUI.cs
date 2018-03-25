using UnityEngine;
using UnityEngine.UI;


public class LivesUI : MonoBehaviour {

    public Text livesText;
	//printing the lives in the text UI
	// Update is called once per frame
	void Update () {
        livesText.text = PlayerStats.Lives.ToString()  ;
	}
}
