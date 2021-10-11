using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.Networking;
public class DisplayLento : MonoBehaviour
{
    private InputField lentoOutput;
    private DatabaseAccess databaseAccess;
    private System.DateTime theDate;
    // Start is called before the first frame update
    void Start()
    {
        theDate = System.DateTime.Now;
        lentoOutput = GameObject.Find("Output").GetComponent<InputField>();
        databaseAccess = GameObject.FindGameObjectWithTag("DatabaseAccess").GetComponent<DatabaseAccess>();
        Debug.Log(databaseAccess);
        Debug.Log(lentoOutput);
        GameObject.Find("Data").GetComponent<Button>().onClick.AddListener(GetData);
        Invoke("DisplayLennotInTextMesh", 2.0f);
        
    }
    void GetData() => StartCoroutine(GetData_Coroutine());
    // Update is called once per frame
    IEnumerator GetData_Coroutine()
    {
        lentoOutput.text = "Loading...";
        string uri = "http://api.aviationstack.com/v1/flights?access_key=c0fadea6e3e07932e3340f46239317a0";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError){
                lentoOutput.text = request.error;
            }
            else{
                int i = 0;
                
                //outputArea.text = request.downloadHandler.text;
                JSONNode itemsData = JSON.Parse(request.downloadHandler.text);
                System.DateTime lento = itemsData["data"][i]["flight_date"];
                Debug.Log(itemsData["data"].ToString());
                Debug.Log(itemsData["data"][0]["departure"]["airport"].ToString());
                Debug.Log(theDate);
                Debug.Log(lento.ToString("yyyy-MM-dd"));
                Debug.Log(lento + "Lento");
                Debug.Log(theDate + "DaTE");
                Debug.Log(itemsData["data"][i]["flight_date"].ToString());
                lentoOutput.text = "Flights\n";
                while (i<=30) {
                    //if(theDate>lento) {
                        
                        lentoOutput.text += "Date: " + itemsData["data"][i]["flight_date"].ToString() + " Departure: " + itemsData["data"][i]["departure"]["airport"].ToString() 
                        + " (" + itemsData["data"][0]["departure"]["iata"].ToString() + ")" + " Destination: " + itemsData["data"][i]["arrival"]["airport"].ToString() + " (" + itemsData["data"][0]["arrival"]["iata"].ToString() + ")" + "\n";
                        Delay();
                    //}
                        Debug.Log(itemsData["data"][i]["flight_date"].ToString());
                        i++;
                    Delay();
                }

                //flight = item
                //itemsData["data"][0]["iata_code"].ToString(); näyttää saadun tiedot API
                //lentoOutput.text = "Lähtöpaikka: " + itemsData["data"][0]["departure"]["airport"].ToString() +" " + itemsData["data"][0]["departure"]["iata"].ToString() + "\nLähtöaika: " + itemsData["data"][0]["departure"]["scheduled"].ToString()
                //+ "\nSaapumispaikka: " + itemsData["data"][0]["arrival"]["airport"].ToString() +" " + itemsData["data"][0]["arrival"]["iata"].ToString() + "\nLähtöaika: " + itemsData["data"][0]["arrival"]["scheduled"].ToString();

                }
        }
    }
   // void myFunction(//String callback){
       // return JsonUtility.FromJson<GetScript>
   // }
   public IEnumerator Delay() {
       yield return new WaitForSeconds(2f); 
   }
    private async void DisplayLennotInTextMesh() {
        var task = databaseAccess.GetScoresFromDataBase();
        
         var result = await task;
         var output = "";
         foreach(var score in result) {
             output += "Score: " + score.Score;
         }
        lentoOutput.text = output;
    }
}
