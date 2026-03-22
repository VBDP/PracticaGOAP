public class GoHome : GAction {
    public SpawnPacient spawn;

    void Start()
    {
        spawn = FindFirstObjectByType<SpawnPacient>();
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
