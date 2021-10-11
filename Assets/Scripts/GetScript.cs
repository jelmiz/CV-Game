using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;


public class GetScript : MonoBehaviour
{
    public string flightDate;
    public string flightloc;
    public System.DateTime theDate;
    public string parsedDate;
   
    //string Access = "access_key=c0fadea6e3e07932e3340f46239317a0";
    InputField outputArea;
    void Start()
    {
        theDate = System.DateTime.Now;
        outputArea = GameObject.Find("Output").GetComponent<InputField>();
        GameObject.Find("Data").GetComponent<Button>().onClick.AddListener(GetData);
    }

    void GetData() => StartCoroutine(GetData_Coroutine());
    IEnumerator GetData_Coroutine()
    {
        outputArea.text = "Loading...";
        string uri = "http://api.aviationstack.com/v1/flights?access_key=c0fadea6e3e07932e3340f46239317a0";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError){
                outputArea.text = request.error;
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
                outputArea.text = "Tulevat lennot\n";
                while (i<=30) {
                    if(theDate>lento) {
                        
                        outputArea.text += "Lähtöpäivä: " + itemsData["data"][i]["flight_date"].ToString() + " Lähtöpaikka: " + itemsData["data"][i]["departure"]["airport"].ToString() 
                        + " (" + itemsData["data"][0]["departure"]["iata"].ToString() + ")" + " Kohde: " + itemsData["data"][i]["arrival"]["airport"].ToString() + " (" + itemsData["data"][0]["arrival"]["iata"].ToString() + ")" + "\n";
                        Delay();
                    }
                        Debug.Log(itemsData["data"][i]["flight_date"].ToString());
                        i++;
                    Delay();
                }

                //flight = item
                //itemsData["data"][0]["iata_code"].ToString(); näyttää saadun tiedot API
                //outputArea.text = "Lähtöpaikka: " + itemsData["data"][0]["departure"]["airport"].ToString() +" " + itemsData["data"][0]["departure"]["iata"].ToString() + "\nLähtöaika: " + itemsData["data"][0]["departure"]["scheduled"].ToString()
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
}
