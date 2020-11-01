using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARSessionOrigin))]
[RequireComponent(typeof(ARRaycastManager))]
public class ARTapPlaceObject : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    private ARRaycastManager _aRRaycastManager;

    ARSessionOrigin SessionOrigin;


    private int Isspawned = 0;
    private GameObject spawnedObject;
    private Vector2 touchposition;

    //public Button ReloadButton;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    [SerializeField]
    [Tooltip("A transform which should be made to appear to be at the touch point.")]
    Transform m_Content;

    /// <summary>
    /// A transform which should be made to appear to be at the touch point.
    /// </summary>
    public Transform content
    {
        get { return m_Content; }
        set { m_Content = value; }
    }

    [SerializeField]
    [Tooltip("The rotation the content should appear to have.")]
    Quaternion m_Rotation;

    /// <summary>
    /// The rotation the content should appear to have.
    /// </summary>
    public Quaternion rotation
    {
        get { return m_Rotation; }
        set
        {
            m_Rotation = value;
            if (SessionOrigin != null)
                SessionOrigin.MakeContentAppearAt(content, content.transform.position, m_Rotation);
        }
    }

    private void Awake()
    {
        SessionOrigin = GetComponent<ARSessionOrigin>();
        _aRRaycastManager = GetComponent<ARRaycastManager>();
        SessionOrigin.transform.localScale = Vector3.one * 50;

        //ReloadButton.onClick.AddListener(replaceMap);
    }

    public bool TryGetTouchPosition(out Vector2 touchposition)
    {
        if (Input.touchCount > 0)
        {
            touchposition = Input.GetTouch(0).position;
            return true;
        }
        touchposition = default;
        return false;
    }

    public void replaceMap()
    {
        //SessionOrigin.MakeContentAppearAt(content, new Vector3(content.position.x + 1000, content.position.y, content.position.z), m_Rotation);
        Destroy(spawnedObject);
        Isspawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchposition))
            return;

        if (_aRRaycastManager.Raycast(touchposition, hits, trackableTypes:TrackableType.PlaneWithinPolygon))
        {
            var hitpose = hits[0].pose;

            if (Isspawned == 0)
            {
                Isspawned = 1;
                spawnedObject = (GameObject)Instantiate(gameObjectToInstantiate, new Vector3(hitpose.position.x, hitpose.position.y + 1, hitpose.position.z), m_Rotation, GameObject.Find("Offset").transform);
                SessionOrigin.MakeContentAppearAt(content, hitpose.position, m_Rotation);
                GameObject.Find("GameHandler").GetComponent<WaveSpawner>().Start();

            }

            //spawnedObject = Instantiate(gameObjectToInstantiate, hitpose.position, hitpose.rotation);
            //SessionOrigin.MakeContentAppearAt(content, hitpose.position, rotation);
            //spawnedObject = 1;
            /*else
            {
                spawnedObject.transform.position = hitpose.position;
                spawnedObject.transform.rotation = hitpose.rotation;
            }*/
        }
    }
}
