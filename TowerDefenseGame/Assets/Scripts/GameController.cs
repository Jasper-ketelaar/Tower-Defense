using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public GameObject Enemy;
    private double elapsedTime;
    public double secondsBetweenSpawn;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = secondsBetweenSpawn;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        elapsedTime += Time.deltaTime;

        if (elapsedTime < secondsBetweenSpawn)
        {
            return;
        }
        elapsedTime = 0;
        GameObject test = Instantiate(Enemy, start.transform.position, Quaternion.identity);
        EnemyScript script = test.GetComponent<EnemyScript>();
        script.End = end;

    }
}
