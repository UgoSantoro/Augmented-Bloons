using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ARTapPlaceObject : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    private GameObject spawnedObject;
    private ARRaycastManager _aRRaycastManager;
    private Vector2 touchposition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _aRRaycastManager = GetComponent<ARRaycastManager>();
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

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(gameObjectToInstantiate, hitpose.position, hitpose.rotation);
            } /*else
            {
                spawnedObject.transform.position = hitpose.position;
                spawnedObject.transform.rotation = hitpose.rotation;
            }*/
        }
    }
}
