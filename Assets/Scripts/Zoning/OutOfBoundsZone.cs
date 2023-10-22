using UnityEngine;

public enum OutOfBoundsZoneBehavior
{
    InvisibleWall,
    TextPopUp,
    Reposition,
    Respawn,
    MapHorizontalEdgeReposition,
    MapVerticalEdgeReposition,
    NewLevel
}

public class OutOfBoundsZone : MonoBehaviour
{
    public OutOfBoundsZoneBehavior behavior;
    public Vector3 repositionVector = new Vector3(0f,2f,-2f); // Controls where the player is repositioned
    public string newLevelName = "NewLevelToLoad"; // The level to load name

    private void Start()
    {
        if(behavior == OutOfBoundsZoneBehavior.InvisibleWall)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false; // make it a not a trigger? todo: make sure this works with final player controller
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered OutOfBoundsZone");
        if (other.CompareTag("Player")) // Assuming the player has the tag "Player"
        {
            Debug.Log("Player entered OutOfBoundsZone");
            PerformEnterZoneBehavior(other.gameObject);
        }
    }

    private void PerformEnterZoneBehavior(GameObject player)
    {
        Vector3 currentPosition = player.transform.position;
        switch (behavior)
        {
            case OutOfBoundsZoneBehavior.InvisibleWall:
                // TODO: Implement code for an invisible wall behavior?
                break;

            case OutOfBoundsZoneBehavior.TextPopUp:
                // TODO: Implement code for a text popup behavior here
                //UIManager.Instance.ShowPopup("Out of Bounds!");
                break;

            case OutOfBoundsZoneBehavior.Reposition:
                Debug.Log("player reposition to ");
                player.transform.position = repositionVector; // For now is transform, possible refactor this to the player class and call function
                break;

            case OutOfBoundsZoneBehavior.Respawn:
                // TODO: Implement code to respawn the player
                //player.GetComponent<Player>().Respawn();
                break;

            case OutOfBoundsZoneBehavior.MapHorizontalEdgeReposition:
               // Vector3 currentPosition = player.transform.position;
                currentPosition.x = -currentPosition.x + repositionVector.x;
                player.transform.position = currentPosition;
                break;

            case OutOfBoundsZoneBehavior.MapVerticalEdgeReposition:
                currentPosition.z = -currentPosition.z;
                player.transform.position = currentPosition;
                break;

            case OutOfBoundsZoneBehavior.NewLevel:
                LevelLoader.Instance.BeginLoadingLevel(newLevelName);
                break;

            default:
                Debug.LogWarning("Invalid EnterZoneBehavior specified.");
                break;
        }
    }
}
