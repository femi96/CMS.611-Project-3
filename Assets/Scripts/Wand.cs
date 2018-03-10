using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour, IWand {
	// Wand:
	//		Controller that handles wand data and player input.
	private double money;
	private double manPower;
	private Color color;

	// Wand variables
	

	// Use this for initialization
	void Start () {
		money = 30;
		manPower = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public double getMoney(){
		return money;
	}

	public double getManPower(){
		return manPower;
	}

	public void addMoney(double m){
		money = money + m;
	}

	public void addManPower(double m){
		manPower = manPower + m;
	}
		
	// Lose methods return true if possible, return false if not possible
	public bool loseMoney(double m){
		if (money > m) {
			money = money - m;
			return true;
		}
		return false;
	}

	public bool loseManPower(double m){
		if (manPower > m) {
			manPower = manPower - m;
			return true;
		}
		return false;
	}
}
