using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;

    public Text sellAmount;
    public Text upgradeCost;
    public Button upgradeButton;

    private Node target;
    
    public void Update()
    {
        //print(target);
    }

    public void SetTarget(Node _target)
    {
        print("SET TARGET");

        target = _target;
        
        transform.position = target.GetBuildPosition();
        

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        ui.SetActive(true);        
    }

    public void Hide()
    {

        ui.SetActive(false);
    }

    public void Upgrade()
    {
      //  print("Upgrade function");
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}