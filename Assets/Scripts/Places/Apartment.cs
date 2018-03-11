using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apartment : Place {
	// PoliceStation:
	//		Data type that holds a position's data.

	public Apartment() {}

	public override bool TakeOver(Wand player) {
		return (player.LoseMoney(15) && player.LoseManPower(2)); // NOTE: THIS MEANS A PLAYER WILL LOSE
		// ONE RESOURCE AND FAIL TO TAKE OVER
		// If they don't have enough of both,
		// not sure if we want that, let's see how it plays
	}

	public override void Generate() {
		Wand owner = GetOwner();
		if (owner != null) {
			owner.AddMoney(3);
			owner.AddManPower((int) Random.Range( 0.0f, 1.5f ) ); // will add 1 man power 1/3 of the time
		}
		return;
	}
}