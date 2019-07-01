using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Shooting")] //random comment
    public GameObject projectile;
    public float shootSpeed = 0.1f; //time between projectiles
    private float lastShot;
    private bool shooting;

    [Header("Slashing")]
    public GameObject swordSlash;
    [Range(0, 1)]
    [SerializeField] private float  slashOffset;
    [SerializeField] private float slashDuration;
    [SerializeField] private float slashCooldown;

    private float lastSlash = 0;
    
    private PlayerInput _input;

    void Start()
    {
        GetComponents();
    }

    // Update is called once per frame
    void Update()
    {
        SwordSlash(_input.GetAimDirection(transform.position, _input.GetCursorPosition()));
        Shoot(_input.shootButton);
    }
    private void GetComponents()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Shoot(string shootBtn)
    {
        shooting = Input.GetButton(shootBtn);
        if(!shooting) return;

        if(Time.time >= lastShot + shootSpeed)
        {
            ShootProjectile(projectile);
        }
    }
    private void ShootProjectile(GameObject projectile)
    {
        var proj = Instantiate(projectile, transform.position, Quaternion.identity);
        proj.transform.up = _input.GetAimDirection(transform.position, _input.GetCursorPosition());
        lastShot = Time.time;
    }

    public void SwordSlash(Vector2 direction)
    {
        if(direction == Vector2.zero) direction = Vector2.right; //Edgecase but might as well
        if(swordSlash.activeSelf == false)
        {
            swordSlash.transform.up = direction;
            swordSlash.transform.localPosition = direction * slashOffset;
        }
        if(Input.GetButtonDown(_input.slashButton) && Time.time > lastSlash + slashCooldown)
        {
            lastSlash = Time.time;
        }
        if(lastSlash + slashDuration > Time.time && lastSlash != 0)
        {
            swordSlash.SetActive(true);            
        }
        else
        {
            swordSlash.SetActive(false);
        }
    }

}
