using System;
using UnityEngine;
using UnityEngine.Events;

public class WaterProjectile : MonoBehaviour
{
        #region Variables

        [Header("Projectile Variable Fields - Water")]
        [SerializeField] float projectileSpeed;
        [SerializeField] float projectileRadius;
        [SerializeField] UnityEvent OnImpact;
        [SerializeField] private float projectileDamage;

        Rigidbody rb;

        #endregion

        #region MonoBehaviour Callbacks

        void OnCollisionEnter(Collision collision) {
            if(collision.gameObject.CompareTag("Growth Surface")) {
                WaterExplosion();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyAi>().TakeDamage(projectileDamage);
            }
        }

        #endregion

        #region Private Methods

        private void WaterExplosion() {
            Debug.Log("Splash!");
            FindNearbySeeds();
            OnImpact.Invoke();
            Destroy(gameObject, 0.1f);
        }

        private void FindNearbySeeds() {
            Collider[] collider = Physics.OverlapSphere(transform.position, projectileRadius);

            foreach(Collider nearbyObject in collider) {
                SeedProjectile seed = nearbyObject.GetComponent<SeedProjectile>();

                if(seed != null) {
                    seed.GrowPlant();
                }
            }
        }

        #endregion

        #region Public Methods



        #endregion
}
