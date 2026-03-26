using UnityEngine;

public class Doctor : GAgent
{

    new void Start()
    {

        // Call base Start method
        base.Start();
        // Set goal so that it can't be removed so the nurse can repeat this action
        SubGoal s1 = new SubGoal("treatPatient", 1, false);
        goals.Add(s1, 3);

        // Resting goal
        SubGoal s2 = new SubGoal("rested", 1, false);
        goals.Add(s2, 1);

        // Call the GetTired() method for the first time
        Invoke("GetTired", Random.Range(10.0f, 20.0f));
    }

    void GetTired()
    {

        if (!beliefs.HasState("exhausted"))
        {
            beliefs.ModifyState("exhausted", 0);
        }

        Invoke("GetTired", Random.Range(30.0f, 60.0f));
    }

}