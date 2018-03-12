using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : Place {
	// Bank:
	//		Data type that holds a position's data.

	public Bank() {}

	public override bool TakeOver(Wand player) {
        if (IsOwned())
        {
            bool canTakeOver = player.LoseManPower(3) && player.LoseMoney(20);
            if (canTakeOver)
            {
                SetOwner(player);
            }
            return canTakeOver;
        } else
        {
            bool wonTakeOver = player.Attack(GetOwner());
            return wonTakeOver;
        }
    }

	public override void Generate() {
		Wand owner = GetOwner();
		if (owner != null) {
			owner.AddMoney(8);
			owner.AddManPower(0);
		}
		return;
	}
}