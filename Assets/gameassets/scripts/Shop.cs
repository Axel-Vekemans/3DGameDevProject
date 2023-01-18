using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint Tier1Turret;
    public TurretBlueprint Tier2Turret;
    public TurretBlueprint Tier3Turret;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void SelectStandardTurret()
    {
        Debug.Log("standard turret selected");
        buildManager.SelectTurretToBuild(Tier1Turret);
    }

    public void SelectTier2Turret()
    {
        Debug.Log("Tier2 turret selected");
        buildManager.SelectTurretToBuild(Tier2Turret);
    }

    public void SelectTier3Turret()
    {
        Debug.Log("Tier3 turret selected");
        buildManager.SelectTurretToBuild(Tier3Turret);
    }
}
