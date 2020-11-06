using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public GameObject gameobject;
    
    public float spawnTime = 1.0f;
    public GameObject enemy;
    float deltaSpawnTime;

    public int maxSpawnCnt = 50;
    public int curSpawnCnt = 1;

    public AudioSource music;
    public AudioClip ZombieG;
    // Update is called once per frame

    private void Start()
    {
        music = gameObject.AddComponent<AudioSource>();
        music.clip = ZombieG;
        music.Play();
    }
    void Update()
    {


        


        gameobject.SetActive(false);
        if (curSpawnCnt > maxSpawnCnt) return;

        deltaSpawnTime +=  Time.deltaTime;

        if (deltaSpawnTime > spawnTime && curSpawnCnt <= 45 && curSpawnCnt > 5)
        {
            deltaSpawnTime = 0;
            float x = Random.Range(-22.0f, -18.0f);

            float z = Random.Range(-2.0f, 2.0f);

            Instantiate(enemy, new Vector3(x, 0.0f, z), Quaternion.Euler(0, 90f, 0));
            if (!music.isPlaying)
            {
                music.Play();
            }
            curSpawnCnt++;
        }
        if (deltaSpawnTime > spawnTime && curSpawnCnt <= 5)
        {
            deltaSpawnTime = 0;
            float x = Random.Range(-16.0f, -12.5f);

            float z = Random.Range(-7.0f, -3.0f);

            GameObject temp = Instantiate(enemy, new Vector3(x, 0.0f, z), Quaternion.Euler(0, 90f, 0));
            temp.GetComponent<NewBehaviourScript>().manager = this;

            curSpawnCnt++;
        }
        if(curSpawnCnt > 45)
        {
            gameobject.SetActive(true);

            Vector3 m = GameObject.Find("FirstPersonCharacter").transform.position;
            Vector3 n = GameObject.Find("Cube").transform.position;
            Debug.Log(Vector3.Distance(n, m));

            if (Vector3.Distance(n, m) < 5.5)
            {
                
                SceneManager.LoadScene("Scene3");
            }
        }
        Debug.Log(curSpawnCnt);
        
    }
}
