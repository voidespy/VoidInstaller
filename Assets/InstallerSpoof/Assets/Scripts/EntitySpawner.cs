using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    // Restructing this Script in 2020-12-20

    // should spawn a block prefab in the coroutine every randomly inputted intervals as soon as the scene starts
    public Transform[] Locations;

    public GameObject[] Quads;
    public GameObject[] Spawnables;
    public float deployTime = 2;


    //Spawnables
    public GameObject BlockO;
    public Transform BadBlock;
    public GameObject TheRealBadBlock;

    // Variables
    public int randomBlock;
    public int randomLocation;

    

    // Start is called before the first frame update
    void Start()
    { 
        GetAreaQuads();
        StartCoroutine(BlockSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        ChooseABlock();
    }

    public void ChooseABlock()
    {
        // chooses a random block from these arrays
         randomBlock = Random.Range(0, Spawnables.Length);
         randomLocation = Random.Range(0, Locations.Length);
    }

    private void Mechania()
    {
        GameObject TheRealBadBlock = Instantiate(Spawnables[randomBlock], BadBlock) as GameObject;
        TheRealBadBlock.transform.position = Locations[randomLocation].transform.position;
    }

    private void GetAreaQuads()
    {
        // Finds the empty GameObjects tagged Quads
        Quads = GameObject.FindGameObjectsWithTag("Quads");
    }


    IEnumerator BlockSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(deployTime);
            Mechania();
        }
    }
}
