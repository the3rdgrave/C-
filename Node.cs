using UnityEngine;
//the user cant build in the way of the UI SHOP
using UnityEngine.EventSystems;
//


public class Node : MonoBehaviour
{


    public AudioClip SellSound;
   public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]

    public GameObject turret;

    [HideInInspector]

    public TurretBluePrint turretBlueprint;

    [HideInInspector]

    public bool isUpgraded = false;

    private Renderer rend;

  //  private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
      //  startColor = rend.material.color;
        buildManager = BuildManager.instance;
       
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        //the user cant build in the way of the UI SHOP
        if (EventSystem.current.IsPointerOverGameObject())
            return;

       

        if (turret != null)
        {

            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;
        BuildTurret(buildManager.GetTurretToBuild());
            
    }
    //if the players has the required money he builds a tower
    void BuildTurret(TurretBluePrint blueprint)
    {
        
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            return;
        }
       
        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
       
        //error
        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret was built!");
    }
    //upgrade turret and destroy the previous prefab
    public void UpgradeTurret()
    {
        print("Upgrade function called");

        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to Upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;
        //DEstroy
        Destroy(turret);
        //build
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.UpgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret Upgraded!");
    }
    //selling the turret
    public void SellTurret()
    {
        
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        AudioSource.PlayClipAtPoint(SellSound, Camera.main.transform.position);
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    //doesnt work because I changed the node textures to unlit.
    void OnMouseEnter()
    {
        //the user cant build in the way of the UI SHOP
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        //
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughMoneyColor;
        }
       
    }

    void OnMouseExit()
    {
    //   rend.material.color = startColor;
    }
}