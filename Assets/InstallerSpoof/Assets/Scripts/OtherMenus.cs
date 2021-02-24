using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherMenus : MonoBehaviour
{
    #region Variables

    public Text DeliveryText;
    public Text ShieldPurchaseText;

    public bool isClicked = false;
    public bool isDDMenuOpen = false;
    public bool isItemOpen = false;
    public GameObject DeliveryServiceMenu;
    public GameObject ItemShopMenu;
    public GameObject RetrieveAmagus;

    public int foodCount = 0;
    public Text FoodText;

    public AudioSource MenuAudioSource;
    private AudioSource ItemShopSource;
    public AudioClip PurchaseSuccessDing;
    public AudioClip PurchaseFailureWhomp;

    #endregion

    // actual game object
    public bool isInMenu = false;

    public void SucessSound()
    {
        MenuAudioSource.PlayOneShot(PurchaseSuccessDing);
    }
    public void FailureSound()
    {
        MenuAudioSource.PlayOneShot(PurchaseFailureWhomp);
    }

    // Start is called before the first frame update
    void Start()
    {
        isDDMenuOpen = false;
        isClicked = false;
        isInMenu = false;

        MenuAudioSource = GetComponent<AudioSource>(); // For Delivery
        //ItemShopSource = GetComponent<AudioSource>(); // For Shields
    }

    // Update is called once per frame
    void Update()
    {
        MenuDebugs();

        if (DeliveryServiceMenu.activeInHierarchy == true)
        {
            ItemShopMenu.SetActive(false);
            return;
        }

        else if (ItemShopMenu.activeInHierarchy == true)
        {
            DeliveryServiceMenu.SetActive(false);
            return;
        }

        // Other Variables

    }

    public void UpdateMenuUI()
    {
        FoodText.text = "Food Count: " + foodCount.ToString();
    }

    #region FoodSelection

    public void CheeseMac()
    {
        if (RetrieveAmagus.GetComponent<GameManager>().AmaCoin >= 0.5)
        {
            foodCount += 1; // adds value
            Debug.Log("You have " + foodCount + " food resources.");

            MenuAudioSource.PlayOneShot(PurchaseSuccessDing); // plays sound

            RetrieveAmagus.GetComponent<GameManager>().RemoveAmagus();
            Debug.Log("Removing specified amount."); // removes curreny

            DeliveryText.text = "You've brought some Spicy Mango Devil Mac.";
            Debug.Log("You've brought some Spicy Mango Devil Mac.");
        }

        else if (RetrieveAmagus.GetComponent<GameManager>().AmaCoin < 0.49)
        {
            Debug.Log("Error: Purchase Declined."); // declined due to not having enough
            MenuAudioSource.PlayOneShot(PurchaseFailureWhomp);
        }
              
    }

    public void Pizza()
    {
        if (RetrieveAmagus.GetComponent<GameManager>().AmaCoin >= 0.7)
        {
            foodCount += 1; // adds value
            Debug.Log("You have " + foodCount + " food resources.");

            MenuAudioSource.PlayOneShot(PurchaseSuccessDing); // plays sound

            RetrieveAmagus.GetComponent<GameManager>().RemoveAmagus();
            Debug.Log("Removing specified amount."); // removes curreny

            DeliveryText.text = "You've brought pepper and goatcheese pizza.";
            Debug.Log("Pizza.");
        }

        else if (RetrieveAmagus.GetComponent<GameManager>().AmaCoin < 0.69)
        {
            Debug.Log("Error: Purchase Declined."); // declined due to not having enough
            MenuAudioSource.PlayOneShot(PurchaseFailureWhomp);
        }


        DeliveryText.text = "You've brought pepper and goatcheese pizza.";
        Debug.Log("Pizza.");
    }

    public void Wings()
    {
        if (RetrieveAmagus.GetComponent<GameManager>().AmaCoin >= 0.3 )
        {
            foodCount += 1; // adds value
            Debug.Log("You have " + foodCount + " food resources.");

            MenuAudioSource.PlayOneShot(PurchaseSuccessDing); // plays sound

            RetrieveAmagus.GetComponent<GameManager>().RemoveAmagus();
            Debug.Log("Removing specified amount."); // removes curreny

            DeliveryText.text = "You've brought burnin' backstabbing wings."; // confirmation message
            Debug.Log("Wings.");
        }

        else if (RetrieveAmagus.GetComponent<GameManager>().AmaCoin < 0.2)
        {
            Debug.Log("Error: Purchase Declined."); // declined due to not having enough
            MenuAudioSource.PlayOneShot(PurchaseFailureWhomp);
        }

    }

    public void Fries()
    {
        if (RetrieveAmagus.GetComponent<GameManager>().AmaCoin >= 0.4)
        {
            foodCount += 1; // adds value
            Debug.Log("You have " + foodCount + " food resources.");

            MenuAudioSource.PlayOneShot(PurchaseSuccessDing); // plays sound

            RetrieveAmagus.GetComponent<GameManager>().RemoveAmagus();
            Debug.Log("Removing specified amount."); // removes curreny

            DeliveryText.text = "You've brought some cheesy gullotine fries.";
            Debug.Log("Fries.");
        }

        else if (RetrieveAmagus.GetComponent<GameManager>().AmaCoin < 0.39)
        {
            Debug.Log("Error: Purchase Declined."); // declined due to not having enough
            MenuAudioSource.PlayOneShot(PurchaseFailureWhomp);
        }
    }

    public void Calzone()
    {
        if (RetrieveAmagus.GetComponent<GameManager>().AmaCoin >= 1)
        {
            foodCount += 1; // adds value
            Debug.Log("You have " + foodCount + " food resources.");

            MenuAudioSource.PlayOneShot(PurchaseSuccessDing); // plays sound

            RetrieveAmagus.GetComponent<GameManager>().RemoveAmagus();
            Debug.Log("Removing specified amount."); // removes curreny

            DeliveryText.text = "You've brought a spicy brimstone calzone.";
            Debug.Log("Calzone.");
        }

        else if (RetrieveAmagus.GetComponent<GameManager>().AmaCoin < .99)
        {
            Debug.Log("Error: Purchase Declined."); // declined due to not having enough
            MenuAudioSource.PlayOneShot(PurchaseFailureWhomp);
        }

        
    }

    #endregion

    public void ActivateDeliveryMenu()
    {
        isClicked = true;

        if (isDDMenuOpen == false && isClicked == true)
        {
            isDDMenuOpen = true;
            isInMenu = true;
            DeliveryServiceMenu.SetActive(true);
            Debug.Log("Delivery Menu is Activated.");

            isClicked = false;
            return;
        }

        if (ItemShopMenu.activeInHierarchy == true)
        {
            ItemShopMenu.SetActive(false);
        }
    }

    public void DeactivateDeliveryMenu()
    {

        if (isDDMenuOpen == true && isClicked == true)
        {
            isDDMenuOpen = false;
            isInMenu = false;
            DeliveryServiceMenu.SetActive(false);
            Debug.Log("Delivery Menu has been deactivated.");

            isClicked = false;
            return;
        }
        
    }

    public void ActivateItemMenu()
    {
        isClicked = true;

        if (isItemOpen == false && isClicked == true)
        {
            // set bool to true
            isItemOpen = true;
            isInMenu = true;
            ItemShopMenu.SetActive(true);
            Debug.Log("Item shop has been activated.");

            isClicked = false; // return isClicked to false;
            return;
        }

        if (DeliveryServiceMenu.activeInHierarchy == true)
        {
            DeliveryServiceMenu.SetActive(false);
        }
    }

    public void ShieldSelected()
    {
        Debug.Log("You have purchased shield one.");
        ShieldPurchaseText.text = "You've brought an Altus Basic Shield.";
    }

    public void DeactiveItemMenu()
    {
        if (isItemOpen == true && isClicked == true)
        {
            isItemOpen = false;
            isInMenu = false;
            ItemShopMenu.SetActive(false);
            Debug.Log("Item shop has been deactivated.");

            isClicked = false;
            return;
        }
    }

    public void MenuDebugs()
    {
        if (DeliveryServiceMenu.activeInHierarchy == true)
        {
            Debug.Log("Delivery is open.");
        }
    }


    #region DEPRICATED

    //public void RemoveFoodandAddHealth()
    //{
    //    Food -= 1;
    //    RetrieveAmagus.GetComponent<GameManager>().PlayerHealth += 25; // adds 25 health is player Health when eating
    //}

    //public void DrainFood()
    //{
    //    RetrieveAmagus.GetComponent<GameManager>().PlayerHunger -= 0.2f * Time.deltaTime; // drains Hunger by 0.2 each last framerate
    //}
    #endregion
}
