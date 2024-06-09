using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using TMPro;
using System.Reflection.Emit;

public class CollectObjects : MonoBehaviour
{
    int score;
    bool startDeleteMessage;
    float timer;
    int nbPetrolCansCollected;
    void Start()
    {
        score = 0;
        startDeleteMessage = false;
        timer = 0.0f;
        nbPetrolCansCollected = 0;
        //GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "";
        DisplayMessageToUser("");
    }

    
    void Update()
    {
        if (startDeleteMessage)
        {
            timer = timer + Time.deltaTime;
            if (timer >= 2)
            {
                //GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "";
                DisplayMessageToUser("");
                timer = 0.0f;
                startDeleteMessage = false;
            }
            
        }

                
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.gameObject.tag == "pick_me" || hit.collider.gameObject.tag == "petrol-can")
        {
            string label = hit.collider.gameObject.tag;
            print("collision with " + label);
            score = score + 1;
            //if (score == 1)
            //{
                //GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "You collected " + score + " Box!";
            //}
            //if (score > 1)
            //{
                //GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "You collected " + score + " Boxes!";
            //}
            startDeleteMessage = true;
            if (score >= 4 && SceneManager.GetActiveScene().name == "First Scene")
                SceneManager.LoadScene("Second Scene");
            print("score: " + score);
            if (hit.collider.gameObject.tag == "petrol-can")
            {
                nbPetrolCansCollected++;
                //if (nbPetrolCansCollected == 1)
                //{
                //print("Collected " + nbPetrolCansCollected + " can");
                //}
                //if (nbPetrolCansCollected > 1)
                //{
                //print("Collected " + nbPetrolCansCollected + " cans");
                //}
                if (nbPetrolCansCollected == 1)
                {
                    //GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "Collected " + nbPetrolCansCollected + " can";
                    //DisplayMessageToUser("Collected " + nbPetrolCansCollected + " can");
                    DisplayMessageToUser("Collected " + nbPetrolCansCollected + " can");
                }
                if (nbPetrolCansCollected > 1)
                {
                    //GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "Collected " + nbPetrolCansCollected + " cans";
                    DisplayMessageToUser("Collected " + nbPetrolCansCollected + " cans");
                }
            }
            Destroy(hit.collider.gameObject);
            
            
        }
        if (hit.collider.gameObject.tag == "helicopter")
        {
            if (nbPetrolCansCollected < 3)
            {
                DisplayMessageToUser("You need 3 cans to fly the plane");
                startDeleteMessage = true;
            }
            else
            {
                DisplayMessageToUser("Well done, you can now fly the plane and leave the island");
                startDeleteMessage = true;
                
            }
        }
    }
    void DisplayMessageToUser(string messageToDisplay)
    {
        GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = messageToDisplay;
        startDeleteMessage = true;
    }
}
