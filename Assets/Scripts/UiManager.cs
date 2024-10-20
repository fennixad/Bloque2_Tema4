using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerCounter;
    public TextMeshProUGUI showInstructions;
    public TextMeshProUGUI ranking;

    public GameObject cajaRojaPrefab;
    public GameObject cajaBlanca1Prefab;
    public GameObject cajaBlanca2Prefab;
    public GameObject personaje;

    public GameObject cajaRojaEscena;
    public GameObject cajaBlanca1Escena;
    public GameObject cajaBlanca2Escena;

    private Vector3 cajaRojaPosition;
    private Quaternion cajaRojaRotation;

    private Vector3 cajaBlanca1Position;
    private Quaternion cajaBlanca1Rotation;

    private Vector3 cajaBlanca2Position;
    private Quaternion cajaBlanca2Rotation;

    private Vector3 personajeStartPosition;

    float record = 1000f;
    float gameTimer = 0f;
    void Start()
    {
        cajaRojaPosition = cajaRojaEscena.transform.position;
        cajaRojaRotation = cajaRojaEscena.transform.rotation;
        cajaBlanca1Position = cajaBlanca1Escena.transform.position;
        cajaBlanca1Rotation = cajaBlanca1Escena.transform.rotation;
        cajaBlanca2Position = cajaBlanca2Escena.transform.position;
        cajaBlanca2Rotation = cajaBlanca2Escena.transform.rotation;
        personajeStartPosition = personaje.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        UpdateInstructions();
        CheckAndInstantiateGameObjects();
    }

    void UpdateTimer()
    {
        gameTimer += Time.deltaTime;
        timerCounter.text = $"Tiempo: {gameTimer:F2}";        
    }

    void UpdateInstructions()
    {
        if (cajaRojaPrefab == null)
        {
            showInstructions.text = "Destruye las Cajas apuntando y pulsando E";
        }
        else if (cajaRojaPrefab != null && cajaBlanca1Prefab != null && cajaBlanca2Prefab != null)
        {
            showInstructions.text = "Salta encima de la esfera roja";
        }
    }

    void CheckAndInstantiateGameObjects()
    {
        if (cajaRojaEscena == null && cajaBlanca1Escena == null && cajaBlanca2Escena == null)
        {
            personaje.transform.position = personajeStartPosition;

            cajaRojaEscena = Instantiate(cajaRojaPrefab, cajaRojaPosition, cajaRojaRotation);
            cajaBlanca1Escena = Instantiate(cajaBlanca1Prefab, cajaBlanca1Position, cajaBlanca1Rotation);
            cajaBlanca2Escena = Instantiate(cajaBlanca2Prefab, cajaBlanca2Position, cajaBlanca2Rotation);

            MaximumScore();
        }
    }

    void IgualarObjetosEscena()
    {
        cajaRojaEscena = cajaRojaPrefab;
        cajaBlanca1Escena = cajaBlanca1Prefab;
        cajaBlanca2Escena = cajaBlanca2Prefab;
    }

    void MaximumScore()
    {
        string textValue = timerCounter.text;
        textValue = textValue.Replace("Tiempo: ", "");

        float puntuacion = float.Parse(textValue);

        if (puntuacion < record)
        {
            record = puntuacion;
            Debug.Log($"Enorabuena has obtenido un nuevo record: { record:F2}");
        }
        gameTimer = 0f;

        gameTimer += Time.deltaTime;
        ranking.text = $"Best: {record:F2}";
    }

}
