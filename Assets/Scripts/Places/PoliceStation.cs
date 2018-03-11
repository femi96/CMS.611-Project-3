using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceStation : Place {
	// PoliceStation:
	//		Data type that holds a position's data.

	public PoliceStation() {
		SetType(PlaceType.Police);
	}

	public override bool TakeOver(Wand player) {
		return (player.LoseMoney(20) && player.LoseManPower(5)); // NOTE: THIS MEANS A PLAYER WILL LOSE
		// ONE RESOURCE AND FAIL TO TAKE OVER
		// If they don't have enough of both,
		// not sure if we want that, let's see how it plays
	}

	public override void Generate() {
		Wand owner = GetOwner();
		if (owner != null) {
			owner.AddMoney(8);
			owner.AddManPower(2);
		}
		return;
	}
}