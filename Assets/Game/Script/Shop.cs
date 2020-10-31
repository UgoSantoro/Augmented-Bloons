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
    private GameObject gameHandler;
    private float money;


    void Start()
    {
        buildmanager = BuildManager.instance;
        gameHandler = GameObject.Find("GameHandler");
        money = gameHandler.GetComponent<WaveSpawner>().money;
    }

    void Update()
    {
        money = gameHandler.GetComponent<WaveSpawner>().money;
    }

    public void Create_Turret()
    {
        if (node.GetComponent<Node>().turret != null || money < 70) return;
        buildmanager.SetTurretToBuild(buildmanager.TurretPrefab);

        if (buildmanager.GetTurretToBuild() == null) return;

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, nodeposition + positionOffset, node.transform.rotation);
        node.GetComponent<Node>().turret = turret;
        gameHandler.GetComponent<WaveSpawner>().money -= 70;
        Destroy(actualObject);

    }

    public void Create_Missile()
    {
        if (node.GetComponent<Node>().turret != null || money < 70) return;
        buildmanager.SetTurretToBuild(buildmanager.MissilePrefab);

        if (buildmanager.GetTurretToBuild() == null) return;

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, nodeposition + new Vector3(0, 0.1f, 0), node.transform.rotation);
        node.GetComponent<Node>().turret = turret;
        gameHandler.GetComponent<WaveSpawner>().money -= 70;
        Destroy(actualObject);

    }
    public void Create_Laser()
    {
        if (node.GetComponent<Node>().turret != null || money < 70) return;
        buildmanager.SetTurretToBuild(buildmanager.LaserPrefab);

        if (buildmanager.GetTurretToBuild() == null) return;

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, nodeposition + new Vector3(0, 0.1f, 0), node.transform.rotation);
        node.GetComponent<Node>().turret = turret;
        gameHandler.GetComponent<WaveSpawner>().money -= 70;
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
