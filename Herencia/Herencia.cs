using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herencia : MonoBehaviour
{
    void QueEsHerencia()
    {
        print("En Paradigma de Programacion Orientada a Objetos, " +
            "Podemos utilizar una clase base, la cual comparte sus propiedades y metodos a los derivados de ella.");

        print("Abuelo comparte su genetica con el padre. El padre comparte a su vez con el hijo. " +
            "Por transitividad, Hijo, cuenta con la genetica de Abuelo y Padre.");
    }
    void QueEsPolimorfismo()
    {
        print("Se refiere a la propiedad por la que es posible enviar mensajes sintácticamente iguales a objetos de tipos distintos.");
        print("Puedo enviar un mensaje a un Humano y a una Serpiente -- Reproducirse() -- y cada quien tomara accion segun su implementacion");
        print("Puedo tratar con un tipo base compartido a dos objetos de un nivel de implementacion superior");
        print("Humano es Animal, Serpiente es Animal");
    }

}

public abstract class Animal
{
    protected string especie;
    protected abstract void Reproducirse(); // La accion reproductiva varia en todas las variantes. Los oviparos ponen huevos, los mamiferos gestan, etc.

    protected virtual void Comer()
    {
        Debug.Log("Comer");
    }
    protected virtual void Dormir()
    {
        Debug.Log("Descansar");
    }

    protected virtual void Vivir()
    {
        Debug.Log("Soy un animal vivo");
    }

}
public abstract class Oviparo : Animal
{
    // Contiene todos los metodos y propiedades de animal. Sobreescribe solo el metodo de reproduccion
    protected override void Reproducirse()
    {
        Debug.Log("Poner huevos");
    }
}
public abstract class Mamifero : Animal
{
    // Contiene todos los metodos y propiedades de animal. Sobreescribe solo el metodo de reproduccion
    protected override void Reproducirse()
    {
        Debug.Log("Gestar");
    }
}
public class Humano : Mamifero
{
    // Contiene todos los metodos y propiedades de ANIMAL Y Las implementaciones de Mamifero.

    protected override void Reproducirse()
    {
        base.Reproducirse(); // ejecuta el metodo heredado de la clase base. (Mamifero.Reproducirse())
        Debug.Log("Trascender mediante la cultura y la ciencia"); // agregado particular de esta clase
    }

}

