using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : MonoBehaviour, IInteractuable
{
    public void Interactuar()
    {
        Destroy(gameObject);
    }
}
