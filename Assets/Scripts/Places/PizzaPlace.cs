using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPlace : Place {
	// PizzaPlace:
	//		Data type that holds a position's data.

	public PizzaPlace() {}

    // Called when trying to takeover a location.
    //		Takes wand of attempting player, for player's money and manpower
    //		Returns boolean for if takeover was successful
    //
    public override bool TakeOver(Wand player)
    {
        if (!IsOwned())
        {
            bool canTakeOver = player.LoseManPower(1) && player.LoseMoney(10);
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

    // Called on generation ticks.
    //		Change resources of owner based on place effect
    //

 // NOTE: THIS MEANS A PLAYER WILL LOSE
																 


	public override void Generate() {
		Wand owner = GetOwner();
		if (owner != null) {
			owner.AddMoney(4);
			owner.AddManPower(0);
		}
		return;
	}
}
