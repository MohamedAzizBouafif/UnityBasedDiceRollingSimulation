using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    //prefabs and holders
    public GameObject DicePrefab;
    private Transform diceHolder;

    //inisiate objects
    private DiceStats[] dices;
    public int[] DiceScore;

    public static bool ThrowMode;

    public Text display;

    public Transform DiceOnScreenPosition;

    private void Awake()
    {
        dices = new DiceStats[2];
        DiceScore = new int[2];
    }

    public void throwDice()
    {
        //Debug.Log("throw dice");

        if (ThrowMode)
            return;

        display.text = "00";

        SetAndFindDiceHolder();

        ThrowMode = true;

        dices[0] = NewDiceToThrow(transform.position + (Vector3.right));
        dices[1] = NewDiceToThrow(transform.position + (-Vector3.right));

        StartCoroutine(DiceUpdate());
    }

    [System.Obsolete]
    private void SetAndFindDiceHolder()
    {
        //Debug.Log("set and find dice holder");

        const string HolderName = "diceholder";
        if (transform.FindChild(HolderName))
        {
            Destroy(transform.FindChild(HolderName).gameObject);
        }
        diceHolder = new GameObject(HolderName).transform;
        diceHolder.parent = transform;
        diceHolder.position = Vector3.zero;
    }

    private DiceStats NewDiceToThrow(Vector3 initialPosition)
    {
        //random force and rotation for the dice
        Vector3 randomRotation = new Vector3(Random.Range(0f, 360), Random.Range(0f, 360), Random.Range(0f, 360));
        Vector3 randomThrowForce = new Vector3((transform.position.x - initialPosition.x) * Random.Range(100f, 300f), Random.Range(100f, 300f), 0f);


        //instansiate new dice and set its parent
        DiceStats newDice = Instantiate(DicePrefab, initialPosition, Quaternion.Euler(randomRotation)).GetComponent<DiceStats>();
        newDice.transform.parent = diceHolder;

        //find righetBody and throw dice
        Rigidbody DiceBody = newDice.transform.GetComponent<Rigidbody>();
        DiceBody.AddForce(randomThrowForce);

        return newDice;
    }

    IEnumerator DiceUpdate()
    {
        //Debug.Log("dice update");
        
        while (ThrowMode)
        {
            //Debug.Log("Dice Update");
            yield return new WaitForSeconds(1f);
            ThrowMode = !dices[0].DiceBalenced && !dices[1].DiceBalenced;

            if (!ThrowMode)
            {
                yield return new WaitForSeconds(1f);

                DiceScore[0] = dices[0].FindValue();
                DiceScore[1] = dices[1].FindValue();
            }
        }

        SetDsiplayScore();
        dices[0].ShowDiceToTheScreen(DiceOnScreenPosition.position + (Vector3.right * 0.75f));
        dices[1].ShowDiceToTheScreen(DiceOnScreenPosition.position - (Vector3.right * 0.75f));
    }

    void SetDsiplayScore()
    {
        if ((DiceScore[0] == 0) || (DiceScore[1] == 0))
            throwDice();
        else
            display.text = DiceScore[0].ToString() + " + " + DiceScore[1].ToString();
    }
}
