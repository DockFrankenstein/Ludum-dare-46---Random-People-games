using UnityEngine;

class Checkpoint : MonoBehaviour
{
    public int id;
    public bool isReached = false;

    CheckpointGroup checkpointGroup;

    private void Start()
    {
        checkpointGroup = GetComponentInParent<CheckpointGroup>();
    }


    public void OverrideCheckpoint()
    {
        if (!isReached)
        {
            Set();
            checkpointGroup.SetCurrentCheckpoint(this);
        }

    }
    public void Set()
    {
        isReached = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            OverrideCheckpoint();
    }
}