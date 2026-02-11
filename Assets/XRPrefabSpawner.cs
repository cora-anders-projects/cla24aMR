using UnityEngine;
using UnityEngine.InputSystem;

public class XRPrefabSpawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    [Header("Input Action")]
    public InputActionReference spawnActionReference;

    private void OnEnable()
    {
        // Subscribe to the 'performed' event (when the button is pressed)
        spawnActionReference.action.Enable();
        spawnActionReference.action.performed += OnSpawnButtonPressed;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks or errors when the object is destroyed
        spawnActionReference.action.performed -= OnSpawnButtonPressed;
    }

    private void OnSpawnButtonPressed(InputAction.CallbackContext context)
    {
        SpawnPrefab();
    }

    public void SpawnPrefab()
    {
        if (prefabToSpawn != null && spawnPoint != null)
        {
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Spawner: Missing Prefab or Spawn Point reference!");
        }
    }
}