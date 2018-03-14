using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : Place {
	// Street:
	//		Data type that holds a position's data.

	public Street() {}

	public override bool TakeOver(IWand player) {
		return true;
	}

	public override void Generate() {
		return;
	}
}