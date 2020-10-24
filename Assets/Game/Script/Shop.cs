using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    BuildManager buildmanager;

    private GameObject turret;

    public GameObject actualObject;
    public GameObject node;
    public Vector3 positionOffset;
    public Vector3 nodeposition;

    void Start()
    {
        buildmanager = BuildManager.instance;
    }

    public void Create_Turret()
    {
        if (node.GetComponent<Node>().turret != null) return;
        buildmanager.SetTurretToBuild(buildmanager.TurretPrefab);

        if (buildmanager.GetTurretToBuild() == null) return;

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, nodeposition + positionOffset, node.transform.rotation);
        node.GetComponent<Node>().turret = turret;
        Destroy(actualObject);

    }

    public void Create_Missile()
    {
        if (node.GetComponent<Node>().turret != null) return;
        buildmanager.SetTurretToBuild(buildmanager.MissilePrefab);

        if (buildmanager.GetTurretToBuild() == null) return;

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, nodeposition + new Vector3(0, 0, 0), node.transform.rotation);
        node.GetComponent<Node>().turret = turret;
        Destroy(actualObject);

    }
    public void Create_Laser()
    {
        if (node.GetComponent<Node>().turret != null) return;
        buildmanager.SetTurretToBuild(buildmanager.LaserPrefab);

        if (buildmanager.GetTurretToBuild() == null) return;

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, nodeposition + positionOffset, node.transform.rotation);
        node.GetComponent<Node>().turret = turret;
        Destroy(actualObject);
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
