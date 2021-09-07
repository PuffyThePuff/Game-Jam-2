using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClickController : MonoBehaviour
{
    public Camera cam;
    private Transform spotlight;

    [SerializeField] private List<GameObject> placeableObjects;
    [SerializeField] private List<Texture> cookieList;
    private int index = 0;

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
                Instantiate(placeableObjects[index]);
                placeableObjects[index].transform.position = hit.point;
            }

            //scroll up
            if (Input.mouseScrollDelta.y > 0)
            {
                index++;
                index = Mathf.Clamp(index, 0, placeableObjects.Count - 1);
            }

            //scroll down
            if (Input.mouseScrollDelta.y < 0)
            {
                index--;
                index = Mathf.Clamp(index, 0, placeableObjects.Count - 1);
            }
        }
    }
}
