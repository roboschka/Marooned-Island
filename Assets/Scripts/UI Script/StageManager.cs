using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {

	[SerializeField]
	private GameObject popUp;
	[SerializeField]
	private Animator popUpAnimator;
	public GameObject crossHair;
	//public EnemyManager enemyManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ShowCanvas() {
		popUp.SetActive(true);
		crossHair.SetActive(false);
		//popUpAnimator.Play("Next Stage Manager");
	}
}
