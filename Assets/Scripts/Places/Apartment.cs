using System.Collections;
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
			return true;
		}
		return player.LosePower(GetCostP()) && player.LoseMoney(GetCostM());
	}

	public override void Generate() {
		IWand owner = GetOwner();
		if (owner != null) {
			owner.AddMoney(3);
			owner.AddPower((int) Random.Range( 0.0f, 1.5f ) ); // will add 1 man power 1/3 of the time
		}
		return;
	}

	public override void UpdateCosts() {
		SetCostM(5);
		SetCostP(0);
	}
}