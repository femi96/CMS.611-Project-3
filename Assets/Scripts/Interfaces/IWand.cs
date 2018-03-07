using System.Collections.Generic;
using UnityEngine;

// Responsible for maintaining a queue of actions
public interface IWand
{
    // Current cursor Location
    int GetX();
    int GetY();

    Color GetColor();
    

    // Get the action on top of the queue
    Direction Peek();

    // Get the action on top of the queue and remove it; also updates cursor location
    Direction Pop();

    // Gets the trail of actions currently on the queue
    List<Direction> Trail();
}
