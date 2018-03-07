using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	// Map:
	//		Controller that handles wand data and player input.


	// Map variables
	private int mapSize = 10;
	private Place[,] placeGrid;			// Grid mapping location to place data @ location
	private GameObject[,] placeGOGrid;	// Grid mapping location to place gameobject


	// Use this for initialization
	void Start () {
		
		// Create placeGrid as new places
		placeGrid = new Place[mapSize, mapSize];
		for(int y = 0; y < mapSize; y++) {
			for(int x = 0; x < mapSize; x++) {
				placeGrid[x, y] = new PizzaPlace();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Update GO at x, y from place data
	private void UpdateGO(int x, int y) {

	}

	public int getMapSize(){
		return mapSize;
	}

	public Place[,] getPlaceGrid(){
		return placeGrid;
	}
}
