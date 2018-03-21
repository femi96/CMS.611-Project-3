using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : Place {
	// Street:
	//		Data type that holds a position's data.

	public Street() {}

	public override bool TakeOver(IWand player) {
		if(GetCostM() <= player.GetMoney() && GetCostP() <= player.GetPower()) {
			return player.LosePower(GetCostP()) && player.LoseMoney(GetCostM());
		}
		return false;
	}

	public override void Generate() {
        return;
    }

	public override void UpdateCosts() {
		if(IsOwned()) {
			SetCostM(0);
			SetCostP(2);
		} else {
			SetCostM(0);
			SetCostP(0);
		}
	}
}