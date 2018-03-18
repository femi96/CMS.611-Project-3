using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
	// Game:
	//		Controller that handles game data.

	
	// Game variables
	public GameState gameState;

	private IWand wand1;
	private IWand wand2;
	private IMap map;
	
	// UI variables
	public GameObject wandUI1;
	public GameObject wandUI2;

	public GameObject pausedUI;

	private Text wandUI1money;
	private Text wandUI2money;
	private Text wandUI1power;
	private Text wandUI2power;

	// Game tick variables
	private float time;
	private float tickTime = 1f; // This is in seconds
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
		ChangeGameState(GameState.Paused);

		time = 0;
		GameTick();
	}
	
	// Update is called once per frame
	void Update() {

		time += Time.deltaTime;
		if(time > tickTime) GameTick();

		if(Input.GetKeyDown(KeyCode.O)) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
		if(Input.GetKeyDown(KeyCode.P)) {
			if(gameState == GameState.Playing) { ChangeGameState(GameState.Paused); } else
			if(gameState == GameState.Paused) { ChangeGameState(GameState.Playing); }
		}
	}

	// Game tick
	private void GameTick() {
		time -= tickTime;
		tick += 1;
		
		wand1.Pop();
		wand2.Pop();
		
		WandTakeOver(wand1);
		WandTakeOver(wand2);

		if(tick % 3 == 0) { // This is generation rate (currently every frame because of || true)
			for(int y = 0; y < map.GetMapSize(); y++) {
				for(int x = 0; x < map.GetMapSize(); x++) {
					map.GetPlace(x, y).Generate();
				}
			}
		}

		map.UpdatePlaces();
		map.UpdateMap();

		UpdateCanvasUI();
	}

	// Wand takeover position
	private void WandTakeOver(IWand wand) {
		
		IPlace place = map.GetPlace(wand.GetPosition());
		if(place.GetOwner() != wand) {
			if(place.TakeOver(wand)) {
				place.SetOwner(wand);
			}
		}
	}

	// Update cavnasUI each tick
	private void UpdateCanvasUI() {
		wandUI1money.text = wand1.GetMoney().ToString();
		wandUI1power.text = wand1.GetPower().ToString();

		wandUI2money.text = wand2.GetMoney().ToString();
		wandUI2power.text = wand2.GetPower().ToString();
	}

	private void ChangeGameState(GameState newState) {
		gameState = newState;

		if(gameState == GameState.Playing) {
			Time.timeScale = 1;
		} else {
			Time.timeScale = 0;
		}

		pausedUI.SetActive(gameState == GameState.Paused);
	}
}
