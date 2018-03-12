using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : Place {
	// Street:
	//		Data type that holds a position's data.

	public Street() {}

    public override bool TakeOver(Wand player)
    {
        if (!IsOwned())
        {
            SetOwner(player);
            return true;
        }
        else
        {
            bool wonTakeOver = player.Attack(GetOwner());
            return wonTakeOver;
        }
    }

	public override void Generate() {
        if(IsOwned())
        {
            GetOwner().AddManPower(1);
        }
		return;
	}
}