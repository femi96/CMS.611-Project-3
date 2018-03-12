using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apartment : Place {
	// PoliceStation:
	//		Data type that holds a position's data.

	public Apartment() {}

	public override bool TakeOver(Wand player) {
        if (!IsOwned())
        {
            bool canTakeOver = player.LoseManPower(2) && player.LoseMoney(15);
            if (canTakeOver)
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
			owner.AddMoney(3);
			owner.AddManPower((int) Random.Range( 0.0f, 1.5f ) ); // will add 1 man power 1/3 of the time
		}
		return;
	}
}