using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Serialized so it is visible in inspector
public class itemDrop
{
    public GameObject itemToDrop;
    public int weight;
}

public class ItemDrop : MonoBehaviour
{
    public List<itemDrop> drops;
    private List<int> CDFArray;

    public void DropRandomItem()
    {
        // Choose a random number less than my total CDF
        int randomNumber = Random.Range(0, CDFArray[CDFArray.Count - 1]);

        /* Method 1 - Manual look through CDFArray - If it is a high number, it will a high number of checks - not optimal
        // Look through my CDFArray and find which index our number belongs to
        for (int i=0; i<CDFArray.Count; i++)
        {
            // If the random numberis less than the cumulative weight of my current index
            if (randomNumber < CDFArray[i])
            {
                // Instantiate me current index
                Instantiate(drops[i].itemToDrop, transform.position, transform.rotation);
                // Quit this function
                return;
            }
        }
        */

        // Method 2 - Binary search :D
        // Find the index that our random number is in
        int selectedIndex = System.Array.BinarySearch(CDFArray.ToArray(), randomNumber);
        // Binary search will tell me where that number is ONLY if we hit it EXACTLY, otherwise, we get a special negative number
        if (selectedIndex < 0)
            selectedIndex = ~selectedIndex;
        // Instantiate the items
        Instantiate(drops[selectedIndex].itemToDrop, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Simulating having a giant list of items to drop
        CDFArray = new List<int>();
        for (int i=0; i < drops.Count; i++)  // Go through every item in the drops list
        {
            // Set its CDFArray value
            if (i == 0) // Use if because you cannot add the previous one if it is 0, as there is no -1
            {
                CDFArray.Add(drops[i].weight);
            }
            else
            {
                CDFArray.Add(drops[i].weight + CDFArray[i - 1]);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
