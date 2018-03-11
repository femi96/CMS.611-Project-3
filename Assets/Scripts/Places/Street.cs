using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : Place {
	// Street:
	//		Data type that holds a position's data.

	public Street() {}

	public override bool TakeOver(Wand player) {
		return false;
	}

	public override void Generate() {
		return;
	}
}