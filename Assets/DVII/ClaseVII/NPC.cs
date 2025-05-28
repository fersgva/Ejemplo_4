using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : MonoBehaviour
{
    
    private int[] numerosA = {5, 3, 2, 18};
    private int[] numerosB = {15, 3, 4, 18};
    private int[] numerosC = {5, 3, 2, 18};
    
    private void Start()
    {

        for (int i = 0; i < 4; i++) //i = 0, 1, 2, 3
        {
            Debug.Log(numerosA[i] + numerosB [ i + 2 ] );
        }
    }
}
