using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WindowClone : EditorWindow
{
    //Cosas a poner: Cantidad int, separación float, sobre eje x o y trigger
    //Boton para ejecutar
    public int miCantidad;
    public float miSeparacion;

    
    
    bool ejeX = false;
    bool ejeZ = false;
    
    //para el boton
    Texture tex;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/WindowClone")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        WindowClone window = (WindowClone)EditorWindow.GetWindow(typeof(WindowClone));
        window.Show();
        EditorWindow windowInt = GetWindow(typeof(WindowClone));
        EditorWindow windowFloat = GetWindow(typeof(WindowClone));
    }

    void OnGUI()
    {
        GUILayout.Label("Multiplicador de objetos", EditorStyles.boldLabel);
        miCantidad = EditorGUILayout.IntField("Cantidad", miCantidad);
        miSeparacion = EditorGUILayout.FloatField("Separación", miSeparacion);

        
       
        ejeX = EditorGUILayout.Toggle("Sobre eje X", ejeX);
        ejeZ = EditorGUILayout.Toggle("Sobre eje Z", ejeZ);

        /*if (!tex)
        {
            Debug.LogError("No texture found, please assign a texture on the inspector");

        }
        if(GUILayout.Button(tex))
        {
            Debug.Log("Clicked the image");
        }*/ // de prueba?

        if(GUILayout.Button("Clonar Objeto")) //Si el boton es presionado
        {
            
            Debug.Log("Boton oprimido");

            if(!Selection.activeGameObject)
            {
                Debug.Log("Selecciona un GameObject primero");
            }

            Transform objeto = Selection.activeTransform;
            Transform padre = Selection.activeTransform.parent;
            if(ejeX == true)
            {
                for (int cantidad = 1; cantidad < miCantidad; cantidad++)
                {
                    Instantiate(objeto, new Vector3(objeto.position.x + cantidad * miSeparacion, objeto.position.y,
                        objeto.position.z), Quaternion.identity, padre);
                }
            }
            if(ejeZ == true)
            {
                for (int cantidad = 1; cantidad < miCantidad; cantidad++)
                {
                    Instantiate(objeto, new Vector3(objeto.position.x, objeto.position.y,
                       objeto.position.z + cantidad * miSeparacion), Quaternion.Euler(0, 90, 0), padre);
                }
                
            }
            else
            {
                Debug.Log("Seleccione un eje");
            }
           
        }
         
        
    }

    
}
