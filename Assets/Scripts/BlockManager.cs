using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject block;
    public Grid grid;

    public int numberOfPlatforms = 5;
    public int horizontalSpacing = 2;
    public int verticalSpacing = 2;

    // Start is called before the first frame update
    void Start()
    {
        int length = 13;
        for (int i = 0; i < length; i++)
        {
            int tileCount = GetTileCount();
            int[] positionX = GetRandomGridPosition(tileCount);
            for (int j = 0; j < tileCount; j++)
            {
                Vector3 randomPos = new Vector3(-3.5f + positionX[j] * 0.5f, 6.5f + i * 2, 0);
                Instantiate(block, randomPos, Quaternion.identity);
            }
        }
    }

    private int[] GetRandomGridPosition(int tileCount)
    {
        List<int> availableNumbers = new List<int>();
        for(int i =0; i<19; i++)
        {
            availableNumbers.Add(i);
        }

        int[] positionX = new int[tileCount];
        for (int i = 0; i < tileCount; i++)
        {
            positionX[i] = PickNumber(availableNumbers);
        }

        return positionX;
    }

    private int PickNumber(List<int> availableNumbers)
    {
        int pickedNumber;
        bool isValidNumber;

        do
        {
            int index = Random.Range(0, availableNumbers.Count);
            pickedNumber = availableNumbers[index];
            isValidNumber = CheckIfValidNumber(pickedNumber, availableNumbers);

        } while (!isValidNumber);

        RemoveNumbersInRange(pickedNumber, availableNumbers);
        return pickedNumber;
    }
    private bool CheckIfValidNumber(int number, List<int> availableNumbers)
    {
        for (int i = 0; i < 4; i++)
        {
            int numToCheck = (number + i) % 19;
            if (!availableNumbers.Contains(numToCheck))
            {
                return false;
            }
        }
        return true;
    }

    private void RemoveNumbersInRange(int number, List<int> availableNumbers)
    {
        for (int i = -1; i < 5; i++)
        {
            int numToRemove = (number + i) % 19;
            availableNumbers.Remove(numToRemove);
        }
    }

    private int GetTileCount()
    {
        return Random.Range(2, 4);
    }

    // Update is called once per frame
    void Update()
    {
    }    
}
