using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPlace : IPlace {
	// PizzaPlace:
	//		Data type that holds a position's data.

	public PizzaPlace() {}

	public override bool TakeOver(IWand player) {
		return true;
	}

	public override void Generate() {
		IWand owner = GetOwner();
		if (owner != null) {
			owner.addMoney(4);
			owner.addManPower(0);
		}
		return;
	}
}
