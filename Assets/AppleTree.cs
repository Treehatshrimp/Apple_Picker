using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    //Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject poisonPrefab;

    //Speed at which the AppleTree moves
    public float speed = 9f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 24f;

    //Chance that the AppleTree will change directions
    public float changeDirChance = 0.007f;

    //Seconds between Apples and poison instantiations
    public float appleDropDelay = 1f;
    public float poisonDropDelay = 10f;

    //Time before increasing the round and difficulty
    float elapsedTime = 0f;  // seconds since start
    public RoundManager roundManager; //Add the round indicator in

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Start Dropping apples
        Invoke("DropApple", 2f);
        Invoke("DropPoison", 6f);

    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
        
    }
    void DropPoison()
    {
        //Added poison
        GameObject poison = Instantiate<GameObject>(poisonPrefab);
        poison.transform.position = transform.position + new Vector3(Random.Range(-2f,2f),0f,0f);
        Invoke("DropPoison", poisonDropDelay);
    }
    void UpdateDifficulty()
    {
        // after 30 seconds
        if (elapsedTime >= 20f)
        {
            speed *= 1.3f;
            appleDropDelay *= 0.8f;
            poisonDropDelay *= 0.85f;
            elapsedTime = 0f;
            roundManager.NextRound();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        else if(Random.value < changeDirChance)
        {
            speed *= -1;
        }
        elapsedTime += Time.deltaTime; // increment by frame time
        UpdateDifficulty();
    }
    void FixedUpdate()
    {
        // Random Direction changes are now time-based due to FixedUpdate()
        if(Random.value < changeDirChance)
        {
            speed *= -1; //Change direction
        }
    }
}
