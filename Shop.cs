using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

    public TurretBluePrint standardTurret;
    public TurretBluePrint MissileLauncher;
    public TurretBluePrint LazerBeamer;
    BuildManager buildManager;

    //selecting turrets from the shop canvas to build
    void Start()
    {
        buildManager = BuildManager.instance;
    }
	public void SelectStandardTurret(){

        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {

        Debug.Log("Missile Launcher Purchased");
        buildManager.SelectTurretToBuild(MissileLauncher);
    }
    public void SelectLazerBeamer()
    {

        Debug.Log("Lazer Beamer Purchased");
        buildManager.SelectTurretToBuild(LazerBeamer);
    }
}
