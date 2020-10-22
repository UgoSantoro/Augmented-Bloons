using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    BuildManager buildmanager;
    private GameObject turret;

    public GameObject actualObject;

    public Vector3 positionOffset;
    public Vector3 nodeposition;

    void Start()
    {
        buildmanager = BuildManager.instance;
    }

    public void Create_Turret1()
    {
        buildmanager.SetTurretToBuild(buildmanager.TurretPrefab);

        if (buildmanager.GetTurretToBuild() == null)
            return;

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, nodeposition + positionOffset, transform.rotation);

    }

    public void Create_Turret2()
    {

    }

    public GameObject get_turret()
    {
        return turret;
    }

    public void Destroy_Shop()
    {
        Destroy(actualObject);
    }
}
