using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSelector : MonoBehaviour
{
    public int BaseArmor = 100;

    // Amagus is a float, as it's a type of cryptocurreny.
    // .96 Ama = 1 Amagus Coin

    int basicShield;   // 1.0 -- starter -- starts with this
    int fairShield;   // 1.2 -- cost 5 Amagus
    int medShield;   // 1.4 -- cost 10 Amagus
    int strongShield;  // 1.8 -- cost 15 Amagus
    int titaniumShield; // 2.0 -- cost 20 Amagus

    [Header("Shield Stock Quantity")]
    // Shield Stock Quantity
    public int nOneQuantity = 5; // Shield One
    public int nTwoQuantity = 4; // Shield Two
    public int nTresQuantity = 3; // Shield Three
    public int nQuadQuantity = 2; // Shield Four

    [Header("Set Time For Restock in Seconds")]
    public int RestockA1 = 30;
    public int RestockA2 = 60;
    public int RestockA3 = 90;
    public int RestockA4 = 180;

    public enum ShieldSelection
    {
        PTS_Shield1 = 100, // Aegis Basic 
        PTS_Shield2 = 100 + 20, // Aegis Hard  
        PTS_Shield3 = 100 + 40, // Aegis Defender
        PTS_Shield4 = 100 + 80, // Aegis Prime 
        PTS_Shield5 = 100 + 100 // Aegis Giga Prime
    }

    public ShieldSelection currentShield;

    // Start is called before the first frame update
    void Start()
    {
        switch (currentShield)
        {
            case ShieldSelection.PTS_Shield1:
                Debug.Log("You've been equipped with an Aegis Basic Shield");
                break;

            case ShieldSelection.PTS_Shield2:
                Debug.Log("You've selected Aegis Hard.");
                break;

            case ShieldSelection.PTS_Shield3:
               Debug.Log("You've selected the Aegis Defender.");
               break;

            case ShieldSelection.PTS_Shield4:
               Debug.Log("You've selected the Aegis Prime.");
               break;
            case ShieldSelection.PTS_Shield5:
               Debug.Log("You've selected the Aegis Giga Prime.");
               break;
        }
    }

    public void Update()
    {
        InventoryRestock();
    }

    private bool bResetStock = false;
    public void InventoryRestock()
    {
        if (bResetStock == false)
        {
            bResetStock = true;
            StartCoroutine(RestockShields());
        }
        else
        {
            return;
        }
    }

    public void UpdateShieldUI()
    {

    }

    IEnumerator RestockShields()
    {
        yield return new WaitForSeconds(RestockA1);
        nOneQuantity += 1;
        yield return new WaitForSeconds(RestockA2);
        nTwoQuantity += 1;
        yield return new WaitForSeconds(RestockA3);
        nTresQuantity += 1;
        yield return new WaitForSeconds(RestockA4);
        nQuadQuantity += 1;
        yield return new WaitForSeconds(5);
        bResetStock = false;

    }
}
