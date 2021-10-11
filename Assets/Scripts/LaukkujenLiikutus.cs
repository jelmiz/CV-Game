using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaukkujenLiikutus : MonoBehaviour
{
        
        
        private Vector3 dis;
        [Header("Referenced objects")]
        public string draggingTag;
        public Camera cam;
        public GameManager gameManager;
        
        private float posX;
        private float posY;
        [Header("Booleans")]
        public bool touched = false;
        public bool dragging = false;
        private Transform toDrag;
        private Rigidbody toDragRigidbody;
        private Vector3 previousPosition;
    
    void Awake() {
    }
    void FixedUpdate()
    {
        gameManager.GetComponent<GameManager>().LopetaLenttis(); 
        
          //TOUCH CONTROLS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began) {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(pos);

            if(Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Laukku")) {
                toDrag = hit.transform;
                previousPosition = toDrag.position;
                toDragRigidbody = toDrag.GetComponent<Rigidbody>();
                Debug.Log(toDragRigidbody);

                dis = cam.WorldToScreenPoint(previousPosition);
                posX = Input.GetTouch(0).position.x - dis.x;
                posY = Input.GetTouch(0).position.y -dis.y;

                SetDraggingProperties(toDragRigidbody);
                touched = true;
                
            }
            if(Physics.Raycast(ray, out hit) && !hit.collider.CompareTag("Laukku")) {
                toDrag = null;
                previousPosition = new Vector3(0f,0f,0f);
                posX = Input.GetTouch(0).position.x - dis.x;
                posY = Input.GetTouch(0).position.y -dis.y;
            }
        }

        if (touch.phase == TouchPhase.Moved ) {
            dragging = true;

            float posXNow = Input.GetTouch(0).position.x - posX;
            float posYNow = Input.GetTouch(0).position.y - posY;
            Vector3 curPos = new Vector3(posXNow, posYNow, dis.z);

            Vector3 worldPos = cam.ScreenToWorldPoint(curPos) - previousPosition;
            worldPos = new Vector3(worldPos.x, worldPos.y, 0.0f);

            toDrag.GetComponent<Rigidbody>().velocity = worldPos / (Time.deltaTime *10);

            previousPosition = toDrag.position;
        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
            dragging = false;
            touched = false;
            previousPosition = new Vector3(0.0f, 0.0f, 0.0f);
            SetFreeProperties(toDrag.GetComponent<Rigidbody>());
        }
    }
        }
    private void SetDraggingProperties(Rigidbody rb) {
        rb.isKinematic = false;
        rb.useGravity = false;
        rb.drag = 15;
    }
    private void SetFreeProperties(Rigidbody rb) {
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.drag = 1;
    }
}

