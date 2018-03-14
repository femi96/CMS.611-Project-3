using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceStation : Place {
	// PoliceStation:
	//		Data type that holds a position's data.

	public PoliceStation() {
		SetType(PlaceType.Police);
	}

	public override bool TakeOver(IWand player) {
		return player.LosePower(2) && player.LoseMoney(15);
	}

	public override void Generate() {
		IWand owner = GetOwner();
		if (owner != null) {
			owner.AddMoney(8);
			owner.AddPower(2);
		}
		return;
	}
}