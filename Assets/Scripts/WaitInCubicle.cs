using UnityEngine;

public class WaitInCubicle : GAction
{
    public override bool PrePerform()
    {
        // Debe tener un cubículo
        target = inventory.FindItemWithTag("Cubicle");

        if (target == null)
            return false;

        return true;
    }

    public override bool PostPerform()
    {
        // Añadimos estado de que el paciente está esperando en el cubículo
        GWorld.Instance.GetWorld().ModifyState("patientInCubicle", 1);

        // El paciente ya no “hace nada más”
        return true;
    }
}