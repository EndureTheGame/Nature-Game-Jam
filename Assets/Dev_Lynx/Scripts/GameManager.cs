using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
        #region Variables

        [Header("UI Variable Fields - Player")]
        [SerializeField] TMP_Text seedStash;
        [SerializeField] Image waterAmmo;

        WateringCan wateringCan;

        [Header("UI Variable Fields - Keys")]
        [SerializeField] TMP_Text keyTotal;
        [SerializeField] UnityEvent onAllKeysCollected;

        bool keysCollected = false;
        KeyManager keyManager;

        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
            keyManager = FindObjectOfType<KeyManager>();

            wateringCan = FindObjectOfType<WateringCan>();
        }

        void Update() {
            //HandleHealth();
            HandleKeys();
            HandleSeedAmmo();
            HandleWaterAmmo();
        }

        #endregion

        #region Private Methods

        private void HandleKeys() {
            keyTotal.text = keyManager.currentKeys.ToString() + " left";

            if(keyManager.currentKeys == 0 && !keysCollected) {
                onAllKeysCollected.Invoke();
                keysCollected = true;
            }

        }


        private void HandleSeedAmmo() {
            seedStash.text = wateringCan.currentSeedData.GetStash().ToString();
        }

        private void HandleWaterAmmo() {
            float waterRatio = (float)wateringCan.currentWater / (float)wateringCan.maxWater;
            Vector3 targetAmmo = new Vector3(waterRatio, 1f, 1f);

            waterAmmo.rectTransform.localScale = Vector3.Lerp(waterAmmo.rectTransform.localScale, targetAmmo, 5f * Time.deltaTime);
        }



        #endregion

        #region Game State

        bool gameHasEnded = false;

        public void GameOver()
        {
            if (gameHasEnded == false)
            {
                gameHasEnded = true;
                Debug.Log("Game Over!");

                Restart();
            }

        }

        void Restart()
        {
            SceneManager.LoadScene("GameOver");
        }

        #endregion

}
