using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRed : MonoBehaviour
{
    public float force = 700f;
    public float delay; 
    private Vector3 position;
    
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start() {
    position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, gameObject.transform.position.z);
    
    }
    void Awake() {
        Invoke("SpawnNext", Random.Range(3.0f, 6.0f));
    }
    
    void SpawnNext() {
        GameObject uusi = Instantiate(gameObject);
        uusi.transform.position = new Vector3(position.x, position.y, position.z);
    }
    
    void FixedUpdate()
    {
        //rb.AddForce(force *Time.deltaTime, 0, 0);
        
    }
    public void setForce() {
        force = 0;
    }
    public void palautaForce() {
        force = 800f;
    }
}
