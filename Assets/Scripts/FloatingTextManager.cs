using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Biblioteca para incluirmos o texto

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>(); // Criando uma lista de textos provenientes do script que acabamos de criar

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float durantion){
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.GameObj.transform.position = Camera.main.WorldToScreenPoint(position); //Transformando o Wolrd Space em screen space pra ficar mais fácil de usar na UI
        floatingText.motion = motion;
        floatingText.duration = durantion;

        floatingText.Show();

        // Atribuindo as características para o texto, garntindo que ela estão rebendo os atributos certos;
    }
    private FloatingText GetFloatingText(){
        FloatingText txt = floatingTexts.Find(t => !t.active);      // Método para encontrarmos um texto flutante não visivel

        if (txt == null){                                           // Criando um texto caso não encontremos um 
            txt = new FloatingText();                               // Criamos o novo texto
            txt.GameObj = Instantiate(textPrefab);                  //Passamos o que vai ter escrito
            txt.GameObj.transform.SetParent(textContainer.transform); // Informamos onde ele deve aparecer
            txt.txt = txt.GameObj.GetComponent<Text>();

            floatingTexts.Add(txt);                                 //Adicionar o texto que criamos dentro da lista já criada

        }
        return txt;                                                  // Se acharmos um, a gente retorna ele, caso contrário devemos criar um
    }
    private void Update(){
        foreach(FloatingText txt in floatingTexts){
            txt.UpdateFlotingText();
        }
        // Fazendo o Update do floating text para cada texto flutuante que criamos ou for criado pelo script
    }
}
