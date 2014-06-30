using UnityEngine;
using System.Collections;

public class Teleportieren : MonoBehaviour
{

    // GameOject Array für die 4 Wegpunkte in der Scene
    GameObject[] wegpunkte = new GameObject[4];


    // Der Wegpunkt zu dessen Position das Testobjekt zuletzt teleportiert wurde, zum Start null
    GameObject letzterWegpunkt;




	// Start der Scene
	void Start ()
    {

        // For Schleife wird so oft durchlaufen, wie das wegpunkte Array lang ist.
        for (int i = 0; i < wegpunkte.Length; i++)
        {


            // Es wird ein GameObject gesucht das den Namen "Wegpunkt" plus den aktuellen Index + 1 hat und dann dem entsprechenden Index im Array zugewiesen.
            // Die Schleife und das Array fangen mit der Zählung bei 0 an, die Wegpunkte in der Scene bei 1.

            wegpunkte[i] = GameObject.Find("Wegpunkt" + (i + 1).ToString());

        }
	}
	


	// Wird bei jedem Frame ausgeführt
	void Update ()
    {


        // Überprüft ob die "Space" Taste gedrückt wird.

        if (Input.GetKeyDown("space"))
        {
            WegpunktSuchenUndPositionSetzen();
        }
	}



    void WegpunktSuchenUndPositionSetzen()
    {

        // Random.Range gibt einen zufälligen Int Zahlenwert zurück, der zwischen 0 und der Länge des wegpunkte Array liegt.
        // Mit dem Ergebnis bestimmen wir, welchen Index aus den Array wir haben wollen und weisen das Objekt der neuerwegpunkt Variable zu.

        GameObject neuerWegpunkt = wegpunkte[Random.Range(0, wegpunkte.Length)];





        // Überprüft ob das neuerWegpunkt zugewiesene Objekt NICHT das gleiche ist wie letzterWegpunkt

        if (!neuerWegpunkt.Equals(letzterWegpunkt))
        {

            // "Teleportieren":
            // Der Vector3 position der Transform Komponente des neuerWegpunkt Object wird dem Script ausführenden GameObject zugewiesen.
            this.transform.position = neuerWegpunkt.transform.position;



            // Damit wir beim nächsten mal wissen wo wir zuletzt gewesen sind, wird letzterWegpunkt das Wegpunkt Object von neuerWegpunkt zugewiesen.
            letzterWegpunkt = neuerWegpunkt;
        }



        // Wenn neuerWegpunkt und letzterWegpunkt gleich sind, wird die Methode nochmal ausgeführt.
        else
        {
            WegpunktSuchenUndPositionSetzen();
        }
    }
}
