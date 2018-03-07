public interface IMap {
    IPlace GetPlace(int x, int y);
	int getMapSize ();
	Place[,] getPlaceGrid ();
}
