using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data {

	private List<Direction> moves1;
	private List<Direction> moves2;

	public Data() {
		moves1 = new List<Direction>();
		moves2 = new List<Direction>();
	}

	public void LogInput(Direction move1, Direction move2) {
		moves1.Add(move1);
		moves2.Add(move2);
	}

	public string ReadLog() {
		string read = "";

		string w1 = " P1:";
		string w2 = " P2:";

		for(int i = 0; i < moves1.Count; i++) {
			read += ""+i+" [";
			switch(moves1[i]) {
				case Direction.UP:
					read += w1+"N";
					break;
				case Direction.DOWN:
					read += w1+"S";
					break;
				case Direction.LEFT:
					read += w1+"W";
					break;
				case Direction.RIGHT:
					read += w1+"E";
					break;
				case Direction.NONE:
					read += w1+"O";
					break;
			}
			switch(moves2[i]) {
				case Direction.UP:
					read += w2+"N";
					break;
				case Direction.DOWN:
					read += w2+"S";
					break;
				case Direction.LEFT:
					read += w2+"W";
					break;
				case Direction.RIGHT:
					read += w2+"E";
					break;
				case Direction.NONE:
					read += w2+"O";
					break;
			}
			read += " ]\n";
		}

		return read;
	}
	public void WriteLog() {
		string read = ReadLog();
		string[] splitString = read.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

		System.DateTime now = System.DateTime.Now;

		using (StreamWriter sw = new StreamWriter("TestFile-"+(now.Second*1000+now.Millisecond)+".txt")) {

			foreach(string str in splitString) {
				sw.WriteLine(str);
			}
			// Arbitrary objects can also be written to the file.
			sw.WriteLine("");
			sw.WriteLine("The date is: ");
			sw.WriteLine(now);
		}
	}
}
