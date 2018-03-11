using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPlace : Place {
	// PizzaPlace:
	//		Data type that holds a position's data.

	public PizzaPlace() {}

	// Place variables
	private bool owned;
	private Wand owner; // If owner == null, owned = false


    // Called when trying to takeover a location.
    //		Takes wand of attempting player, for player's money and manpower
    //		Returns boolean for if takeover was successful
    //
    public override bool TakeOver(Wand player)
    {
        if (!owned)
        {
            owner = player;         // ONE RESOURCE AND FAIL TO TAKE OVER
                                        // If they don't have enough of both,
                                        // not sure if we want that, let's see how it plays
            player.LoseManPower(1);
            player.LoseMoney(10);
            return true;
        }
        else
        {
            bool wonTakeOver = player.Attack(owner);
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
