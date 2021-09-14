using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickController : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private GameObject spotlight;

    [SerializeField] private GameObject placeableObject;
    public int index = 0;

    private Texture cookie;

    private void Start()
    {
        cookie = spotlight.GetComponent<Light>().cookie;
    }

    // Update is called once per frame
    void Update()
    {
        //shoot a ray from the cam to mouse position
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        spotlight.transform.localRotation = Quaternion.Euler(90f, 0, index * 22.5f);

        //returns true if ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            spotlight.transform.position = new Vector3(hit.point.x, spotlight.transform.position.y, hit.point.z);

            if (Input.GetMouseButtonDown(0) && !PauseMenu.GameIsPaused && !PauseMenu.GameIsOver)
            {
                Instantiate(placeableObject);
                placeableObject.transform.position = hit.point;
                placeableObject.transform.localRotation = Quaternion.Euler(0f, -(index * 22.5f - 45f), 0f);
                placeableObject.SetActive(true);
            }

            if (Input.GetMouseButton(1) && !PauseMenu.GameIsPaused && !PauseMenu.GameIsOver)
            {
                spotlight.GetComponent<Light>().color = Color.red;
                spotlight.GetComponent<Light>().cookie = null;
                if (hit.collider.CompareTag("Wall"))
                {
                    hit.collider.gameObject.SetActive(false);
                }
            }
            else
            {
                spotlight.GetComponent<Light>().color = Color.white;
                spotlight.GetComponent<Light>().cookie = cookie;
            }

            //scroll up
            if (Input.mouseScrollDelta.y > 0 && !Input.GetMouseButton(1))
            {
                index++;
                if (index > 8) { index = 1; }
            }

            //scroll down
            if (Input.mouseScrollDelta.y < 0 && !Input.GetMouseButton(1))
            {
                index--;
                if (index < 0) { index = 7; }
            }


        }
    }
}
