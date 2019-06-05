using UnityEngine;
using System.Collections;

// Singleton to hold references to prefabs.
public class PrefabManager : Singleton<PrefabManager> {

	#region PUBLIC VARIABLES
	// An array of large asteroid prefabs. Order doesn't matter.
	public GameObject[] largeAsteroidPrefabs;

	// An array of small asteroid prefabs. Order doesn't matter.
	public GameObject[] smallAsteroidPrefabs;
	#endregion

	#region PUBLIC METHODS
	// Return a large asteroid prefab.
	public GameObject GetLargeAsteroidPrefab()
	{
		if (largeAsteroidPrefabs.Length > 0)
			return largeAsteroidPrefabs[Random.Range (0, largeAsteroidPrefabs.Length)];

		return null;
	}

	// Return a small asteroid prefab.
	public GameObject GetSmallAsteroidPrefab()
	{
		if (smallAsteroidPrefabs.Length > 0)
			return smallAsteroidPrefabs[Random.Range (0, smallAsteroidPrefabs.Length)];

		return null;
	}
	#endregion
}
