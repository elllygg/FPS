
using UnityEngine;


public class Shoot : MonoBehaviour
{



    
        public GameObject impactPrefabWall;    // prefab per muri
        public AudioClip shootClip;
        public GameObject impactPrefabEnemy;   // prefab particellare per nemici



        void Update()
        {
           
            if(Time.timeScale == 1f &&  Input.GetButtonDown("Fire1"))
            {
                  PlayerShoot();
            }

        }

        void PlayerShoot()
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f))
            {
                EnemyController enemy = hit.transform.GetComponentInParent<EnemyController>();

                Vector3 spawnPos = hit.point + hit.normal * 0.01f;
                Quaternion spawnRot = Quaternion.LookRotation(hit.normal);

                if (enemy != null)
                {
                    // colpo su nemico, particelle
                    if (impactPrefabEnemy != null)
                    {
                        GameObject impact = Instantiate(impactPrefabEnemy, spawnPos, Quaternion.identity);
                        Destroy(impact, 2f); // dura 2 secondi e scompare
                    }

                    enemy.TakeDamage(25f);
                }
                else
                {
                    // colpo su muro, prefab normale
                    if (impactPrefabWall != null)
                    {
                        GameObject impact = Instantiate(impactPrefabWall, spawnPos, spawnRot);
                        Destroy(impact, 5f);
                    }

                    Debug.Log("Hit wall: " + hit.transform.name);
                }

                if (AudioManager.instance != null)
                    AudioManager.instance.PlayShoot();
            }

        }
    }


