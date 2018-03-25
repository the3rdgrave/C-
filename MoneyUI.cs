using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyUI : MonoBehaviour {

    public Text moneyText;
	
	// Update is called once per frame
    //setting the money to the players left side
	void Update () {
        moneyText.text = "$ " + PlayerStats.Money.ToString();
	
	}
}
