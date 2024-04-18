using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Shooter : MonoBehaviour
{

    public GameObject bullet;

    public float bulletSpeed = 100;


    [SerializeField]
    ARRaycastManager m_RaycastManager;

    [Space, SerializeField]
    private AudioSource shootAudioSource;

    private bool isShooting = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        if(touch.phase == TouchPhase.Began && !isShooting)
        {
            Shoot(touch);
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            isShooting = false;
        }
    }

    private void Shoot(Touch touch)
    {
        RaycastHit hit;
        if(Physics.Raycast(gameObject.GetComponent<Camera>().ScreenPointToRay(touch.position), out hit)) {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                hit.transform.gameObject.GetComponent<Enemy>().OnKill();
                isShooting = true;
            }
        }
    }
}
