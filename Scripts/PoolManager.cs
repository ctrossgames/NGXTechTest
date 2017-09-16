using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager> {

    //Did not really use, but experimented with creating a stack to randomize cards
    //Based off a VFS project

    private string folderPath = "PrefabCards";

    private Dictionary<string, Stack<GameObject>> nameOfCard = new Dictionary<string, Stack<GameObject>>();


    // Use this for initialization
    void Awake ()
    {
        GameObject[] resources = Resources.LoadAll<GameObject>(folderPath);

        //Referenced https://forum.unity.com/threads/randomize-array-in-c.86871/
        for (int i = 0; i < resources.Length; i++)
        {
            GameObject temp = resources[i];
            int r = Random.Range(i, resources.Length);
            resources[i] = resources[r];
            resources[r] = temp;
        }

        foreach(GameObject cardPrefab in resources)
        {
            Stack<GameObject> cardStack = new Stack<GameObject>();
            cardStack.Push(cardPrefab);
            nameOfCard.Add(cardPrefab.name, cardStack);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
