using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARSessionOrigin))]
[RequireComponent(typeof(ARRaycastManager))]
public class ARTapPlaceObject : MonoBehaviour
{
    //public GameObject gameObjectToInstantiate;

    private ARRaycastManager _aRRaycastManager;

    ARSessionOrigin SessionOrigin;


    private int spawnedObject = 0;
    //private GameObject spawnedObject;
    private Vector2 touchposition;

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
        SessionOrigin.transform.localScale = Vector3.one * 100;
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

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchposition))
            return;

        if (_aRRaycastManager.Raycast(touchposition, hits, trackableTypes:TrackableType.PlaneWithinPolygon))
        {
            var hitpose = hits[0].pose;

            if (spawnedObject == 0)
            {
                //spawnedObject = Instantiate(gameObjectToInstantiate, hitpose.position, hitpose.rotation);
                SessionOrigin.MakeContentAppearAt(content, hitpose.position, m_Rotation);
                spawnedObject = 1;
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
