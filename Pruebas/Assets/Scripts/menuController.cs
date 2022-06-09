using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    [Header("Opciones Generales")]
    [SerializeField] float tiempoCambiaOpcion;
    [SerializeField] GameObject pantallaMenu;
    [SerializeField] GameObject pantallaOpciones;

    [Header("Elementos de menu")]
    [SerializeField] SpriteRenderer comenzar;
    [SerializeField] SpriteRenderer opciones;
    [SerializeField] SpriteRenderer salir;

    [Header("Sprites de menu")]
    [SerializeField] Sprite comenzar_off;
    [SerializeField] Sprite comenzar_on;
    [SerializeField] Sprite opciones_off;
    [SerializeField] Sprite opciones_on;
    [SerializeField] Sprite salir_off;
    [SerializeField] Sprite salir_on;

    //Para los audios
    [Header("Sprites de menu")]
    [SerializeField] AudioSource snd_opcion;
    [SerializeField] AudioSource snd_seleccion;

    int pantalla;
    int opcionMenu, opcionMenuAnt;
    bool pulsadoSubmit;
    float v, h;
    float tiempoV;

    void Awake()
    {
        pantalla = 0;
        tiempoV  = 0;
        opcionMenu = opcionMenuAnt = 1;
        AjustaOpciones();
    }

    void AjustaOpciones()
    {

    }

    void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonUp("Submit")) pulsadoSubmit = false;
        if (v == 0) tiempoV = 0;
        if (pantalla == 0) MenuPrincipal();
    }

    void MenuPrincipal()
    {
        if (v != 0)
        {
            if (tiempoV == 0 || tiempoV > tiempoCambiaOpcion)
            {
                if (v == 1 && opcionMenu > 1) SeleccionaMenu(opcionMenu - 1);
                if (v == -1 && opcionMenu < 3) SeleccionaMenu(opcionMenu + 1);
                if (tiempoV > tiempoCambiaOpcion) tiempoV = 0;
            }
            tiempoV += Time.deltaTime;
        }
        if (Input.GetButtonDown("Submit") && !pulsadoSubmit)
        {
            snd_seleccion.Play();
            //Aquí poner el nombre de la escena que tengamos(nivel de la soledad)
            if (opcionMenu == 1) SceneManager.LoadScene("miedoAlMiedo");
            if (opcionMenu == 2) SceneManager.LoadScene("Opciones"); 
            if (opcionMenu == 3) Application.Quit();
        }
    }

    void SeleccionaMenu(int op)
    {
        snd_opcion.Play();
        opcionMenu = op;
        if (op == 1) comenzar.sprite = comenzar_on;
        if (op == 2) opciones.sprite = opciones_on;
        if (op == 3) salir.sprite = salir_on;

        if (opcionMenuAnt == 1) comenzar.sprite = comenzar_off;
        if (opcionMenuAnt == 2) opciones.sprite = opciones_off;
        if (opcionMenuAnt == 3) salir.sprite = salir_off;
        opcionMenuAnt = op;
    }
}
