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
			owner.AddMoney(GetGenM());
			owner.AddPower(GetGenP());
		}
		return;
	}

	public override void UpdateCosts() {
		if(IsOwned()) {
			SetCostM(0);
			SetCostP(12);
		} else {
			SetCostM(20);
			SetCostP(3);
		}
	}

	public override int GetGenM() {
		return 8;
	}

	public override int GetGenP() {
		return 0;
	}
}