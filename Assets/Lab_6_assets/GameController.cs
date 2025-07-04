using UnityEngine;
using TMPro; 

public class GameController : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    public TextMeshProUGUI winMessageText;

    public TextMeshProUGUI guessCubeText;

    private GameObject correctCube; 

    void Start()
    {
        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false);
        }

        if (guessCubeText != null)
        {
            guessCubeText.gameObject.SetActive(true);
        }

        ResetGame();
    }

    void SetCorrectCube(int cubeIndex)
    {
        ResetGame(); 

        switch (cubeIndex)
        {
            case 1: correctCube = cube1; break;
            case 2: correctCube = cube2; break;
            case 3: correctCube = cube3; break;
            default:
                Debug.LogError("Неправильный индекс куба!");
                return;
        }

        Debug.Log("Выбран куб №" + cubeIndex);

        if (cube1 != correctCube && cube1.GetComponent<Rigidbody>() != null)
        {
            cube1.GetComponent<Rigidbody>().useGravity = true;
        }
        if (cube2 != correctCube && cube2.GetComponent<Rigidbody>() != null)
        {
            cube2.GetComponent<Rigidbody>().useGravity = true;
        }
        if (cube3 != correctCube && cube3.GetComponent<Rigidbody>() != null)
        {
            cube3.GetComponent<Rigidbody>().useGravity = true;
        }

        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(true);
        }

        if (guessCubeText != null)
        {
            guessCubeText.gameObject.SetActive(false);
        }
    }

    void ResetGame()
    {
        Debug.Log("Сброс игры.");
        ResetCubeState(cube1);
        ResetCubeState(cube2);
        ResetCubeState(cube3);

        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false);
        }

        if (guessCubeText != null)
        {
            guessCubeText.gameObject.SetActive(true);
        }
    }

    void ResetCubeState(GameObject cube)
    {
        if (cube != null)
        {
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    public void OnCube1ButtonClicked()
    {
        SetCorrectCube(1);
    }

    public void OnCube2ButtonClicked()
    {
        SetCorrectCube(2);
    }

    public void OnCube3ButtonClicked()
    {
        SetCorrectCube(3);
    }
}