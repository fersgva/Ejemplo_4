using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    private void Start()
    {
        for (int i = 1; i < 3; i++)
        {
            for(int j = -1; j > -3; j--)
            {
                Debug.Log(i - j);
            }
        }
    }
}
