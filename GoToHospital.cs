using UnityEngine;

public class GoToHospital : GAction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
