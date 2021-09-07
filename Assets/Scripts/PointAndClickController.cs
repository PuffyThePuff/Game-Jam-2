using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClickController : MonoBehaviour
{
    public Camera cam;

    [SerializeField] private Transform spotlight;

    [SerializeField] private List<GameObject> placeableObjects;

    private void Start()
    {
        spotlight = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //shoot a ray from the cam to mouse position
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //returns true if ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            spotlight.position = new Vector3(hit.point.x, spotlight.position.y, hit.point.z);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(placeableObjects[0]);
                placeableObjects[0].transform.position = (new Vector3(hit.point.x, 0, hit.point.z));
            }
        }
    }
}
