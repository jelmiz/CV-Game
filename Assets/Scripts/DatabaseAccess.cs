using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;
using SimpleJSON;
public class DatabaseAccess : MonoBehaviour
{
    MongoClient client = new MongoClient("mongodb+srv://testUser:testPassword@cluster0.u49o9.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;
    // Start is called before the first frame update
    void Start()
    {

        database = client.GetDatabase("LennotDB");
        collection = database.GetCollection<BsonDocument>("LennotCollection");
        database.DropCollection("LennotCollection");
        SaveLennotToDataBase("MrPine", 101);
        SaveLennotToDataBase("joku", 200);
    }
 public async void SaveLennotToDataBase(string userName, int score){
     var document = new BsonDocument{ { userName, score}};
     await collection.InsertOneAsync(document);
 }

 public async Task<List<HighScore>> GetScoresFromDataBase(){
     var allScoresTask = collection.FindAsync(new BsonDocument());
     var scoresAwaited = await allScoresTask;

     List<HighScore> highscores = new List<HighScore>();
     foreach(var score in scoresAwaited.ToList()){
         highscores.Add(Deserialize(score.ToString()));
        
     }
     return highscores;
 }
    private HighScore Deserialize(string rawJson) {
        {
            var highScore = new HighScore();
            var stringWithoutID = rawJson.Substring(rawJson.IndexOf("),") + 4);
            var username = stringWithoutID.Substring(0, stringWithoutID.IndexOf(":") - 2);
            var score = stringWithoutID.Substring(stringWithoutID.IndexOf(":") + 2, stringWithoutID.IndexOf("}")-stringWithoutID.IndexOf(":") - 3);
            highScore.UserName = username;
            highScore.Score = Convert.ToInt32(score);
            return highScore;
        }
    }

 public class HighScore {

     public string UserName {get; set;}

     public int Score {get; set;}
 }
 /*void GetData() => StartCoroutine(GetData_Coroutine());
    IEnumerator GetData_Coroutine()
    {
        string uri = "http://api.aviationstack.com/v1/flights?access_key=c0fadea6e3e07932e3340f46239317a0";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError){
                Debug.Log(request.error);
            }
            else{
                int i = 0;
                
                //outputArea.text = request.downloadHandler.text;
                JSONNode itemsData = JSON.Parse(request.downloadHandler.text);
                System.DateTime lento = itemsData["data"][i]["flight_date"];
                
                
                while (i<=30) {
                    
                }*/
}
