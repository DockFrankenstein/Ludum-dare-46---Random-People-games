using UnityEngine;

class Checkpoint : MonoBehaviour
{
    bool isReached = false;

    public Transform spawnPoint { get; private set; }
    CheckpointGroup checkpointGroup;

    private void Start()
    {
        spawnPoint = transform.GetChild(0);

        checkpointGroup = GetComponentInParent<CheckpointGroup>();
    }


    public void OverrideCheckpoint()
    {
        if(!isReached)
        {
            checkpointGroup.currentCheckpoint = this;
            isReached = true;
        }
    }
}