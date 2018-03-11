using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPlace : Place {
	// PizzaPlace:
	//		Data type that holds a position's data.

	public PizzaPlace() {}

	public override bool TakeOver(Wand player) {
		return (player.loseMoney(10) && player.loseManPower(1)); // NOTE: THIS MEANS A PLAYER WILL LOSE
																 // ONE RESOURCE AND FAIL TO TAKE OVER
		                                                         // If they don't have enough of both,
		                                                         // not sure if we want that, let's see how it plays
	}

	public override void Generate() {
		Wand owner = GetOwner();
		if (owner != null) {
			owner.addMoney(4);
			owner.addManPower(0);
		}
		return;
	}
}
