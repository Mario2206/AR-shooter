using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    ARRaycastManager m_RaycastManager;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField]
    GameObject spawnablePrefab;

    GameObject spawnedObject;



    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        if (m_RaycastManager.Raycast(touch.position, m_Hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {

            if (touch.phase == TouchPhase.Began)
            {
                SpawnPrefab(m_Hits[0].pose.position);
            }
            else if (touch.phase == TouchPhase.Moved && spawnedObject != null ) {
                spawnedObject.transform.position = m_Hits[0].pose.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }

        }
    }

    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }

}
