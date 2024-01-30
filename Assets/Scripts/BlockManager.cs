using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject block;
    public Grid grid;

    void Start()
    {
        int length = 13;   // 블록 쌓은 층 수를 의미
        for (int i = 0; i < length; i++) // 블록 만드는 for 문
        {
            int tileCount = GetTileCount(); // 타일 개수 랜덤 값
            int[] positionX = GetRandomGridPosition(tileCount); // 타일 생성 좌표
            for (int j = 0; j < tileCount; j++) // 타일 개수만큼 좌표에 타일 생성
            {
                Vector3 randomPos = new Vector3(-3.5f + positionX[j] * 0.5f, 6.5f + i * 2, 0);
                Instantiate(block, randomPos, Quaternion.identity);
            }
        }
    }

    // 타일 생성 좌표
    private int[] GetRandomGridPosition(int tileCount)
    {
        List<int> availableNumbers = new List<int>();
        for(int i =0; i<19; i++)
        {
            availableNumbers.Add(i);
        }

        int[] positionX = new int[tileCount]; // 랜덤 좌표 결과 담을 배열
        for (int i = 0; i < tileCount; i++)
        {
            positionX[i] = PickNumber(availableNumbers); // 블록이 생성된 좌표가 겹치는지 확인
        }

        return positionX;
    }

    // 블록이 생성된 좌표가 겹치는지 확인
    private int PickNumber(List<int> availableNumbers)
    {
        int pickedNumber;
        bool isValidNumber;

        do
        {
            int index = Random.Range(0, availableNumbers.Count); // 숫자를 랜덤으로 1개 선택
            pickedNumber = availableNumbers[index];
            isValidNumber = CheckIfValidNumber(pickedNumber, availableNumbers); // 뽑은 숫자가 안겹치는지 확인

        } while (!isValidNumber);

        RemoveNumbersInRange(pickedNumber, availableNumbers); // 뽑은 숫자를 겹치지 않도록 배열에서 값 제거
        return pickedNumber;
    }

    private bool CheckIfValidNumber(int number, List<int> availableNumbers)
    {
        for (int i = 0; i < 4; i++) // 뽑은 숫자를 기준으로 블록을 겹치지 않게 깔 수 있는지 확인
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
        for (int i = -1; i < 5; i++) // 뽑은 숫자 기준으로 6칸을 제거 (블록 4칸 + 좌우 2칸)
        {
            int numToRemove = (number + i) % 19;
            availableNumbers.Remove(numToRemove);
        }
    }

    private int GetTileCount()
    {
        return Random.Range(2, 4);
    }

    void Update()
    {
    }    
}
