﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceStation : Place {
	// PoliceStation:
	//		Data type that holds a position's data.

	public PoliceStation() {
		SetType(PlaceType.Police);
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
			SetCostM(60);
			SetCostP(10);
		} else {
			SetCostM(30);
			SetCostP(5);
		}
	}

	public override int GetGenM() {
		return 0;
	}

	public override int GetGenP() {
		return 4;
	}
}