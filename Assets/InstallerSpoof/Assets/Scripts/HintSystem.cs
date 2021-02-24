using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintSystem : MonoBehaviour
{
    public Text InformationText;
    public GameObject GameRef;

    // Start is called before the first frame update
    void Start()
    {
        GetGameRef();
        StartCoroutine(HSList());
    }

    private void GetGameRef()
    {
        GameRef = GameObject.FindGameObjectWithTag("GameManager");
    }


    // Below is a list of things to say 

    IEnumerator HSList()
    {
        
        InformationText.text = "Don't forget to check out DevilDash!"; // starts with this
        yield return new WaitForSeconds(5); // waits 5 seconds to switch to the bottom one
        InformationText.text = "Try the Spicy Mango Devil Mac!";
        yield return new WaitForSeconds(3);
        InformationText.text = "Click the boxes!";
        yield return new WaitForSeconds(10);
        InformationText.text = "Watch out for Mammon! He might leave you in debt.";
        yield return new WaitForSeconds(5);
        InformationText.text = "Levia-chan says, don't forget to apply your shields! First time is free.";
        yield return new WaitForSeconds(20);
        InformationText.text = "Beel might leave you hungry as well...";
        yield return new WaitForSeconds(10);
        InformationText.text = "The AmaCoin is a highly sought after currency.";
        yield return new WaitForSeconds(10);
        InformationText.text = "These systems were hard to implements, the toughest was...";
        yield return new WaitForSeconds(5);
        InformationText.text = "Creating an item class!";
        yield return new WaitForSeconds(10);

        InformationText.text = "I didn't know what to create for the actual gameplay.";
        yield return new WaitForSeconds(5);
        InformationText.text = "My favorite character is Asmodeus, actually.";
        yield return new WaitForSeconds(2);
        InformationText.text = "I'm going to shout into the aether!";
        yield return new WaitForSeconds(2);
        InformationText.text = ":)";
        yield return new WaitForSeconds(10);
        InformationText.text = ""; // this "deletes text so to say
        yield return new WaitForSeconds(5);
        InformationText.text = "Don't pay too much attention to down here. Keep your eyes up.";
        yield return new WaitForSeconds(5);
        InformationText.text = "No, really.";
        yield return new WaitForSeconds(2);
        InformationText.text = "There are stats above, didn't you know?";
        yield return new WaitForSeconds(5);
        InformationText.text = "So, what I thought I'd do was pretend I was some sort of deaf-mute.";
        yield return new WaitForSeconds(5);
        InformationText.text = "What if increase how fast you get hungry, huh?";
        GameRef.GetComponent<GameManager>().isFastFoodDrain = true;
        yield return new WaitForSeconds(10);
        InformationText.text = "Okay, that was mean. I'll change it back.";
        GameRef.GetComponent<GameManager>().isFastFoodDrain = false;
        yield return new WaitForSeconds(3);
        InformationText.text = "";
        yield return new WaitForSeconds(3);
        InformationText.text = "Hmm";
        yield return new WaitForSeconds(3);
        InformationText.text = "When I added that it broke things...";
        yield return new WaitForSeconds(3);
        InformationText.text = "The fix was simply putting it ahead of the food drain.";
        yield return new WaitForSeconds(4);
        InformationText.text = "Belta Lowda!";
        yield return new WaitForSeconds(3);
        InformationText.text = "";
        yield return new WaitForSeconds(4);
        InformationText.text = "why you pensa?";
        yield return new WaitForSeconds(4);
        InformationText.text = "This is just a simple click game, the meat and nerves of this is the systems.";
        yield return new WaitForSeconds(2);
        InformationText.text = "";

    }

    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Started Coroutine at Timestamp : " + Time.time);
    }
}
