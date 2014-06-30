using UnityEngine;
using System.Collections;

public class Bewegen : MonoBehaviour
{
    public float Geschwindigkeit;
    public float Beschleunigung;
    public float Rutschen;

    float aktuelleGeschwindigkeit = 0;
    Vector3 aktuelleRichtung = Vector3.zero;
    float rutschenGeschwindigkeit = 0;

    void Start()
    {
    }

    void Update()
    {
        if (EingabeÜberprüfen())
        {
            if (aktuelleGeschwindigkeit < Geschwindigkeit)
            {
                aktuelleGeschwindigkeit += Beschleunigung * Time.deltaTime;
            }
            this.transform.position += aktuelleRichtung * aktuelleGeschwindigkeit * Time.deltaTime;
            rutschenGeschwindigkeit = aktuelleGeschwindigkeit / 2;
        }
        else
        {
            if (rutschenGeschwindigkeit > 0)
            {
                this.transform.position += aktuelleRichtung * rutschenGeschwindigkeit * Time.deltaTime;
                rutschenGeschwindigkeit -= (100f / Rutschen) * Time.deltaTime;
            }
            aktuelleGeschwindigkeit = 0f;
        }
    }

    private bool EingabeÜberprüfen()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            aktuelleRichtung = new Vector3(1f, 0f, 0f);
            return true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            aktuelleRichtung = new Vector3(-1f, 0f, 0f);
            return true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            aktuelleRichtung = new Vector3(0f, 0f, 1f);
            return true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            aktuelleRichtung = new Vector3(0f, 0f, -1f);
            return true;
        }
        return false;
    }
}