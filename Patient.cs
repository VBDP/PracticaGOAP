using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Patient : GAgent
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        subGoal s1 = new subGoal("isWaiting", 1, true);
        goals.Add(s1, 3);
    }
}
