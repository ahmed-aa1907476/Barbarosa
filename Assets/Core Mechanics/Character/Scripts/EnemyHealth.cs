using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int counter;
    private static int killCount = 0;
    public GameObject Pickup;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            counter += 1;
        }
        if (counter == 3) {
            Instantiate(Pickup, transform.position, Quaternion.identity);
            Destroy(gameObject);
            killCount++;
            GameObject.Find("VillageQuest").GetComponent<Quest>().tempKills = killCount;
            if (killCount == 4) {
                killCount = 0;
            }
        }
    }
}
