using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, IMap {
	// Map:
	//		Controller that handles wand data and player input.


	// Map assigned in editor
	public GameObject newPlace;
	public Sprite[] typeSprites;
	public PlaceType[] typeIndex;

	// Map variables
	private int mapSize = 10;
	private IPlace[,] placeGrid;		// Grid mapping location to place data @ location
	private GameObject[,] placeGOGrid;	// Grid mapping location to place gameobject

	private float offset;


	// Use this for initialization
	void Start() {

		// Position offset based on mapSize
		offset = 0.5f - (mapSize/2f);
		
		// Create placeGrid as new places
		placeGrid = new IPlace[mapSize, mapSize];
		placeGOGrid = new GameObject[mapSize, mapSize];
		for(int y = 0; y < mapSize; y++) {
			for(int x = 0; x < mapSize; x++) {
				if(x==1) { placeGrid[x, y] = new PoliceStation();}
				else { placeGrid[x, y] = new PizzaPlace(); }
				UpdateGO(x, y);
			}
		}
	}
	
	// Update is called once per frame
	void Update() {}

	public int GetMapSize(){
		return mapSize;
	}

	public IPlace GetPlace(int x, int y) {
		if(ValidXY(x,y)) return placeGrid[x, y];
		else return null;
	}

	public IPlace GetPlace(Vector2 v) {
		int x = Mathf.FloorToInt(v.x);
		int y = Mathf.FloorToInt(v.y);
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
		GameObject go = placeGOGrid[x, y];

		if(go != null) { Destroy(go); }

		IPlace place = GetPlace(x, y);

		go = Instantiate(newPlace, new Vector2(x+offset, y+offset), Quaternion.identity, transform);
		go.name = "Place ("+x+", "+y+")";

		// Color place background based on ownership
		if(place.IsOwned()) {
			IWand owner = place.GetOwner();
			go.transform.Find("Background").gameObject.GetComponent<SpriteRenderer>().color = owner.GetColor();
		}

		// Add sprite based on place type
		int i = Array.IndexOf(typeIndex, place.GetPlaceType());
		if(i != -1) {
			go.transform.Find("Type").gameObject.GetComponent<SpriteRenderer>().sprite = typeSprites[i];
		}

		placeGOGrid[x, y] = go;
	}

	// Return if x, y are valid coordinates in the grid
	private bool ValidXY(int x, int y) {
		return (x >= 0 && x < mapSize && y >= 0 && y < mapSize);
	}
}
