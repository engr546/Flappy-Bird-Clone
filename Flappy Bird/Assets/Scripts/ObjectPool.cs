using UnityEngine;

/// <summary>
/// Object Pooling. Optimized for 2D Objects
/// Position Vertical
/// </summary>
public class ObjectPool : MonoBehaviour
{
    public int gameObjectPoolSize = 5; // Size of the Pool
    public GameObject gameObjectPrefab; // GameObject Prefab
    public Vector2 objectStartPoolPosition = new Vector2(10, 0); //Start Position of Objects
    public float spwanRate = 2f; // How often to reposition the Objet infront of a Pool
    public float objectPosMin = -2.5f; //Random Min Offset for Vertical (Y) Position
    public float objectPosMax = 2.5f; //Random Max Offset for Vertical (Y) Position

    private GameObject[] gameObjects; // Array of GameObjets
    private float timeSinceLastSpawned; // Store how much since object is last spawned
    private readonly float spawnXpos = 10f; // Fixed X Position. 10 units right off the camera
    private int currentObject = 0; // Track what object of the Array to Reposition

    // Start is called before the first frame update
    void Start()
    {
        // Setup Array
        gameObjects = new GameObject[gameObjectPoolSize];

        // Fill Array with new spawn prefab object
        for (int i = 0; i < gameObjectPoolSize; i++)
            // Instantiate Prefab
            gameObjects[i] = Instantiate(gameObjectPrefab, objectStartPoolPosition, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Count the time that elapsed
        timeSinceLastSpawned += Time.deltaTime;

        // Check Time to Reposition GameObject
        if (!GameManager.instance.IsGameOver && timeSinceLastSpawned >= spwanRate)
        {
            // GENERATE NEW POSITION
            // Reset timeSinceLastSpawned
            timeSinceLastSpawned = 0;
            // Set Y Position
            float spawnYPos = Random.Range(objectPosMin, objectPosMax);
            // Set Position of GameObjects
            gameObjects[currentObject].transform.position = new Vector2(spawnXpos, spawnYPos);
            // Add 1 to current GameObject
            currentObject++;
            // Check if current GameObject is greater than pool
            if (currentObject >= gameObjectPoolSize)
                // Reset current Object
                currentObject = 0;
        }
    }
}
