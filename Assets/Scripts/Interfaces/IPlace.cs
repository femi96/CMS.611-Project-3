public interface IPlace {

	// Get the place's type
	//		Returns place's PlaceType
	PlaceType GetPlaceType();

	// Set the place's type
	//		Takes new PlaceType
	void SetType(PlaceType newType);

	// If the place has an owner
	//		Returns boolean for if the place has an owner
    bool IsOwned();

	// Get the place's owner's wand
	//		Returns wand of owner
    IWand GetOwner();

	// Set the place's owner
	//		Takes wand of new owning player
    void SetOwner(IWand owner);

	// Try to take over the place.
	//		Takes wand of player taking over
	//		Changes player's resources
	//		Returns boolean for if takeover was successful
    bool TakeOver(IWand owner);

	// Give resources to the place's owner. Call on generation ticks.
	//		Change resources of place's owner based on the type of place.
    void Generate();
    
    void UpdateCosts();
    int GetCostM();
    int GetCostP();
}