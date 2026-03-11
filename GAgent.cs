using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class subGoal
{
    public Dictionary<string, int> sgoals;
    public bool remove;

    public subGoal(string s, int i, bool r)
    {
        sgoals = new Dictionary<string, int>
        {
            { s, i }
        };
        remove = r;
    }
}

public class GAgent : MonoBehaviour
{
    public List<GAction> actions = new();
    public Dictionary<subGoal, int> goals = new();
    GPlanner planner;
    Queue<GAction> actionQueue;
    public GAction currentAction;
    subGoal currentGoal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GAction[] acts = this.GetComponents<GAction>();
        foreach (GAction a in acts)
        {
            actions.Add(a);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (planner == null || actionQueue == null || actionQueue.Count == 0)
        {
            planner = new GPlanner();
            WorldStates world = GWorld.Instance.GetWorld();
            var orderedGoals = from entry in goals orderby entry.Value descending select entry;
            foreach (KeyValuePair<subGoal, int> sg in orderedGoals)
            {
                actionQueue = planner.Plan(actions, sg.Key.sgoals, world);
                if (actionQueue != null)
                {
                    currentGoal = sg.Key;
                    break;
                }
            }
        }

        if (currentAction != null && currentAction.running)
        {
            if (currentAction.PostPerform())
            {
                currentAction.running = false;
            }
        }
        else
        {
            if (actionQueue != null && actionQueue.Count > 0)
            {
                currentAction = actionQueue.Dequeue();
                if (currentAction.PrePerform())
                {
                    currentAction.running = true;
                }
                else
                {
                    currentAction.running = false;
                }
            }
        }
    }
}
