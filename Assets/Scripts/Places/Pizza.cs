﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPlace : Place {
	// PizzaPlace:
	//		Data type that holds a position's data.

	public PizzaPlace() {}

	public override bool TakeOver(Wand player) {
		return true;
	}

	public override void Generate() {
		Wand owner = GetOwner();
		return;
	}
}
