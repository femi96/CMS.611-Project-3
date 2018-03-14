﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apartment : Place {
	// PoliceStation:
	//		Data type that holds a position's data.

	public Apartment() {
		SetType(PlaceType.Apartment);
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
			owner.AddMoney(0);
			owner.AddPower(1); // will add 1 man power 1/3 of the time
		}
		return;
	}

	public override void UpdateCosts() {
		if(IsOwned()) {
			SetCostM(10);
			SetCostP(1);
		} else {
			SetCostM(5);
			SetCostP(0);
		}
	}
}