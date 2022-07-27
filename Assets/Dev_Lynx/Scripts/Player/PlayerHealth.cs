using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
        #region Variables

        [Header("Player Health Variable Fields")]
        [SerializeField] Image[] hearts;
        [SerializeField] Sprite heartImage;
        public int maxHealth = 3;


        #endregion

        #region MonoBehaviour Callbacks

        void Update() {
            foreach(Image img in hearts) {
                img.sprite = null;
                img.color = Color.clear;
            }

            for(int i = 0; i < maxHealth; i++) {
                hearts[i].sprite = heartImage;
                hearts[i].color = Color.white;
            }
        }

        #endregion

        #region Private Methods


        #endregion

        #region Public Methods

        public void TakeDamage() {
            maxHealth -= 1;

            if(maxHealth == 0) {
                //OnPlayerDeath;
            }
        }

        #endregion

}
