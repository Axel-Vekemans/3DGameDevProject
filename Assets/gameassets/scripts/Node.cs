using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color NotEnoughMoneyColor;

    public Vector3 positionOffset;

    public AudioSource src;
    public AudioClip sfxBuild, sfxSell;



    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret (TurretBlueprint bleuprint)
    {
        if (PlayerStats.Money < bleuprint.cost)
        {
            Debug.Log("not enough money");
            return;
        }

        PlayerStats.Money -= bleuprint.cost;

        GameObject _turret = (GameObject)Instantiate(bleuprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        src.clip = sfxBuild;
        src.Play();


        turretBlueprint = bleuprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

    }


    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("not enough money to upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //delete old turret
        Destroy(turret);

        //build new turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        src.clip = sfxBuild;
        src.Play();

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;


    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);


        Destroy(turret);
        turretBlueprint = null;

        src.clip = sfxSell;
        src.Play();

        isUpgraded = false;
    }



    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (!buildManager.CanBuild)
            return;


        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;

        }
        else
        {
            rend.material.color = NotEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
