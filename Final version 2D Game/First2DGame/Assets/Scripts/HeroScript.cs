using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroScript : MonoBehaviour
{
    public float jumpForce = 7.0f;
    private bool onGround = false;
    float dirX, moveSpeed;
    Rigidbody2D rb;
    public Animator anim;
    bool jump = false;
    bool Hurting = false;
    bool Dead = false;
    bool facingRight = true;
    Vector3 localScale;
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBar healthBar;
    public Transform startpoint;
    public Text Distancemoved;
    public Text Runmeters;
    private float distance;
    public int life;
    public Text lifeText;
    float healthReg;
    bool isRegenHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        FuelCanText.fuelCanAmount = 0;
        life = 3;
    }

    void Update()
    {
        if (Dead == false)
        {
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
            moveSpeed = 8f;
            anim.SetFloat("Speed", Mathf.Abs(dirX));
        }

        if (Input.GetKeyDown("up") && Dead == false)
        {
            if (onGround == true)
            {
                jump = true;
                anim.SetBool("isJumping", true);
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                onGround = false;
                SoundManager.PlaySound("Jump");
                Debug.Log("Jumping");
            }
        }

        distance = (startpoint.transform.position.x + transform.position.x);
        Distancemoved.text = distance.ToString("F0");
        Runmeters.text = distance.ToString("F0");

        if (life == 0)
        {
            Dead = true;
            anim.SetTrigger("isDead");
            dirX = 0;
            GameControl.instance.HeroDied();
        }
    }

    void FixedUpdate()
    {
        if (!Hurting)
           rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void LateUpdate()
        {
            CheckWhereToFace();
        }

    void CheckWhereToFace()
        {
            if (dirX > 0)
                facingRight = true;
            else if (dirX < 0)
                facingRight = false;

            if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
                localScale.x *= -1;

            transform.localScale = localScale;
        }

    IEnumerable Hurt()
    {
        Hurting = true;
        rb.velocity = Vector2.zero;

        if (facingRight)
             rb.AddForce(new Vector2(-200f, 200f));
        else
             rb.AddForce(new Vector2(200f, 200f));

        yield return new WaitForSeconds(2f);
         Hurting = false;
     }

    IEnumerable Death()
    {
        Debug.Log("Dead");
        Dead = true;
        yield return new WaitForSeconds(2);
        Debug.Log("Respawn");
        Dead = false;
        anim.SetTrigger("Alive");
    }

    IEnumerator RegainHealth()
        {
            isRegenHealth = true;
            currentHealth = maxHealth;
            yield return new WaitForSeconds(2);
            isRegenHealth = false;
            healthBar.SetHealth(currentHealth);
        }

    void OnCollisionEnter2D(Collision2D hit)
        {
            onGround = true;
            print("Hero has touched ground");
            anim.SetBool("isJumping", false);
        }

    void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "GunBullet(Clone)")
            {
                Debug.Log("HIT!");
                LoseHealth(10);
            }
        }

    public void ImproveHealth(float health)
        {
            if (currentHealth < maxHealth)
            {
                currentHealth += health;
                healthBar.SetHealth(currentHealth);
            }
        }

    public void LoseHealth(float damage)
    {
        if (currentHealth > damage)
        {
                currentHealth -= damage;
                anim.SetTrigger("isHurting");
                healthBar.SetHealth(currentHealth);
                StartCoroutine("Hurt");
                SoundManager.PlaySound("Hurt");
        }
        else if (currentHealth <= damage)
        {
            if (life > 0)
            {
                damage -= currentHealth;
                currentHealth = 0f;
                anim.SetTrigger("isDead");
                SoundManager.PlaySound("Dead");
                Die();
                life -= 1;
                lifeText.text = life.ToString();
            }
        }
     }

    void Die()
    {
        StartCoroutine("Death");
        StartCoroutine("RegainHealth");
    }
}

