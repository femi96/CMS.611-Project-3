using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Place {
	// Place:
	//		Data type that holds a place's data.


	// Place variables
	private bool owned = false;
	private Wand owner;	// If owner == null, owner = false


	// Called when trying to takeover a location.
	//		Takes wand of attempting player, for player's money and manpower
	//		Returns boolean for if takeover was successful
	//
	public virtual bool TakeOver(Wand player) {
		return false;
	}

	// Called on generation ticks.
	//		Change resources of owner based on place effect
	//
	public virtual void Generate() {
		return;
	}

	// Called to get owner's wand
	//		Returns wand of owner
	//
	public Wand GetOwner() {
		if(!owned) { owner = null; }
		return owner;
	}

	// Called to set owner's wand
	//		Takes wand of new owning player
	//		Sets owned and owner fields
	//
	public void SetOwner(Wand player) {
		owned = true;
		owner = player;
	}
}