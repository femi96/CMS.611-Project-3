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
		if(GetCostM() <= player.GetMoney() && GetCostP() <= player.GetPower()) {
			return player.LosePower(GetCostP()) && player.LoseMoney(GetCostM());
		}
		return false;
	}

	public override void Generate() {
		IWand owner = GetOwner();
		if (owner != null) {
			owner.AddMoney(8);
			owner.AddPower(0);
		}
		return;
	}

	public override void UpdateCosts() {
		if(IsOwned()) {
			SetCostM(75);
			SetCostP(10);
		} else {
			SetCostM(50);
			SetCostP(5);
		}
	}
}