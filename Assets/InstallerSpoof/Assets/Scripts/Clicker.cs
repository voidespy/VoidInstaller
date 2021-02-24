using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clicker : MonoBehaviour
{
    // This is going to be image that the player can click, but it will turn down system integrity as long as it is on the screen.

    public GameObject GameRef;
    public int currClick = 0;
    public int nClicks = 2;
    Renderer block;

    private GameObject currentObject;
    private Transform target;

    public GameObject EntitySpawnerObject;

    // Start is called before the first frame update
    void Start()
    {
        GameRef = GameObject.FindGameObjectWithTag("GameManager");
        EntitySpawnerObject = GameObject.FindGameObjectWithTag("EntitySpawner");
    }

    private void Awake()
    {
        block = GetComponent<Renderer>();
        nClicks = Random.Range(1, 5);
    }

    public void GetBlockTransform()
    {
        currentObject = this.gameObject;
        target = currentObject.transform;
        return;
    }

    public void FixedUpdate()
    {
        //gameObject.transform.position = Vector3.MoveTowards(transform.position, EntitySpawnerObject.GetComponent<EntitySpawner>().Locations[EntitySpawnerObject.GetComponent<EntitySpawner>().randomLocation].position, 10);

    }

    private void DifficultyOnClick()
    {
        //DifficultySelector.Difficulty.Easy,
        //    int _nClicks = Mathf.RoundToInt(nClicks * 1.4f);
        //DifficultySelector.Difficulty.Hard,
        //    int _nClicks = Mathf.RoundToInt(nClicks * .5f);
        //DifficultySelector.Difficulty.Normal,
        //    int _nClicks = Mathf.RoundToInt(nClicks * 1.0f);
        //DifficultySelector.Difficulty.Overkill,
        //    int _nClicks = Mathf.RoundToInt(nClicks * .3f);


    }

    // Update is called once per frame
    void Update()
    {

        if (currClick >= nClicks)
        {
            Debug.Log("Item is Destroyed");
            Destroy(gameObject); 
        }

        GameRef.GetComponent<GameManager>().ShieldValueCheck(); //.DamageSystem();
    }

    private void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && gameObject.tag == "Enemy")
        {
            currClick++;
            NormalHit();
            GameRef.GetComponent<GameManager>().EnemyAmagus();
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && gameObject.tag == "Money")
        {
            currClick++;
            GoldHit();
            GameRef.GetComponent<GameManager>().MBAmagus();
        }
    }

    private void NormalHit()
    {
        block.material.color = Color.red; // change color of object once hit
    }
    
    private void GoldHit()
    {
        block.material.color = Color.yellow; // change color of object once hit
    }

    private void OffHit()
    {
        block.material.color = Color.white;
    }

}
