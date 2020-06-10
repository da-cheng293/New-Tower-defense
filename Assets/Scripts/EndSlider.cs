using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSlider : MonoBehaviour
{

	public float hp = 1000; 
	private float totalHp = 1000;//总血量
	public Slider endSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(float damage){
        if (hp <= 0) return;
    	hp -= damage;
    	endSlider.value = (float)hp / totalHp;
    	if(hp <= 0){
    		GameManager.Instance.Failed ();
    	}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
