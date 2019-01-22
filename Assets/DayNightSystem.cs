using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : MonoBehaviour {

	public float speed=1;
	public float cloudSpeed=1;
	public float starsSpeed=0.5f;
	public float currentTime = 0.0f;
	public Light sun;
	public GameObject clouds;
	public GameObject stars;
	
	void Update () {
		currentTime += Time.deltaTime*speed;
		if (currentTime >= 24f) 
			currentTime %= 24f;
		
		
		UpdateSun();
		
		UpdateStars();

	}

	void LateUpdate(){
		
		transform.position = Camera.main.transform.position;
		
		UpdateClouds();
	}

	void UpdateSun(){
		var rotX = -(90f+currentTime*15f);
		sun.transform.eulerAngles = sun.transform.right*rotX;
		if (rotX >= 360f) 
			rotX %= 360f;
		
		var isNight = currentTime >= 18f || currentTime <= 5.5f;
	
		if (isNight) 
			sun.intensity = Mathf.MoveTowards(sun.intensity,0.0f,Time.deltaTime*speed*10);
		else 
			sun.intensity = Mathf.MoveTowards(sun.intensity,1.0f,Time.deltaTime*speed*10);
	}

	void UpdateStars(){
	
		Color currentColor;
		var isNight = currentTime >= 18 || currentTime <= 5.5f;
		
		stars.transform.Rotate(Vector3.forward*starsSpeed*speed*Time.deltaTime);
		if (isNight){
			stars.gameObject.SetActive(true);
			
		}else{
			currentColor = stars.GetComponent<Renderer>().material.color;
			stars.gameObject.SetActive(false);
		}
	
	}

	void UpdateClouds(){
		clouds.transform.Rotate(Vector3.forward*cloudSpeed*speed*Time.deltaTime);
	}

}
