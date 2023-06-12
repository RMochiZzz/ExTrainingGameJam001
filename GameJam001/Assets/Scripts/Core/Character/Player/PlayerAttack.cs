using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat.PlayerAttackMotion
{
    public class PlayerAttack : MonoBehaviour
    {
        public GameObject PlayerBulletPrefab;
        [SerializeField] private float AttackInterval;
        public AudioClip playerAttackSE;
        private AudioSource audioSource;
        public float AttackseVolum;

        private float timer = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GManager.instance.isGameOver) return;
            if (GManager.instance.isGameClear) return;

            if (timer > AttackInterval)
            {
                Attack();
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

        public void Attack()
        {
            PlayPlayerAttackSE(AttackseVolum);
            switch (GManager.instance.LevelNum)
            {
                case 1:
                    GameObject bullet = Instantiate(PlayerBulletPrefab, transform.position, transform.rotation);
                    break;

                case 2:
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(0.25f, 0f, 0f), transform.rotation);
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(-0.25f, 0f, 0f), transform.rotation);
                    break;

                case 3:
                    threeway();
                    break;
                case 4:
                    threeway();
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(-0.5f, 0f, 0f), Quaternion.Euler(0f, 0f, 25f));
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(0.5f, 0f, 0f), Quaternion.Euler(0f, 0f, -25f));
                    break;
                case 5:
                    threeway();
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(-0.5f, 0f, 0f), Quaternion.Euler(0f, 0f, 25f));
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(0.5f, 0f, 0f), Quaternion.Euler(0f, 0f, -25f));
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(-0.8f, -0.3f, 0f), Quaternion.Euler(0f, 0f, 25f));
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(0.8f, -0.3f, 0f), Quaternion.Euler(0f, 0f, -25f));
                    break;
                case 6:
                    threeway();
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(-0.5f, 0f, 0f), Quaternion.Euler(0f, 0f, 25f));
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(0.5f, 0f, 0f), Quaternion.Euler(0f, 0f, -25f));
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(-0.8f, -0.3f, 0f), Quaternion.Euler(0f, 0f, 25f));
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(0.8f, -0.3f, 0f), Quaternion.Euler(0f, 0f, -25f));
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(-0.2f, 0.3f, 0f), Quaternion.Euler(0f, 0f, 25f));
                    Instantiate(PlayerBulletPrefab, transform.position + new Vector3(0.2f, 0.3f, 0f), Quaternion.Euler(0f, 0f, -25f));

                    break;
            }
        }

        public void threeway()
        {
            Instantiate(PlayerBulletPrefab, transform.position + new Vector3(0.4f, 0f, 0f), transform.rotation);
            Instantiate(PlayerBulletPrefab, transform.position, transform.rotation);
            Instantiate(PlayerBulletPrefab, transform.position + new Vector3(-0.4f, 0f, 0f), transform.rotation);

        }

        public void PlayPlayerAttackSE(float volumeScale)
        {
            audioSource.PlayOneShot(playerAttackSE, volumeScale);
        }
    }
}
