using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
	// Game:
	//		Controller that handles game data.

	
	// Game variables
	private Wand wand1;
	private Wand wand2;
	private Map map;
	
	// Game variables
	public GameObject wandUI1;
	public GameObject wandUI2;

	// UI variables
	private Text wandUI1money;
	private Text wandUI2money;
	private Text wandUI1power;
	private Text wandUI2power;

	// Game tick variables
	private float time;
	private float tickTime = 1f;
	private int tick;


	// Use this for finding components
	void Awake() {
		map = transform.Find("Map").gameObject.GetComponent<Map>();
		wand1 = transform.Find("Wand1").gameObject.GetComponent<Wand>();
		wand2 = transform.Find("Wand2").gameObject.GetComponent<Wand>();

		wandUI1money = wandUI1.transform.Find("MValue").gameObject.GetComponent<Text>();
		wandUI1power = wandUI1.transform.Find("PValue").gameObject.GetComponent<Text>();
		wandUI2money = wandUI2.transform.Find("MValue").gameObject.GetComponent<Text>();
		wandUI2power = wandUI2.transform.Find("PValue").gameObject.GetComponent<Text>();
	}

	// Use this for initialization
	void Start() {
		time = 0;
	}
	
	// Update is called once per frame
	void Update() {
		time += Time.deltaTime;
		if(time > tickTime) GameTick();
	}

	// Game tick
	void GameTick() {
		time -= tickTime;
		tick += 1;
		
		wand1.Pop();
		wand2.Pop();
		
		map.GetPlace(wand1.GetPosition()).TakeOver(wand1);
		map.GetPlace(wand2.GetPosition()).TakeOver(wand2);
		map.UpdateMap();

		for(int y = 0; y < map.GetMapSize(); y++) {
			for(int x = 0; x < map.GetMapSize(); x++) {
				map.GetPlace(x, y).Generate();
			}
		}
		UpdateCanvasUI();
	}

	// Update cavnasUI each tick
	void UpdateCanvasUI() {
		String sm1 = wand1.GetMoney().ToString();
		Debug.Log(sm1);
		wandUI1money.text = sm1;
		wandUI1power.text = wand1.GetManPower().ToString();

		wandUI2money.text = wand2.GetMoney().ToString();
		wandUI2power.text = wand2.GetManPower().ToString();
	}
}
