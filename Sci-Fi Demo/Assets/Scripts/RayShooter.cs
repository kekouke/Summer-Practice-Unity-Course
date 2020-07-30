using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] GameObject _muzzleFlash;
    [SerializeField] GameObject _hitMarker;
    [SerializeField] GameObject _canvas;

    private int _currentAmmo;
    private int _maxAmmo = 50;
    private bool _isReload;

    private AudioSource _shootSound;

    private void Start()
    {
        _shootSound = GetComponent<AudioSource>();
        _currentAmmo = _maxAmmo;
    }

    void Update()
    {
        _canvas.GetComponent<UIManager>().DisplayAmmo(_currentAmmo);

        if (Input.GetKeyDown(KeyCode.R) && !_isReload)
        {
            _isReload = true;
            StartCoroutine(ReloadRoutine());
        }
        else if (Input.GetMouseButton(0) && _currentAmmo > 0 && !_isReload)
        {
            _currentAmmo--;

            if (_shootSound.isPlaying == false)
            {
                _shootSound.Play();
            }

            _muzzleFlash.SetActive(true);
            Shoot();
        }
        else
        {
            _shootSound.Stop();
            _muzzleFlash.SetActive(false);
        }
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        RaycastHit raycastInfo;

        if (Physics.Raycast(ray, out raycastInfo))
        {
            StartCoroutine(HitMarkerRoutine(raycastInfo));
        }

    }

    IEnumerator ReloadRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        _isReload = false;
    }

    IEnumerator HitMarkerRoutine(RaycastHit hitPoint)
    {
        GameObject hit = Instantiate(_hitMarker, hitPoint.point, Quaternion.LookRotation(hitPoint.normal));
        yield return new WaitForSeconds(0.5f);
        Destroy(hit.gameObject);
    }
}
