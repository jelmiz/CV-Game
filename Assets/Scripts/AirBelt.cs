using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBelt : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public List<GameObject> beltObject;

    void Update()
    {
        //If objects on the belt, adds velocity to them until they
        //are not on the belt anymore
        for(int i = 0; i <= beltObject.Count -1; i++){
            if(beltObject[i] != null){
            beltObject[i].GetComponent<Rigidbody>().velocity = speed *direction * Time.deltaTime;
            }
            
            else {
                beltObject.Remove(beltObject[i]);
            }
        }
    }
    //Checks if object are on the belt or not.
    private void OnCollisionEnter(Collision other) {
        beltObject.Add(other.gameObject);
    }
    public void OnCollisionExit(Collision other) {
        beltObject.Remove(other.gameObject);
    }
}
