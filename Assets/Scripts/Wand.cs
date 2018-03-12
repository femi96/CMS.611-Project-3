using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour, IWand {
	// Wand:
	//		Controller that handles wand data and player input.


	// Wand variables
	public double money;
	public double manPower;
	private Color color;

	private int mapSize = 10;
	private float offset;

	public int controls; // This would be cleaner as an enum
	public int xInitial;
	public int yInitial;
	private int x;
	private int y;

	private LinkedList<Direction> queue;
	// Wand variables
	
	// Use this for initialization
	void Start() {
		x = xInitial;
		y = yInitial;

		money = 30;
		manPower = 2;
		color = transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().color;
		
		queue = new LinkedList<Direction>();

		// Position offset based on mapSize
		offset = 0.5f - (mapSize/2f);
		MoveWand();
	}
	
	// Update is called once per frame
	void Update() {
		Direction dir = Direction.NONE;
		switch(controls) {
			case 1:
				if(Input.GetKeyDown(KeyCode.W)) {
					dir = Direction.UP;
				} else if(Input.GetKeyDown(KeyCode.A)) {
					dir = Direction.LEFT;
				} else if(Input.GetKeyDown(KeyCode.S)) {
					dir = Direction.DOWN;
				} else if(Input.GetKeyDown(KeyCode.D)) {
					dir = Direction.RIGHT;
				}
				break;
			default:
				if(Input.GetKeyDown(KeyCode.UpArrow)) {
					dir = Direction.UP;
				} else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
					dir = Direction.LEFT;
				} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
					dir = Direction.DOWN;
				} else if(Input.GetKeyDown(KeyCode.RightArrow)) {
					dir = Direction.RIGHT;
				}
				break;
		}
		if(dir != Direction.NONE) { queue.AddLast(dir); }
	}

	public Color GetColor() {
		return color;
	}

	public Vector2 GetPosition() {
		return transform.position;
	}

	public double GetMoney(){
		return money;
	}

	public double GetManPower(){
		return manPower;
	}

	public void AddMoney(double m){
		money = money + m;
	}

	public void AddManPower(double m){
		manPower = manPower + m;
	}
		
	// Lose methods return true if possible, return false if not possible
	public bool LoseMoney(double m){
		if (money > m) {
			money = money - m;
			return true;
		}
		return false;
	}

	public bool LoseManPower(double m){
		if (manPower > m) {
			manPower = manPower - m;
			return true;
		}
		return false;
	}

	public Direction Peek() {
		if(queue.Count == 0) {
			return Direction.NONE;
		}
		return queue.First.Value;
	}

	public Direction Pop() {
		if(queue.Count == 0) {
			return Direction.NONE;
		}
		Direction popped = queue.First.Value;
		queue.RemoveFirst();
		switch(popped) {
			case Direction.DOWN:
				y--;
				break;
			case Direction.LEFT:
				x--;
				break;
			case Direction.RIGHT:
				x++;
				break;
			case Direction.UP:
				y++;
				break;
		}
		MoveWand();
		return popped;
	}

	public List<Direction> Trail() {
		return new List<Direction>(queue);
	}

	private void MoveWand() {
		transform.position = new Vector2(x + offset, y + offset);
	}

	public bool Attack(Wand otherPlayer)
	{
		if(manPower > otherPlayer.GetManPower())
		{
			LoseManPower(manPower / otherPlayer.GetManPower());
			otherPlayer.LoseManPower(otherPlayer.GetManPower() / manPower);
			return true;
		} else if(manPower < otherPlayer.GetManPower())
		{
			otherPlayer.LoseManPower(manPower / otherPlayer.GetManPower());
			LoseManPower(otherPlayer.GetManPower() / manPower);
			return false;
		} else
		{
			bool moneyGreater = money >= otherPlayer.GetMoney();
			if(moneyGreater)
			{
				LoseMoney(otherPlayer.GetMoney() + 1);
				otherPlayer.LoseMoney(otherPlayer.GetMoney());
			} else
			{
				otherPlayer.LoseMoney(money + 1);
				LoseMoney(money);
			}
			return moneyGreater;
		}
	} 
}
