using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSlider : MonoBehaviour
{

	public float hp = 1000; 
	private float totalHp = 1000;//总血量
	public Slider endSlider;
    public AudioSource attackedAudio;
    // Start is called before the first frame update
    void Start()
    {
        attackedAudio = GameObject.Find("Attacked_audio").GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage){
        attackedAudio.Play();
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
