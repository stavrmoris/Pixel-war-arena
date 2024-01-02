using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{    
    [SerializeField] private GameObject[] inv;
    [SerializeField] private GameObject[] invGun;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject itemObj;
    [SerializeField] private Sprite active, passive, itemSprite;
    [SerializeField]private bool canGetUp;
    private KeyCode[] _keyCodes = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, };
    
    void Update()
    {
        for (int i = 0; i < _keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(_keyCodes[i]))
            {
                weapons[i].SetActive(true);
                foreach (var obj in weapons)
                {
                    if (obj != weapons[i])
                    {
                        obj.SetActive(false);
                    }
                }   
            }
        }
        
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].activeSelf)
            {
                inv[i].GetComponent<Image>().sprite = active;
            }
            else
            {
                inv[i].GetComponent<Image>().sprite = passive;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E) && !canGetUp)
        {
            canGetUp = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("item") && canGetUp)
        {
            itemSprite = other.gameObject.GetComponent<SpriteRenderer>().sprite;
            itemObj = other.gameObject.GetComponent<ItemController>().item;
            Destroy(other.gameObject);
            
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i].activeSelf)
                {
                    var item = Instantiate(weapons[i].GetComponent<GunController>().item, spawnPoint.transform.position, Quaternion.identity);
                    var obj = Instantiate(itemObj, spawnPoint.transform.position, Quaternion.identity);
                    obj.transform.SetParent(transform);
                    Destroy(weapons[i]);
                    weapons[i] = obj;
                    invGun[i].GetComponent<Image>().sprite = itemSprite;
                }
            }
            canGetUp = false;
        }
    }
}
