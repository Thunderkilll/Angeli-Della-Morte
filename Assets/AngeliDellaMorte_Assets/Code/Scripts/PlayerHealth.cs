using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ADM
{
    class PlayerHealth : MonoBehaviour
    {
        private float currentHealth = 100;
        public float CurrentHealth { get { return currentHealth; }  }
        public int startingHealth = 100;                            // The amount of health the player starts the game with.
      
        public Slider healthSlider;                                 // Reference to the UI's health bar.
        public Text healthText;
        
        bool isDead;                                                // Whether the player is dead.
        bool damaged;                                               // True when the player gets damaged.


        void Awake()
        {
            // Setting up the references.
            //  anim = GetComponent<Animator>();
            //   playerAudio = GetComponent<AudioSource>();

            healthText = healthSlider.transform.GetChild(2).GetComponent<Text>();
            // Set the initial health of the player.
            currentHealth = startingHealth;
            healthText.text = currentHealth.ToString();
        }


        void Update()
        {


          
            // If the player has just been damaged...
            if (damaged)
            {
                // ... set the colour of the damageImage to the flash colour.
                Debug.Log("you've been hit");
                TakeDamage(1);
            }
            // Otherwise...
            else
            {
                // ... transition the colour back to clear.
              
            }

            // Reset the damaged flag.
            damaged = false;
        }


        public void TakeDamage(int amount)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            currentHealth -= amount;

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;

            // Play the hurt sound effect.
         
            // If the player has lost all it's health and the death flag hasn't been set yet...
            if (currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                Death();
            }
        }


        void Death()
        {
            // Set the death flag so this function won't be called again.
            isDead = true;
            Debug.Log("you die");
            Time.timeScale = 0;

        }

    }
}
