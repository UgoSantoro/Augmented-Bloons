using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public Transform ShopParent;
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public GameObject TurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
