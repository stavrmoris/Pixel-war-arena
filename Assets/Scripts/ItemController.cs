using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject item;
    public Sprite sprite;

    void Start() => sprite = GetComponent<SpriteRenderer>().sprite;
}
