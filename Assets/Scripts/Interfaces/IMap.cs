using UnityEngine;

public interface IMap {

	// Get place at map location
	//		Takes x, y for grid location
	//		Returns place at location
	IPlace GetPlace(int x, int y);

	// Get place at map location
	//		Takes vector2 for location
	//		Returns place at location
	IPlace GetPlace(Vector2 v);

	// Set place at a map location to have a new owner
	//		Takes new owner's wand
	//		Takes x, y for grid location
	void SetPlaceOwner(int x, int y, Wand newOwner);

	// Get the map's size
	//		Returns map's grid size as int
	int GetMapSize();
}