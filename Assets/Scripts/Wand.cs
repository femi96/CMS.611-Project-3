using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour, IWand {
	// Wand:
	//		Controller that handles wand data and player input.


	// Wand variables
	public double money;
	public double power;
	private Color color;

	private int mapSize = 10;
	private float offset;

	public int controls; // This would be cleaner as an enum
	public int xInitial;
	public int yInitial;
	private int x;
	private int y;
	private int qx;
	private int qy;

	private LinkedList<Direction> queue;
    private LineRenderer lineRenderer;
	// Wand variables
	
	// Use this for initialization
	void Start() {
		x = xInitial;
		y = yInitial;
		qx = x;
		qy = y;

		money = 30;
		power = 2;
		color = transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().color;

		offset = 0.5f - (mapSize/2f);

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.sortingOrder = 0;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.positionCount = 0;
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(qx + offset, qy + offset, -5));


        queue = new LinkedList<Direction>();

		// Position offset based on mapSize
		MoveWand();
	}
	
	// Update is called once per frame
	void Update() {
		Direction dir = Direction.NONE;
		switch(controls) {
			case 1:
				if(Input.GetKeyDown(KeyCode.W)) {
					if (CanMove (qx, qy + 1)) {
						dir = Direction.UP;
                        //Debug.DrawLine(new Vector2(qx+offset, qy+offset), new Vector2(qx+offset, qy+1+offset), Color.red, 2, false);
                        lineRenderer.positionCount++;
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(qx + offset, qy + 1 + offset, -5));
                        qy++;
					}
				} else if(Input.GetKeyDown(KeyCode.A)) {
					if (CanMove (qx - 1, qy)) {
						dir = Direction.LEFT;
                        //Debug.DrawLine(new Vector2(qx+offset, qy+offset), new Vector2(qx-1+offset, qy+offset), Color.red, 2, false);
                        lineRenderer.positionCount++;
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(qx - 1 + offset, qy + offset, -5));
						qx--;
					}
				} else if(Input.GetKeyDown(KeyCode.S)) {
					if (CanMove (qx, qy - 1)) {
						dir = Direction.DOWN;
                        //Debug.DrawLine(new Vector2(qx+offset, qy+offset), new Vector2(qx+offset, qy-1+offset), Color.red, 2, false);
                        lineRenderer.positionCount++;
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(qx + offset, qy -1+ offset, -5));
						qy--;
					}
				} else if(Input.GetKeyDown(KeyCode.D)) {
					if (CanMove (qx + 1, qy)) {
						dir = Direction.RIGHT;
                        //Debug.DrawLine(new Vector2(qx+offset, qy+offset), new Vector2(qx+1+offset, qy+offset), Color.red, 2, false);
                        lineRenderer.positionCount++;
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(qx + 1 + offset, qy+ offset, -5));
						qx++;
					}
				}
				break;
			default:
				if(Input.GetKeyDown(KeyCode.UpArrow)) {
					if (CanMove (qx, qy + 1)) {
						dir = Direction.UP;
                        lineRenderer.positionCount++;
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(qx + offset, qy + 1 + offset, -5));
						qy++;
					}
				} else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
					if (CanMove (qx - 1, qy)) {
						dir = Direction.LEFT;
                        lineRenderer.positionCount++;
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(qx - 1 + offset, qy + offset, -5));
						qx--;
					}
				} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
					if (CanMove (qx, qy - 1)) {
						dir = Direction.DOWN;
                        lineRenderer.positionCount++;
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(qx + offset, qy -1+ offset, -5));
						qy--;
					}
				} else if(Input.GetKeyDown(KeyCode.RightArrow)) {
					if (CanMove (qx + 1, qy)) {
						dir = Direction.RIGHT;
                        lineRenderer.positionCount++;
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(qx + 1 + offset, qy+ offset, -5));
						qx++;
					}
				}
				break;
		}
		if(dir != Direction.NONE) {
			queue.AddLast(dir);
		}
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

	public double GetPower(){
		return power;
	}

	public void AddMoney(double m){
		money = money + m;
	}

	public void AddPower(double m){
		power = power + m;
	}
		
	// Lose methods return true if possible, return false if not possible
	public bool LoseMoney(double m){
		if (money >= m) {
			money = money - m;
			return true;
		}
		return false;
	}

	public bool LosePower(double m){
		if (power >= m) {
			power = power - m;
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
		if(queue == null || queue.Count == 0) {
			return Direction.NONE;
		}
		Direction popped = queue.First.Value;
		queue.RemoveFirst();
        Vector3[] oldPos = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(oldPos);
        Vector3[] newPos = new Vector3[lineRenderer.positionCount - 1];
        for(int i = 1; i < oldPos.Length; i++)
        {
            newPos[i - 1] = oldPos[i];
        }
        lineRenderer.positionCount--;
        lineRenderer.SetPositions(newPos);
		switch(popped) {
			case Direction.DOWN:
				if (CanMove (x, y - 1)) {
					y--;
				} else {
					queue.Clear ();
					qx = x;
					qy = y;
				}
				break;
			case Direction.LEFT:
				if (CanMove(x-1,y)) {
					x--;
				} else {
					queue.Clear ();
					qx = x;
					qy = y;
				}
				break;
			case Direction.RIGHT:
				if (CanMove(x+1,y)) {
					x++;
				} else {
					queue.Clear ();
					qx = x;
					qy = y;
				}
				break;
			case Direction.UP:
				if (CanMove (x, y + 1)) {
					y++;
				} else {
					queue.Clear ();
					qx = x;
					qy = y;
				}
				break;
		}
		MoveWand();
		return popped;
	}

	public bool CanMove(int x_new, int y_new){
		return !(y_new < 0 || x_new < 0 || y_new >= mapSize || x_new >= mapSize);
	}

	public List<Direction> Trail() {
		return new List<Direction>(queue);
	}

	private void MoveWand() {
		x = Mathf.Max(x, 0);
		x = Mathf.Min(x, mapSize - 1);
		y = Mathf.Max(y, 0);
		y = Mathf.Min(y, mapSize - 1);
		transform.position = new Vector2(x + offset, y + offset);
	}

	public bool Attack(IWand otherPlayer) {

		if(power > otherPlayer.GetPower()) {
			LosePower(power / otherPlayer.GetPower());
			otherPlayer.LosePower(otherPlayer.GetPower() / power);
			return true;

		} else if(power < otherPlayer.GetPower()) {
			otherPlayer.LosePower(power / otherPlayer.GetPower());
			LosePower(otherPlayer.GetPower() / power);
			return false;

		} else {
			bool moneyGreater = money >= otherPlayer.GetMoney();

			if(moneyGreater) {

				LoseMoney(otherPlayer.GetMoney() + 1);
				otherPlayer.LoseMoney(otherPlayer.GetMoney());

			} else {

				otherPlayer.LoseMoney(money + 1);
				LoseMoney(money);
			}
			return moneyGreater;
		}
	} 
}
