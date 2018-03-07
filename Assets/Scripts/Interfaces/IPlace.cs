public interface IPlace {
    int GetX();
    int GetY();

    PlaceType Type();
    bool IsOwned();
	void Generate();
    IWand GetOwner();
    void SetOwner(IWand owner);
    bool TakeOver(IWand owner);
}
