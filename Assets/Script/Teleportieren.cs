using UnityEngine;

public class Teleportieren : MonoBehaviour
{
    private GameObject[] wegpunkte = new GameObject[4];

    private GameObject letzterWegpunkt;

    private void Start()
    {
        for (int i = 0; i < wegpunkte.Length; i++)
        {
            wegpunkte[i] = GameObject.Find("Wegpunkt" + (i + 1).ToString());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            WegpunktSuchenUndPositionSetzen();
        }

        this.transform.position.Set(1f, 0f, 5f);
    }

    private void WegpunktSuchenUndPositionSetzen()
    {
        GameObject neuerWegpunkt = wegpunkte[Random.Range(0, wegpunkte.Length)];

        if (!neuerWegpunkt.Equals(letzterWegpunkt))
        {
            this.transform.position = neuerWegpunkt.transform.position;
            letzterWegpunkt = neuerWegpunkt;
        }
        else
        {
            WegpunktSuchenUndPositionSetzen();
        }
    }
}