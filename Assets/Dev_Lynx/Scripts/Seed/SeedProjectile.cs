using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeedProjectile : MonoBehaviour
{
        #region Variables

        [Header("Projectile Variable Fields - Seed")]
        [SerializeField] GameObject plantToGrow;
        [SerializeField] private string growthAreaTag;

        Rigidbody rb;
        Quaternion spawnRotation;
        private Collision col;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start() {
            rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision) {

            if(collision.gameObject.CompareTag("Growth Surface")) {
                rb.isKinematic = true;
                spawnRotation = Quaternion.LookRotation(collision.contacts[0].normal);
                col = collision;
            }
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public void GrowPlant() {
            if(plantToGrow != null && col.gameObject.CompareTag(growthAreaTag)){
                Instantiate(plantToGrow, transform.position, spawnRotation);
            }
            Destroy(gameObject);
        }

        #endregion
}
