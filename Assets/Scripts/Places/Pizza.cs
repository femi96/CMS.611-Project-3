using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPlace : Place {
	// PizzaPlace:
	//		Data type that holds a position's data.

	public PizzaPlace() {}

	public override bool TakeOver(IWand player) {
		return true;
	}

	public override void Generate() {
		IWand owner = GetOwner();
		return;
	}
}
