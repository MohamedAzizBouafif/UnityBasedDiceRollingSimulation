using UnityEngine;

public class DiceSide : MonoBehaviour
{
    const string GROUND_TAG = "Ground";
    public bool SideOnGround;

    private void OnTriggerStay(Collider other)
    { 
        if (other.CompareTag(GROUND_TAG))
            SideOnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!(other.CompareTag(GROUND_TAG)))
            SideOnGround = false;
    }

}
