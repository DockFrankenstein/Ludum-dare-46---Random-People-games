using UnityEngine;

class CheckpointGroup : MonoBehaviour
{
    Checkpoint currentCheckpoint;

    public void SetCurrentCheckpoint(Checkpoint _checkpoint)
    {
        currentCheckpoint = _checkpoint;

        foreach(Checkpoint checkpoint in GetComponentsInChildren<Checkpoint>())
            if (checkpoint.id < _checkpoint.id)
                checkpoint.Set();
    }

}
