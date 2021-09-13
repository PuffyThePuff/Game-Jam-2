using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickController : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private GameObject spotlight;

    [SerializeField] private List<GameObject> placeableObjects;
    [SerializeField] private List<Texture> cookieList;
    public int index = 0;

    private void Start()
    {

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
            spotlight.transform.position = new Vector3(hit.point.x, spotlight.transform.position.y, hit.point.z);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(placeableObjects[index]);
                placeableObjects[index].transform.position = hit.point;
                placeableObjects[index].SetActive(true);
            }

            //scroll up
            if (Input.mouseScrollDelta.y > 0)
            {
                index++;
                index = Mathf.Clamp(index, 0, placeableObjects.Count - 1);
                spotlight.GetComponent<Light>().cookie = cookieList[index];
            }

            //scroll down
            if (Input.mouseScrollDelta.y < 0)
            {
                index--;
                index = Mathf.Clamp(index, 0, placeableObjects.Count - 1);
                spotlight.GetComponent<Light>().cookie = cookieList[index];
            }
        }
    }
}
