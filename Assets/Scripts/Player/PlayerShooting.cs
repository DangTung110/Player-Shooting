using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform          posGunBarrel;
    [SerializeField] private ParticleSystem     gunParticle;
    private Ray             shootRay = new Ray();
    private RaycastHit      shootHit;
    private int             shootableLayerMask;
    private LineRenderer    gunLine;
    private EnemyPoolManager enemyPoolManager;
    private float timeShooting = 0.3f;
    private void Awake()
    {
        gunLine = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        shootableLayerMask = LayerMask.GetMask("Shootable");
        gunLine.positionCount = 2;
    }
    private void Update()
    {
        timeShooting -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeShooting < 0f)
        {
            Shooting();
        }
    }
    private void Shooting()
    {
        gunLine.enabled = true;
        gunLine.SetPosition(0, posGunBarrel.position);
        shootRay.origin = posGunBarrel.position;
        shootRay.direction = posGunBarrel.forward;
        if (Physics.Raycast(shootRay, out shootHit, 100f, shootableLayerMask))
        {
            gunLine.SetPosition(1, shootHit.point);
            if (shootHit.collider.gameObject.tag == Enemy.TAG) 
            {
                shootHit.collider.gameObject.SetActive(false);
                Debug.Log("Enemy Die");
            }
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * 100f);
        }
        timeShooting = 0.3f;
        StartCoroutine(ReturnLineShoot());
    }
    private IEnumerator ReturnLineShoot()
    {
        yield return new WaitForSeconds(0.15f);
        gunLine.enabled = false;
    }
}
