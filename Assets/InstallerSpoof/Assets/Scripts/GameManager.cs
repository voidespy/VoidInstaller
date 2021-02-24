using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region InspectorVariables

    // Variables
    public GameObject ShieldManager;
    public GameObject MenuObject;

    // Music Button
    public AudioSource MusicSource;
    public bool bIsMusicOn = true;


    // Shield
    public bool bIsShieldOn = false; // Apply ShieldPoints
    //public Text ShieldButtonText;
    public Text ShieldText;
    public float ShieldPoints = 110;
    private bool ShieldApplied = false;
    public Button ApplyPatch;

    public Text nShield01;
    public Text nShield02;
    public Text nShield03;
    public Text nShield04;


    float ShieldRating;

    // Sanity
    public Text sysHealth; // changed from sanity to system integrity
    public float sysIntegrity = 100;
    float maxSysIntegrity = 100;
    public static float Percentage;


    // Health
    public Text HealthText;
    public int PlayerHealth = 100;

    // Hunger
    public float PlayerHunger = 100;
    public Text playerHangry;
    public bool isFastFoodDrain = false;
    private bool ForSomethingFunny = true;

    // Coins
    public float AmaCoin = 0.3f;
    public Text AmagusCoin;

    public float AddAmaBy = 0.5f;
    public float RemoveAmaBy = 0.7f;

    // BEEL CHANCE

    float BeelChance;
    public float BeelTime = 60;
    public bool isBeelTime = false;

    // MAMMON CHANCE

    float MammonChance;
    public float MammonTime = 80;
    public bool isMammonTime = false;

    // GameViewBorder
    public GameObject GameView;
    public bool bBlockShown = true;

    #endregion


    #region ShieldAmends

    public void SetShield01() // > Greater than    < Less Than
    { 
        if (AmaCoin >= 5f && ShieldManager.GetComponent<ShieldSelector>().nOneQuantity >= 1)
        {
            ShieldPoints = ShieldPoints + 25;
            AmaCoin = AmaCoin - 5;
            ShieldManager.GetComponent<ShieldSelector>().nOneQuantity--;
            Debug.Log("Shield 01: Purchased.");
            MenuObject.GetComponent<OtherMenus>().SucessSound();
        }
        else if (ShieldManager.GetComponent<ShieldSelector>().nOneQuantity <= 0)
        {
            Debug.Log("Error: No More Shields in Stock.");
            MenuObject.GetComponent<OtherMenus>().FailureSound();
        }
        else if (AmaCoin < 4.9f)
        {
            Debug.Log("Error: You don't have enough Amagus.");
            MenuObject.GetComponent<OtherMenus>().FailureSound();
        }
    }

    public void SetShield02()
    {
        if (AmaCoin >= 10f && ShieldManager.GetComponent<ShieldSelector>().nTwoQuantity >= 1)
        {
            ShieldPoints = ShieldPoints + 50;
            AmaCoin = AmaCoin - 10;
            Debug.Log("Shield 02: Purchased.");
            ShieldManager.GetComponent<ShieldSelector>().nTwoQuantity--;
            MenuObject.GetComponent<OtherMenus>().SucessSound();
        }
        else if (ShieldManager.GetComponent<ShieldSelector>().nTwoQuantity == 0)
        {
            Debug.Log("Error: No More Shields in Stock.");
            MenuObject.GetComponent<OtherMenus>().FailureSound();
        }
        else if (AmaCoin < 9.9f)
        {
            Debug.Log("Error: You don't have enough Amagus.");
            MenuObject.GetComponent<OtherMenus>().FailureSound();
        }
    }

    public void SetShield03()
    {
        if (AmaCoin >= 20f && ShieldManager.GetComponent<ShieldSelector>().nTresQuantity >= 1)
        {
            ShieldPoints = ShieldPoints + 75;
            AmaCoin = AmaCoin - 20;
            Debug.Log("Shield 03: Purchased.");
            ShieldManager.GetComponent<ShieldSelector>().nTresQuantity--;
            MenuObject.GetComponent<OtherMenus>().SucessSound();
        }
        else if (ShieldManager.GetComponent<ShieldSelector>().nTresQuantity == 0)
        {
            Debug.Log("Error: No More Shields in Stock.");
            MenuObject.GetComponent<OtherMenus>().FailureSound();
        }
        else if (AmaCoin < 19.9f)
        {
            Debug.Log("Error: You don't have enough Amagus.");
            MenuObject.GetComponent<OtherMenus>().FailureSound();
        }
    }

    public void SetShield04()
    {
        if (AmaCoin >= 35 && ShieldManager.GetComponent<ShieldSelector>().nQuadQuantity >= 1)
        {
            ShieldPoints = ShieldPoints + 100;
            AmaCoin = AmaCoin - 35;
            Debug.Log("Shield 04: Purchased.");
            ShieldManager.GetComponent<ShieldSelector>().nQuadQuantity--;
            MenuObject.GetComponent<OtherMenus>().SucessSound();
        }
        else if (ShieldManager.GetComponent<ShieldSelector>().nQuadQuantity == 0)
        {
            Debug.Log("Error: No More Shields in Stock.");
            MenuObject.GetComponent<OtherMenus>().FailureSound();
        }
        else if (AmaCoin < 34.9f)
        {
            Debug.Log("Error: You don't have enough Amagus.");
            MenuObject.GetComponent<OtherMenus>().FailureSound();
        }
    }


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        AmaCoin = 0.3f;
        ShieldManager.GetComponent<ShieldSelector>();

        // References
        MusicSource = GameObject.Find("GUICamera").GetComponent<AudioSource>();
        GetGameReferences();
        
    }

    // Update is called once per frame
    void Update()
    {
        ValueClamp();
        GameViewCheck();
        ShieldAppliedCheck();

        if (Input.GetKeyDown(KeyCode.G))
        {
            AddAmagus();
        }

        // Chance Things

        // Beel
        BeelTime -= Time.deltaTime;

        // Mammon

        MammonTime -= Time.deltaTime;

        UpdateStates();

        if (BeelTime <= 0)
        {
            // both functions below work! -- no chance is kind of better tho, I should modulus 2 for Mammon
            BeelNoChance();  
            //RandBeel();
        }

        if (MammonTime <= 0)
        {
            MammonNoChance();
        }


        if (ForSomethingFunny == true)
        {
            if (isFastFoodDrain == true)
            {
                PlayerHunger -= 3.4f * Time.deltaTime;
            }

            else if (isFastFoodDrain == false)
            {
                PlayerHunger -= 0.2f * Time.deltaTime;
                return;

            }
        }

        // Values


    }

    private void GetGameReferences()
    {
        ShieldManager = GameObject.FindGameObjectWithTag("ShieldManager");
        MenuObject = GameObject.FindGameObjectWithTag("SideMenus");
        GameView = GameObject.FindGameObjectWithTag("GameSpace");

        return;

    }

    // Shield Points Allocator
    public void RunShieldFunction()
    {
        return;
    }

    #region ShieldPoints
    public void ApplyS01()
    {
        // Look To Food Service
    }

    #endregion


    public void ShieldAppliedCheck()
    {
        if (bIsShieldOn == true && ShieldPoints == 100f)
        {
            ShieldApplied = true;
        }

        if (ShieldApplied == true)
        {
            // want this button to go null, cancels all calls when the button presses and changes the color to grey.
            ApplyPatch.onClick = null;
            ApplyPatch.CancelInvoke();
            ApplyPatch.image.color = Color.grey;

            // when this can be used again, it should change the color back to purple, and remove the cancel invoke
        }
    }

    public void GameViewCheck()
    {
        // checks to see if blocks are active, when blocks are not active the player is in a menu, and should be set to false
        if (MenuObject.GetComponent<OtherMenus>().isInMenu == false)
        {
            bBlockShown = true;
        }

        else if (MenuObject.GetComponent<OtherMenus>().isInMenu == true)
        {
            bBlockShown = false;
        }
        
            // then set the values

        if (bBlockShown == false )
        {
            GameView.SetActive(false);
        }

        else if (bBlockShown == true)
        {
            GameView.SetActive(true);
        }
    }

    public void ShieldValueCheck()
    {
        // checks the value of the shield, if it's above 0 shield will be damaged, if it's below zero system integrity will be damaged

        if (ShieldPoints > 0)
        {
            // remove shield points
            ShieldPoints -= 1f * Time.deltaTime; // ShieldPoints = (ShieldPoints - 1) * Time.deltaTime; doesn't work
        }

        else if (ShieldPoints <= 0)
        {
            // remove system integrity
            sysIntegrity -= 0.3f * Time.deltaTime;
        }
    }

    #region ValueClamps&UI

    public void ValueClamp()
    {
        PlayerHunger = Mathf.Clamp(PlayerHunger, 0f, 100f);
        PlayerHealth = Mathf.Clamp(PlayerHealth, 0, 100);
        AmaCoin = Mathf.Clamp(AmaCoin, -1.3f, 99.9f);
        sysIntegrity = Mathf.Clamp(sysIntegrity, 0f, 100f);
        ShieldPoints = Mathf.Clamp(ShieldPoints, 0, 250);
    }

    public void UpdateStates()
    {
        UpdateUI(); // Updating the UI
        DebugInput(); // Input Debug For Testing
        TakeOneFood(); // For Eating by Pressing E
        DeathStates(); // Death States
        //DrainFood(); // Food Drain
    }

    public void UpdateUI()
    {
        HealthText.text = "Health: " + PlayerHealth.ToString();
        ShieldText.text = "Shield: " + ShieldPoints.ToString();
        sysHealth.text = "Sys Integrity: " + sysIntegrity.ToString();
        AmagusCoin.text = "Amagus: " + AmaCoin.ToString();
        playerHangry.text = "Hunger: " + PlayerHunger.ToString();

        MenuObject.GetComponent<OtherMenus>().UpdateMenuUI();

        RelayShieldQuantity();

    }

    #endregion

    // ____ BUTTONS

    public void PlayButton()
    {
        SceneManager.LoadScene("01");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("VOIDINSTALLER");
    }

    // --- Game Buttons

    bool bShieldClicked = false;
    bool bFirstTime = true;
    public void ShieldOn()
    {
        bIsShieldOn = true;
        //ShieldButtonText.text = "Apply ShieldPoints: On";

        if (bIsShieldOn == true && bShieldClicked == true && bFirstTime == true)
        {
            ShieldPoints = 100;
        }

        if (bIsShieldOn == false && bShieldClicked == true && bFirstTime == false)
        {
            RunShieldFunction();
        }
    }



    #region Music
    //_ MUSIC SHENANIGANS

    public void MusicButton()
    {
        MusicSource.enabled = !MusicSource.enabled;
    }

    public void ToggleMusic()
    {
        MusicSource.enabled = !MusicSource.enabled;
    }

    private bool bMusicClicked = false;

    public void ActiveMusic()
    {
        bMusicClicked = true; 

        if (bIsMusicOn == false && bMusicClicked == true)
        {
            MusicSource.Pause();
            bIsMusicOn = false;
            bMusicClicked = false;
            return;
        }
    }

    public void DeActivateMusic()
    {
        bMusicClicked = true;

        if (bIsMusicOn == true && bMusicClicked == true)
        {
            MusicSource.UnPause();
            bIsMusicOn = true;
            bMusicClicked = false;
            return;
        }
    }
    #endregion

    #region Encounters
    // _ Random Beel Encounter

    public void BeelNoChance()
    {
        isBeelTime = true;

        if (isBeelTime == true && BeelTime <= 0 && MenuObject.GetComponent<OtherMenus>().foodCount > 0)
        {

            Debug.Log("Beel is hungry, and you have food.");
            MenuObject.GetComponent<OtherMenus>().foodCount--;

            ResetBeelTime();
        }

        else if (isBeelTime == true && BeelTime <= 0 && MenuObject.GetComponent<OtherMenus>().foodCount <= 0)
        {
            Debug.Log("Beel is hungry, wheres the food?");
            PlayerHealth -= 25;

            ResetBeelTime();
        }

    }

    public void RandBeel()
    {
        // Beelzebub gets hungry every x interval will also be for Mammon in another method
        isBeelTime = true;
        BeelChance = Random.Range(0, 1);

        if (BeelChance >= .6f && isBeelTime == true && BeelTime <= 0)
        {
            BeelHasArrived();
        }

        else if (BeelChance <= .5f && BeelTime <= 0 && isBeelTime == true)
        {
            Debug.Log("You've dodged a Beel.");
            ResetBeelTime();
        }

    }

    public void BeelHasArrived()
    {

        //
        if (isBeelTime == true && BeelTime == 0 && MenuObject.GetComponent<OtherMenus>().foodCount > 0)
        {
            Debug.Log("Beel is hungry, and you have food.");
            MenuObject.GetComponent<OtherMenus>().foodCount--;

            ResetBeelTime();
        }

        else if (isBeelTime == true && BeelTime == 0 && MenuObject.GetComponent<OtherMenus>().foodCount <= 0)
        {
            Debug.Log("Beel is hungry, wheres the food?");
            PlayerHealth -= 25;

            ResetBeelTime();
        }       
    }

    public void ResetBeelTime()
    {
        isBeelTime = false;
        BeelTime = 60;
    }

    // _ Random Mammon Encounter
    public void MammonNoChance()
    {
        isMammonTime = true;

        if (isMammonTime == true && MammonTime <= 0 && AmaCoin > 0.5)
        {

            Debug.Log("The Great Mammon needs some money");
            //RemoveAmagus();
            AmaCoin -= Random.Range(0, 3);

            ResetMammonTime();
        }

        else if (isMammonTime == true && MammonTime <= 0 && AmaCoin <= 0.4)
        {
            Debug.Log("Ay! Why don't you have any coin. You need enough for when Beel comes around.");
            PlayerHealth -= 5;

            ResetMammonTime();
        }
    }
    public void ResetMammonTime()
    {
        isMammonTime = false;
        MammonTime = 80;
    }

    #endregion

    public void DebugInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Health has been damaged.");
            PlayerHealth--;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("System Integrity is failing.");
            sysIntegrity--;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("ShieldPoints has been lowered.");
            ShieldPoints--;
        }
    }

    // System Checks

    public void RelayShieldQuantity()
    {
        nShield01.text = ShieldManager.GetComponent<ShieldSelector>().nOneQuantity.ToString();
        nShield02.text = ShieldManager.GetComponent<ShieldSelector>().nTwoQuantity.ToString();
        nShield03.text = ShieldManager.GetComponent<ShieldSelector>().nTresQuantity.ToString();
        nShield04.text = ShieldManager.GetComponent<ShieldSelector>().nQuadQuantity.ToString();
    }

    #region SystemChecks

    void PersShieldCheck()
    {
        if ((ShieldPoints == 0))
        {
            Debug.Log("Shields have been depeleted.");
        }

        else if ((ShieldPoints >= 50))
        {
            Debug.Log("ShieldPoints is at half capacity, consider getting a better guard.");
        }

        else if ((ShieldPoints <= 90))
        {
            Debug.Log("Device's Shielding is optimal.");
        }

    }

    void PersSanityCheck()
    {
        if ((sysIntegrity == 0))
        {
            Debug.Log("The system has been destroyed.");
            //PlayerHealth--;
        }
        else if ((sysIntegrity >= 50))
        {
            Debug.Log("System Integrity is halfway.");
        }

        else if ((sysIntegrity <= 90))
        {
            Debug.Log("The system is at 100%");
        }
    }

    void PersHealthCheck()
    {
        if ((PlayerHealth == 0))
        {
            Debug.Log("The players health has been depleted.");
        }

        else if ((PlayerHealth <= 50))
        {
            Debug.Log("The player is at half health.");
        }

        else if ((PlayerHealth >= 75))
        {
            Debug.Log("The player is at 75% Health, if at or above 75% this will recharge sanity.");
            sysIntegrity++;
        }

        else if ((PlayerHealth <= 90))
        {
            Debug.Log("Health is optimal.");
        }
    }

    #endregion

    // Show Values Scriptings

    #region DrainingValues

    public void DrainFood()
    {
        PlayerHunger -= 0.2f * Time.deltaTime; // drains Hunger by 0.2 each last framerate
    }

    public void FasterFoodDrain()
    {
        PlayerHunger -= 2.3f * Time.deltaTime;
    }

    public void SystemDrain()
    {
        //sysIntegrity -= 1 * Time.deltaTime; // want to change this into a percentage on screen

        Percentage = (sysIntegrity / maxSysIntegrity * 100);
    }
    #endregion

    // Editing Values

    #region ValueEditing

    public void RemoveAmagus() // Remove Currency
    {
        AmaCoin = AmaCoin - RemoveAmaBy;
    }
    public void AddAmagus() // Add Currency
    {
        AmaCoin = AmaCoin + AddAmaBy;
    }
    public void EnemyAmagus()
    {
        AmaCoin = AmaCoin + 0.1f;
    }
    public void MBAmagus()
    {
        AmaCoin = AmaCoin + 0.6f;
    }
    public void DamageSystem()
    {
        sysIntegrity -= 0.3f * Time.deltaTime;
    }

    #endregion

    //_ EATING FOOD 
    #region Food
    public void TakeOneFood()
    {
        if (MenuObject.GetComponent<OtherMenus>().foodCount > 0 && Input.GetKeyDown(KeyCode.E) && PlayerHunger <= 90)
        {
            PlayerHunger += 15; // it was added PlayerHealth to PlayerHealth
            RemoveFoodandAddHealth();
            Debug.Log("You have " + MenuObject.GetComponent<OtherMenus>().foodCount + " food resources.");
            Debug.Log("You have eaten one food, " + "Added 25 Health");
            return;
        }

        else if (MenuObject.GetComponent<OtherMenus>().foodCount <= 0 && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("You don't have any food resources.");
            return;
        }

        else if (MenuObject.GetComponent<OtherMenus>().foodCount > 0 && Input.GetKeyDown(KeyCode.E) && PlayerHunger >= 100)
        {
            Debug.Log("You are full.");
            return;
        }

        else if (MenuObject.GetComponent<OtherMenus>().foodCount <= 0 && Input.GetKeyDown(KeyCode.E) && PlayerHunger >= 100)
        {
            Debug.Log("You are full, and you have no food.");
            return;
        }





    }
    public void RemoveFoodandAddHealth()
    {
        MenuObject.GetComponent<OtherMenus>().foodCount -= 1;
        PlayerHealth += 25; // adds 25 health is player Health when eating
        Debug.Log("Munch, munch.");
    }

    #endregion

    #region DeathStates
    public void DeathStates() // DeathState and Transition
    {
        if (PlayerHunger <= 0 || PlayerHealth <= 0)
        {
            
            Debug.Log("You have died of hunger.");
            SceneManager.LoadScene("Death01");
        }

        if (sysIntegrity <= 0)
        {
            Debug.Log("You have blue-screened.");
            SceneManager.LoadScene("Death02");
        }

        if (SceneManager.GetActiveScene().name == "Death01" || SceneManager.GetActiveScene().name == "Death01")
        {
            Debug.Log("Game Over Bud...");
            Application.Quit();
        }
    }

    #endregion
}





#region DEPRICATED CODE
/// DEPRECATED OR UNWORKING CODE

//public void ShowValues()
//{
//    Text[] texts = FindObjectsOfType<Text>();

//    for (int i = 0; i < texts.Length; i++)
//    {
//        if (texts[i].name == "ShieldText")
//        {
//            ShieldText = texts[i];
//        }
//        else if (texts[i].name == "HealthText")
//        {
//            HealthText = texts[i];
//        }
//        else if (texts[i].name == "sysHealth")
//        {
//            sysHealth = texts[i];
//        }
//        else if (texts[i].name == "AmagusCoins")
//        {
//            AmagusCoin = texts[i];
//        }
//    }
//}  



//void ShowShield()
//{
//    if (ShieldText)
//    {
//        ShieldText.text = string.Format("Shield: ", ShieldPoints);
//    }       
//}

//void ShowCoin()
//{
//    if (AmagusCoin)
//    {
//        AmagusCoin.text = string.Format("Amagus: ", AmaCoin);
//    }        
//}

//void ShowHealth()
//{
//    if (HealthText)
//    {
//        HealthText.text = string.Format("Health: ", PlayerHealth);
//    }        
//}

//void ShowSanity()
//{
//    if (sysHealth)
//    {
//        sysHealth.text = string.Format("Sanity: ", sysIntegrity);
//    }        
//}


#endregion