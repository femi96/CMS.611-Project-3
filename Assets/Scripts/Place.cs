using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Place : IPlace {
	// Place:
	//		Data type that holds a place's data.


	// Place variables
	private bool owned = false;
	private IWand owner;	// If owner == null, owner = false

	private PlaceType placeType = PlaceType.Default;
	
	public virtual bool TakeOver(IWand player) {
		return false;
	}

	public virtual void Generate() {
		return;
	}

	public bool IsOwned() {
		OwnedRep();
		return owned;
	}
	
	public IWand GetOwner() {
		OwnedRep();
		return owner;
	}

	private void OwnedRep() {
		if(!owned) { owner = null; }
	}

	public void SetOwner(IWand newOwner) {
		owned = true;
		owner = newOwner;
	}

	public void SetType(PlaceType newType) {
		placeType = newType;
	}

	public PlaceType GetPlaceType() {
		return placeType;
	}
}