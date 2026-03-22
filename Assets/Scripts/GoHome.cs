public class GoHome : GAction {
    public Spawn spawn;

    void Start()
    {
        spawn = FindFirstObjectByType<Spawn>();
    }
    public override bool PrePerform() {

        return true;
    }

    public override bool PostPerform() {

        Destroy(this.gameObject);
        spawn.RestarPaciente();
        return true;
        
    }
}
