using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    public Vector3 positionOffset;

    public GameObject turret;

    public GameObject Shop;

    private Renderer rend;
    BuildManager buildmanager;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildmanager = BuildManager.instance;
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.instance.ShopParent.childCount >= 1)
        {
            for (int i = 0; i != BuildManager.instance.ShopParent.childCount ; i++)
            {
                Destroy(BuildManager.instance.ShopParent.GetChild(i).gameObject);
            }
        }
        GameObject clone = Instantiate(Shop);
        clone.transform.position = transform.position + new Vector3(0, 5.5f, 0);
        clone.transform.SetParent(BuildManager.instance.ShopParent);
        clone.GetComponentInChildren<Shop>().positionOffset = positionOffset;
        clone.GetComponentInChildren<Shop>().nodeposition = transform.position;
        clone.GetComponentInChildren<Shop>().actualObject = clone;
        clone.GetComponentInChildren<Shop>().node = transform.gameObject;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
