using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPlace : Place {
	// PizzaPlace:
	//		Data type that holds a position's data.

	public PizzaPlace() {}

	// Place variables
	private bool owned;
	private Wand owner; // If owner == null, owner = false


    // Called when trying to takeover a location.
    //		Takes wand of attempting player, for player's money and manpower
    //		Returns boolean for if takeover was successful
    //
    public virtual bool TakeOver(Wand player)
    {
        if (!owned)
        {
            owner = player;
            return true;
        }
        else
        {

            return false;
        }
    }

    // Called on generation ticks.
    //		Change resources of owner based on place effect
    //


	public override void Generate() {
		IWand owner = GetOwner();
		if (owner != null) {
			owner.addMoney(4);
			owner.addManPower(0);
		}
		return;
	}
}
