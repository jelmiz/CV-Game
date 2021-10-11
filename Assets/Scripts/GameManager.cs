using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    
    
    
    [Header("Overall stuff")]
     public float restartDelay = 1f;
    public Button restart;
     public GameObject loadScreen;
    bool peliOhi = false;
    [Header("Lenttis")]
    public InputField punainenUI;
    public Text punainen;
    public Text sininen;
    public InputField sininenUI;
    public GameObject completeLevelUI;
   
   
    [Header("Scan")]
    public Text paketitOhi;
    public Text paketitOikein;
    public Text paketitWrong;
    
    public GameObject scanFailUI;
    [Header("Restaurant")]
    public GameObject textChoice1;
    public int opinion = 1;
    public GameObject imgGood;
    public GameObject imgNeutral;
    public GameObject imgBad;
    public GameObject nameInputUI;
    public void EndGame (){
        if (peliOhi == false) {
            peliOhi = true;
            Invoke("Restart", restartDelay );
        }
        
    }

    public void Restart() {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void Credits() {
        SceneManager.LoadScene("Credits");
    }
    public void ExitGame() {
        Application.Quit();
    }
    public void LevelComplete() {
        completeLevelUI.SetActive(true);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void loadingScreenToNextLevel(){
        loadScreen.SetActive(true);
        Invoke("NextLevel", 5f);
    }
    public void sininenMin() {
    int sininenLuku = int.Parse(sininen.text);
    if(sininenLuku == 0) {
        sininenLuku = 0;
    }
    else {
    sininenLuku = sininenLuku - 1;
    }
    sininen.text = sininenLuku.ToString();
    
    }
    public void punainenMin() {
    int punainenLuku = int.Parse(punainen.text);
    if(punainenLuku == 0) {
        punainenLuku = 0;
    }
    else{
    punainenLuku = punainenLuku - 1;
    }
    punainen.text = punainenLuku.ToString();
    
    }
    public void LopetaLenttis() {
        int punainenLuku = int.Parse(punainen.text);
        int sininenLuku = int.Parse(sininen.text);
        if(punainenLuku == 0 && sininenLuku == 0) {
            loadingScreenToNextLevel();
        }
    }
    public void mainMenuun() {
        loadScreen.SetActive(true);
        Invoke("MainMenu", 3f);
    }
    public void toCredits() {
        loadScreen.SetActive(true);
        Invoke("Credits", 3f);
    }
    public void PakettiOikein() {
        int paketitOikeinNro = int.Parse(paketitOikein.text);
    
    
    paketitOikeinNro = paketitOikeinNro + 1;
    
    paketitOikein.text = paketitOikeinNro.ToString();
    
    }
    public void PakettiOhi() {
        int paketitOhiNro = int.Parse(paketitOhi.text);
    
    paketitOhiNro = paketitOhiNro + 1;
    
    paketitOhi.text = paketitOhiNro.ToString();
    
    }
    public void PakettiVaara() {
        int paketitWrongNro = int.Parse(paketitWrong.text);
    
    
    paketitWrongNro = paketitWrongNro + 1;
    
    paketitWrong.text = paketitWrongNro.ToString();
    
    }
    public void ScanFail() {
        int paketitOhiLuku = int.Parse(paketitOhi.text);
        int paketitWrongLuku = int.Parse(paketitWrong.text);
        int paketitOikeinLuku = int.Parse(paketitOikein.text);
        if(paketitOhiLuku == 5 || paketitWrongLuku == 3) {
            scanFailUI.SetActive(true);
        }
        if(paketitOikeinLuku == 5) {
            loadingScreenToNextLevel();
        }
    }
    public void GoodBtn() {
        opinion++;
    }
    public void BadBtn() { 
        opinion--;  
    }
    public void SetImg() {
        if(opinion == 1) {
            imgNeutral.SetActive(true);
            imgBad.SetActive(false);
            imgGood.SetActive(false);
        }
        if(opinion > 1) {
            imgNeutral.SetActive(false);
            imgBad.SetActive(false);
            imgGood.SetActive(true);
        }
        if(opinion < 1) {
            imgNeutral.SetActive(false);
            imgBad.SetActive(true);
            imgGood.SetActive(false);
        }
    }
    public void changeName(InputField nimi) {
        GameObject player = GameObject.Find("Player");
        if(nimi == null) {
            player.name = "The one who has no name";
        }else{
        player.name = nimi.text;
        }
    }
    public void closeNameInput() {
        nameInputUI.SetActive(false);
    }
    
}
