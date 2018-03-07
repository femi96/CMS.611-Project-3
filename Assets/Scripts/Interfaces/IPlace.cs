public interface IPlace {
    int GetX();
    int GetY();

    PlaceType Type();
    bool IsOwned();
    IWand GetOwner();
    void SetOwner(IWand owner);
    bool TakeOver(IWand owner);
}
