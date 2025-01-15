using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Central coordinator that:

    // Holds references to all other major systems
    // Handles game state transitions
    // Coordinates between systems
    // Implements the Singleton pattern for global access

    [SerializeField] private TimeManager timeManager;
    [SerializeField] private EconomyManager economyManager;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private CustomerManager customerManager;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private UIManager uiManager;

    public static GameManager Instance { get; private set; }

    #region GameManager setup

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (timeManager == null) { timeManager = FindFirstObjectByType<TimeManager>(); }
        if (economyManager == null) { economyManager = FindFirstObjectByType<EconomyManager>(); }
        if (shopManager == null) { shopManager = FindFirstObjectByType<ShopManager>(); }
        if (customerManager == null) { customerManager = FindFirstObjectByType<CustomerManager>(); }
        if (inventoryManager == null) { inventoryManager = FindFirstObjectByType<InventoryManager>(); }
        if (uiManager == null) { uiManager = FindFirstObjectByType<UIManager>(); }
    }

    #endregion
}
