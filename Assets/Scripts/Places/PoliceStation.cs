using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceStation : Place {
	// PoliceStation:
	//		Data type that holds a position's data.

	public PoliceStation() {}

	public override bool TakeOver(Wand player) {
		return (player.loseMoney(20) && player.loseManPower(5)); // NOTE: THIS MEANS A PLAYER WILL LOSE
		// ONE RESOURCE AND FAIL TO TAKE OVER
		// If they don't have enough of both,
		// not sure if we want that, let's see how it plays
	}

	public override void Generate() {
		Wand owner = GetOwner();
		if (owner != null) {
			owner.addMoney(8);
			owner.addManPower(2);
		}
		return;
	}
}