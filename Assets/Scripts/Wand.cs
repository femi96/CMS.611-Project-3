using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour, IWand {
	// Wand:
	//		Controller that handles wand data and player input.


	// Wand variables
	private double money;
	private double manPower;
	private Color color;

    private int x;
    private int y;
    private List<Direction> trail;
	// Wand variables
	

	// Use this for initialization
	void Start() {
		money = 30;
		manPower = 2;
		color = transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update() {
		
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

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

	public Direction Peek() {
		return Direction.UP;
	}

	public Direction Pop() {
		return Direction.UP;
	}

	public List<Direction> Trail() {
		return new List<Direction>();
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
