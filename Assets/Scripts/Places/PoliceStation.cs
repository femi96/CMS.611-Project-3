using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceStation : Place {
	// PoliceStation:
	//		Data type that holds a position's data.

	public PoliceStation() {
		SetType(PlaceType.Police);
	}

	public override bool TakeOver(Wand player) {

        if (!IsOwned())
        {
            bool canTakeOver = player.LoseManPower(2) && player.LoseMoney(15);
            if(canTakeOver)
            {
                SetOwner(player);
            }
            return canTakeOver;
        }
        else
        {
            bool wonTakeOver = player.Attack(GetOwner());
            return wonTakeOver;
        }
    }

	public override void Generate() {
		Wand owner = GetOwner();
		if (owner != null) {
			owner.AddMoney(8);
			owner.AddManPower(2);
		}
		return;
	}
}