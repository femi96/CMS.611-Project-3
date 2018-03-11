using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	// Game:
	//		Controller that handles game data.


	// Game variables
	private IWand wand1;
	private IWand wand2;
	private IMap map;

	// Game tick variables
	private float time;
	private float tickTime = 1f;
	private int tick;


	// Use this for finding components
	void Awake() {
		wand1 = transform.Find("Wand1").gameObject.GetComponent<Wand>();
		wand2 = transform.Find("Wand2").gameObject.GetComponent<Wand>();
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
		Debug.Log(tick);
		for(int y = 0; y < map.getMapSize(); y++) {
			for(int x = 0; x < map.getMapSize(); x++) {
				map.getPlaceGrid () [x, y].Generate();
			}
		}
	}
}
