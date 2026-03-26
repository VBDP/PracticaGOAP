public class TreatPatient : GAction
{
    public override bool PrePerform()
    {
        // Solo intenta ejecutar si el paciente está en el cubículo
        return true; // dejamos que el planner lo decida
    }

    public override bool PostPerform()
    {
        // El doctor trata al paciente
        GWorld.Instance.GetWorld().ModifyState("Treated", 1);

        // Reducimos el paciente en cubículo
        GWorld.Instance.GetWorld().ModifyState("patientOnCubicle", -1);

        // Belief del doctor
        beliefs.ModifyState("isCured", 1);

        return true;
    }
}