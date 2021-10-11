using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ExampleClass : MonoBehaviour
{
    [Header("Refernced objects")]
    public GameObject laatta;
    public Button nappiS;
    public Button nappiP;
    public Button nappiV;
    public List<string> laatat;
    public GameManager gameManager;
    [Header("Bools")]
    public bool buttonS;
    public bool buttonP;
    public bool buttonV;
    
    
    void Awake()
    {
        laatat = new List<string>();
        Button btnP = nappiP.GetComponent<Button>();
        btnP.onClick.AddListener(vaihdaTrueP);

        Button btnS = nappiS.GetComponent<Button>();
        btnS.onClick.AddListener(vaihdaTrueS);

        Button btnV = nappiV.GetComponent<Button>();
        btnV.onClick.AddListener(vaihdaTrueV);

    }


    void LateUpdate()
    {
        //Win Condition
        if(laatat.Count == 9) {
            gameManager.GetComponent<GameManager>().loadingScreenToNextLevel();
        }
        //More than 1 button can't be active at the same time
        if (buttonS == true) {
            buttonP = false;
            buttonV = false;
        }
         if (buttonP == true) {
            buttonS = false;
            buttonV = false;
        }
         if (buttonV == true) {
            buttonP = false;
            buttonS = false;
        }
        // Handle screen touches.
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;

            //Only one touch
            if(Input.GetTouch(0).phase == TouchPhase.Began){
            
            //What the touch is hitting
            if(Physics.Raycast(raycast, out hitInfo)) {

                if(hitInfo.collider.CompareTag("Laatta")){

                
                Paint(hitInfo);

                    //Adds into a list which contains rooftiles that are currently blue
                    if(!laatat.Contains(hitInfo.collider.name) && buttonS == true){
                        
                    laatat.Add(hitInfo.collider.name);
                    }
                    //Removes from a list if a rooftile that was blue was changed into red or green
                    if(laatat.Contains(hitInfo.collider.name) && buttonS == false) {
                    laatat.Remove(hitInfo.collider.name);
                    } 
            }
        }
    }
    }
    }
    //Change color buttons
    private void vaihdaTrueP() {
        buttonP = true;
        buttonS = false;
        buttonV = false;
        
    }
    private void vaihdaTrueS() {
        buttonP = false;
        buttonS = true;
        buttonV = false;
        
    }
    private void vaihdaTrueV() {
        buttonP = false;
        buttonS = false;
        buttonV = true;
        
    }
    //Checks if button is true and if yes uses another method to change color
    private void Paint(RaycastHit laatta) 
    {     
        if(buttonS == true) {
            vaihdaColorSininen(laatta);
        }
        if(buttonP == true) {
            vaihdaColorPunainen(laatta);
        }
        if(buttonV == true) {
            vaihdaColorVihrea(laatta);
        }
    }
    //Change color of a rooftile
    private void vaihdaColorSininen(RaycastHit laatta)
    {
        var laattaRenderer = laatta.collider.GetComponent<Renderer>();
        laattaRenderer.material.SetColor("_Color", Color.blue); 
    }
    private void vaihdaColorPunainen(RaycastHit laatta)
    {
        if(laatta.collider.CompareTag("Laatta")) {
        var laattaRenderer = laatta.collider.GetComponent<Renderer>();
        laattaRenderer.material.SetColor("_Color", Color.red);
        }
    }
    private void vaihdaColorVihrea(RaycastHit laatta)
    { 
        var laattaRenderer = laatta.collider.GetComponent<Renderer>();
        laattaRenderer.material.SetColor("_Color", Color.green);   
    }
}
