using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    /* Game Manager to handle game state and logic */

    [SerializeField] private Transform player;
    [SerializeField] private float winDistance = 5f;
    [SerializeField] private LayerMask personLayer;
    [SerializeField] private LevelEndManager levelEndManager;
    [SerializeField] private LevelData levelData;
    public static GameManager Instance;
    private bool gameRunning = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        gameRunning = false;
    }

    private void OnEnable()
    {
        /* Subscribe to timer's time-up event */
        TimerManager.Instance.OnTimeUp += HandleTimeUp;
    }

    private void OnDisable()
    {
        /* Unsubscribe from timer's time-up event */
        TimerManager.Instance.OnTimeUp -= HandleTimeUp;
    }

    public void StartLevel()
    {
        gameRunning = true;

        // Start the timer
        if (TimerManager.Instance != null)
            TimerManager.Instance.StartTimer(levelData.Time);
    }

    private void HandleTimeUp()
    {
        /* Handle the event when time is up */

        if (!gameRunning) return;

        GameObject closestPerson = FindClosestPerson();
        if (closestPerson == null)
        {
            levelEndManager.EndLevel(false);
            return;
        }

        bool nearMurderer = IsMurderer(closestPerson);
        bool hasClues = HasClues();

        gameRunning = false;
        levelEndManager.EndLevel(hasClues && nearMurderer);
    }

    private bool HasClues()
    {
        /* Check if player has all important clues to win the level */

        var playerItems = Inventory.Instance.GetClues();
        var levelName = levelEndManager.GetCurrentLevelName();

        // Find all important clues in the game (you can assign this list in the Inspector)
        var allImportantClues = Resources.LoadAll<ClueData>(levelName).Where(c => c.WinClue).ToList();

        // Player must have every important clue
        foreach (var clue in allImportantClues)
        {
            if (!playerItems.Contains(clue))
                return false;
        }

        return true;
    }

    private GameObject FindClosestPerson()
    {
        /* Find the closest person within winDistance (who the player thinks is the murderer)  */

        float closestDist = float.MaxValue;
        GameObject closest = null;

        //  Only detect colliders on the "Person" layer
        Collider2D[] hits = Physics2D.OverlapCircleAll(player.position, winDistance, personLayer);
        foreach (var hit in hits)
        {

            float dist = Vector2.Distance(player.position, hit.transform.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closest = hit.gameObject;
            }
        }

        return closest;
    }
    
    private bool IsMurderer(GameObject obj)
    {
        /* Check if the given person object is the murderer */

        var person = obj.GetComponent<PersonInstance>();
        if (person == null || person.personData == null) return false;
        return person.personData.IsMurderer;
    }
}
