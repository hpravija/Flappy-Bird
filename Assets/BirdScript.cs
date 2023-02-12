using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float flapStrenght;
    public LogicScript logicScript;
    private bool birdIsAlive = true;
    public float heightOffset = 12.5f;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("LogicScript").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            rigidbody2D.velocity = Vector2.up * flapStrenght;
        }

        float currentHeight = transform.position.y;

        if (currentHeight < (-heightOffset) || currentHeight > heightOffset)
        {
            logicScript.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.gameOver();
        birdIsAlive = false;
    }
}
