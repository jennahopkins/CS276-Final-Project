using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float winDistance = 5f;
    [SerializeField] private LayerMask personLayer;
    [SerializeField] private GameFlowUI ui;
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
        TimerManager.Instance.OnTimeUp += HandleTimeUp;
    }

    private void OnDisable()
    {
        TimerManager.Instance.OnTimeUp -= HandleTimeUp;
    }

    public void StartLevel()
    {
        gameRunning = true;

        // Start the timer
        if (TimerManager.Instance != null)
            TimerManager.Instance.StartTimer();
    }

    private void HandleTimeUp()
    {
        if (!gameRunning) return;

        GameObject closestPerson = FindClosestPerson();
        if (closestPerson == null)
        {
            EndLevel(false);
            return;
        }

        bool nearMurderer = IsMurderer(closestPerson);
        bool hasClues = HasClues();

        EndLevel(hasClues && nearMurderer);
    }

    private bool HasClues()
    {
        var playerItems = Inventory.Instance.GetClues();

        // Find all important clues in the game (you can assign this list in the Inspector)
        var allImportantClues = Resources.LoadAll<ClueData>("").Where(c => c.WinClue).ToList();

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
        var person = obj.GetComponent<PersonInstance>();
        if (person == null || person.personData == null) return false;
        return person.personData.IsMurderer;
    }

    public void EndLevel(bool playerWon)
    {
        gameRunning = false;
        ui.ShowEndGame(playerWon);
    }
}
