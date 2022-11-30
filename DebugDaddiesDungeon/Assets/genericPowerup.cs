using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericPowerup : MonoBehaviour
{
    public GameObject powerUp;
    public Vector3 initialPos;
    public Vector3 newPos;

    private float upperLimit, lowerLimit;

    public bool movingDown, movingUp;

    public GameObject Player;

    //Timer to reset the double jump effect
    [SerializeField] private float cooldown = 3;
    private float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = powerUp.transform.position;
        newPos = initialPos;
        movingDown = true;
        movingUp = false;
        upperLimit = initialPos.y - 0.4f;
        lowerLimit = initialPos.y + 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingDown == true && newPos.y < upperLimit)
        {
            movingDown = false;
            movingUp = true;
        }

        if (movingUp == true && newPos.y > lowerLimit)
        {
            movingUp = false;
            movingDown = true;
        }
    }

    private void FixedUpdate()
    {
        if(movingDown)
        {
            newPos.y = newPos.y - 0.005f;
        }
        if(movingUp)
        {
            newPos.y = newPos.y + 0.005f;
        }

        powerUp.transform.position = newPos;
        powerUp.transform.Rotate(0.0f, 0.0f, 1.0f, Space.Self);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            powerUp.active = false;

            //Cant set this anywhere else as there would be 2 collision checks and unity doesnt like that
            Player.gameObject.GetComponent<PlayerFifi>().allowedJumps += 4;
            Player.gameObject.GetComponent<PlayerFifi>().jumpForce = 16;
            Player.gameObject.GetComponent<PlayerFifi>().gravityScale = 6;
            Player.gameObject.GetComponent<PlayerFifi>().resetJump = true;
        }
    }
}
