using System.Collections;
using UnityEngine;

public class DiceStats : MonoBehaviour
{
    private Rigidbody diceBody;
    public bool DiceBalenced;

    private DiceSide[] DiceSides;

    public int DiceScore;
    private bool ToTheScreen = false;

    private Vector3 diceOnScreenPosition;
    private Quaternion diceOnScreenRotation;

    private void Start()
    {
        diceBody = GetComponent<Rigidbody>();
        DiceSides = new DiceSide[6];
        SetDiceSides();
    }

    void FixedUpdate()
    {
        if (!DiceBalenced)
            StartCoroutine(SetRollingBool());

        if(ToTheScreen)
        {
            diceBody.useGravity = false;

            transform.localRotation =Quaternion.Slerp(transform.rotation,
                                                      diceOnScreenRotation,
                                                      0.05f);
           
            transform.position = Vector3.Lerp(transform.position, diceOnScreenPosition, 0.1f);

        }
        if (transform.rotation == diceOnScreenRotation && transform.position == diceOnScreenPosition)
            ToTheScreen = false;
    }

    IEnumerator SetRollingBool()
    {
        yield return new WaitForSeconds(0.2f);

        if (diceBody.velocity == Vector3.zero)
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                break;
            }
            DiceBalenced = true;
            //Debug.Log("dice balenced true");
        }
        else
        {
            DiceBalenced = false;
            //Debug.Log("dice balanced false");
        }
    }

    public void SetDiceSides()
    {
        for (int i = 0; i < 6; i++)
        {
             DiceSides[i] = transform.GetChild(i + 1).GetComponent<DiceSide>();
        }

    }

    public int FindValue()
    {
        for (int i = 0; i < 6; i++)
        {
            DiceSide _diceSide = DiceSides[i];

            if (_diceSide.SideOnGround)
            {
                #region DETERMEN_VALUE
                switch (_diceSide.name)
                {
                    case "1":
                        DiceScore = 6;
                        break;
                    case "2":
                        DiceScore = 4;
                        break;
                    case "3":
                        DiceScore = 5;
                        break;
                    case "4":
                        DiceScore = 2;
                        break;
                    case "5":
                        DiceScore = 3;
                        break;
                    case "6":
                        DiceScore = 1;
                        break;
                    default:
                        return 0;
                }
                #endregion
            }
        }
        return DiceScore;
    }

    public void ShowDiceToTheScreen(Vector3 _diceOnScreenPosition)
    {
        Vector3 diceOnScreenRotationElur = Vector3.zero;

        #region DICE_SCORE_SCRREEN_ROTATION
        switch (DiceScore)
        {
            case 1:
                diceOnScreenRotationElur = new Vector3(0f, -90f, 160f);
                break;
            case 2:
                diceOnScreenRotationElur = new Vector3(20f, 0f, 0f);
                break;
            case 3:
                diceOnScreenRotationElur = new Vector3(110f, 0f, 0f);
                break;
            case 4:
                diceOnScreenRotationElur = new Vector3(200f, 0f, 0f);
                break;
            case 5:
                diceOnScreenRotationElur = new Vector3(-70f, 0f, 0f);
                break;
            case 6:
                diceOnScreenRotationElur = new Vector3(0f, -90f, -20f);
                break;
            default:
                break;
        }
        #endregion

        diceOnScreenPosition = _diceOnScreenPosition;
        diceOnScreenRotation = Quaternion.Euler(diceOnScreenRotationElur);
        ToTheScreen = true;
    }

}
