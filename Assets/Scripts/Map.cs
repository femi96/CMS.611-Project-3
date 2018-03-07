using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, IMap {
	// Map:
	//		Controller that handles wand data and player input.


	// Map variables
	private int mapSize = 10;
	private IPlace[,] placeGrid;			// Grid mapping location to place data @ location
	private GameObject[,] placeGOGrid;	// Grid mapping location to place gameobject


	// Use this for initialization
	void Start() {
		
		// Create placeGrid as new places
		placeGrid = new IPlace[mapSize, mapSize];
		for(int y = 0; y < mapSize; y++) {
			for(int x = 0; x < mapSize; x++) {
				placeGrid[x, y] = new PizzaPlace();
				UpdateGO(x, y);
			}
		}
	}
	
	// Update is called once per frame
	void Update() {}

	// Get place at x, y from place data
	public IPlace GetPlace(int x, int y) {
		if(ValidXY(x,y)) return placeGrid[x, y];
		else return null;
	}

	// Get place at vector2 location from place data
	public IPlace GetPlace(Vector2 v) {
		int x = Mathf.RoundToInt(v.x);
		int y = Mathf.RoundToInt(v.y);
		return GetPlace(x, y);
	}


	public void SetPlaceOwner(int x, int y, Wand newOwner) {
		if(ValidXY(x, y)) {
			placeGrid[x, y].SetOwner(newOwner);
			UpdateGO(x, y);
		}
	}

	// Update GO at x, y from place data
	private void UpdateGO(int x, int y) {
		IPlace place = GetPlace(x, y);

	}

	// Return if x, y are valid coordinates in the grid
	private bool ValidXY(int x, int y) {
		return (x > 0 && x < mapSize && y > 0 && y < mapSize);
	}

	public int GetMapSize(){
		return mapSize;
	}
}
