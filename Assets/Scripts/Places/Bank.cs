using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : Place {
	// Bank:
	//		Data type that holds a position's data.

	public Bank() {
        SetType(PlaceType.Bank);
    }

	public override bool TakeOver(IWand player) {
        return player.LosePower(3) && player.LoseMoney(20);
    }

	public override void Generate() {
		IWand owner = GetOwner();
		if (owner != null) {
			owner.AddMoney(8);
			owner.AddPower(0);
		}
		return;
	}
}