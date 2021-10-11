using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public List<GameObject> beltObject;
    public GameManager gameManager;
    public Vector3 teleTrk;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= beltObject.Count -1; i++){
            if(beltObject[i] != null){
            beltObject[i].GetComponent<Rigidbody>().velocity = speed *direction * Time.deltaTime;
            }
            
            else {
                beltObject.Remove(beltObject[i]);
            }
        }
       gameManager.GetComponent<GameManager>().ScanFail();
    }
    private void OnCollisionEnter(Collision other) {
        beltObject.Add(other.gameObject);
    }
    public void OnCollisionExit(Collision other) {
        beltObject.Remove(other.gameObject);
    }
}
