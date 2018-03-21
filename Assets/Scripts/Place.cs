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

	private int costM;
	private int costP;
	
	public virtual bool TakeOver(IWand player) {
		return false;
	}

	public virtual void Generate() {
		return;
	}

	public virtual void UpdateCosts() {
		SetCostM(0);
		SetCostP(0);
	}

	public bool IsOwned() {
		OwnedRep();
		return owned;
	}
	
	public IWand GetOwner() {
		OwnedRep();
		return owner;
	}

	public void SetOwner(IWand newOwner) {
		owned = true;
		owner = newOwner;
	}

	// Maintain owned rep state
	private void OwnedRep() {
		if(!owned) { owner = null; }
	}

	public PlaceType GetPlaceType() {
		return placeType;
	}

	public void SetType(PlaceType newType) {
		placeType = newType;
	}

	public void SetCostM(int newCost) {
		costM = newCost;
	}

	public void SetCostP(int newCost) {
		costP = newCost;
	}

	public int GetCostM() {
		return costM;
	}

	public int GetCostP() {
		return costP;
	}

	public virtual int GetGenP() {
		return 0;
	}

	public virtual int GetGenM() {
		return 0;
	}
}