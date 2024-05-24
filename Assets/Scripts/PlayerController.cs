using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int health;

    [Space]
    [Header("Player Speed")]
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;

    [Space]
    [Header("Shooting Point")]
    [SerializeField] private Transform shootingPoint;

    [Space]
    [Header("Black Bullet Properties")]
    [SerializeField] private GameObject blackBullet;
    [SerializeField] private float blackBulletSpeed;
    [SerializeField] private float blackBulletCooldown;
    [SerializeField] private bool canShootBlackBullet;

    [Space]
    [Header("White Bullet Properties")]
    [SerializeField] private GameObject whiteBullet;
    [SerializeField] private float whiteBulletSpeed;
    [SerializeField] private float whiteBulletCooldown;
    [SerializeField] private bool canShootWhiteBullet;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        WhiteShooting();
        BlackShooting();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2 (horizontal, vertical) * speed;
        rb2d.velocity = movement;
    }

    void WhiteShooting()
    {
        if (!canShootWhiteBullet) return;
        else if (Input.GetButtonDown("Fire1"))
        {
            GameObject PlayerWhiteBullet = Instantiate(whiteBullet);
            Rigidbody2D whiteBulletRb2d = PlayerWhiteBullet.GetComponent<Rigidbody2D>();

            whiteBulletRb2d.AddForce(Vector2.up * whiteBulletSpeed, ForceMode2D.Impulse);
            PlayerWhiteBullet.transform.position = shootingPoint.position;

            canShootWhiteBullet = false;

            Invoke(nameof(ResetWhiteShooting), whiteBulletCooldown);
        }
    }

    void ResetWhiteShooting()
    {
        canShootWhiteBullet = true;
    }

    void BlackShooting()
    {
        if (!canShootBlackBullet) return;
        else if (Input.GetButtonDown("Fire2"))
        {
            GameObject PlayerBlackBullet = Instantiate(blackBullet);
            Rigidbody2D blackBulletRb2d = PlayerBlackBullet.GetComponent<Rigidbody2D>();

            blackBulletRb2d.AddForce(Vector2.up * whiteBulletSpeed, ForceMode2D.Impulse);
            PlayerBlackBullet.transform.position = shootingPoint.position;

            canShootWhiteBullet = false;

            Invoke(nameof(ResetWhiteShooting), whiteBulletCooldown);
        }
    }

    void ResetBlackShooting()
    {
        canShootBlackBullet = true;
    }

    public void HealthModifier(int amount)
    {
        health += amount;
    }

    void Dead()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
