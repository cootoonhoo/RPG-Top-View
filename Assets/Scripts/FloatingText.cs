using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool active;
    public GameObject GameObj;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show(){
        active = true;
        lastShown = Time.time;
        GameObj.SetActive(active);
    }

    public void Hide(){
        active = false;
        GameObj.SetActive(active);
    }
    public void UpdateFlotingText(){
        if(!active){
            return;
        }
        if(Time.time - lastShown > duration){
            Hide();
        }
        GameObj.transform.position += motion * Time.deltaTime;
    }
}
