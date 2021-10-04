using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake(){
        instance = this;
        if(GameManager.instance != null){
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

        
    }
    //Recursos
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weponPrices;
    public List<int> exTable;

    //Referências
    public PlayerCtrl player;

    //Programação
    public int gold;
    public int experience;

    // Lógica de salvar o jogo

    public void SaveState(){
        string s = "";
        s += "0" + "|";                     // Skin do player
        s += gold.ToString() + "|";         // Gold
        s += experience.ToString() + "|";   // Xp 
        s += "0";                           // Wepon Level

        Debug.Log("SaveState");
    }
    public void LoadState(Scene s, LoadSceneMode mode){
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin
        gold = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Wepon Level
        Debug.Log("LoadState");
    }
}
