using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBox : MonoBehaviour
{
        [Header("References")]
        public Vector3 teleTrk;
        public Camera cam;
        [SerializeField]
        public GameObject toTrkTruck;
        
        
    // Update is called once per frame
    void Awake() {
    
        cam = Camera.main;
        toTrkTruck = GameObject.Find("TurkuTruckTele");
        teleTrk = toTrkTruck.transform.position;
    }
    void FixedUpdate()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began) {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(pos);

            //Checks what box you touched and places it in the truck. The tele
            //has a hitbox which checks if it's correct a correct one
            if(Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Package")) {
                
                if(hit.collider.name.Contains("Turku") && hit.transform.gameObject != null){

                    hit.collider.gameObject.transform.position = teleTrk;
                    hit.collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (0,0,100);
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(0f,0f,100f * Time.deltaTime);
                }
                if(hit.collider.name.Contains("Espoo") && hit.transform.gameObject != null){

                    hit.collider.gameObject.transform.position = teleTrk;
                    hit.collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (0,0,100);
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(0f,0f,100f * Time.deltaTime);
                    
                }
                if(hit.collider.name.Contains("Helsinki") && hit.transform.gameObject != null){

                    hit.collider.gameObject.transform.position = teleTrk;
                    hit.collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (0,0,100);
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(0f,0f,100f * Time.deltaTime);

                }
            }
        }
        }
    }
}