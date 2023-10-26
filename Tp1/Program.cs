//Si una palabra empieza con vocal, entonces la primera vocal se duplica, a menos que la
//segunda letra sea también sea una vocal; en ese caso ignoramos la regla.

//Las mayúsculas no existen en esta lengua, por lo que toda mayúscula debe ser
//reemplazada por una minúscula.

//Podemos ignorar las tildes. No hace falta hacer nada al respecto.

//Si una palabra tiene más de 6 letras de largo, debemos agregar “an” al principio, antes del
//primer prefijo, y luego de aplicar la primera regla.

//Si una palabra termina en n, s o vocal, entonces debemos agregar “sten” al final de la
//palabra, a menos que la vocal sea ‘o’, en ese caso debemos agregar “so” en lugar.

//No es importante que el programa acepte nuevas frases durante la ejecución; es suficiente
//que estén guardadas previamente dentro del mismo programa.

//----------------------- FABRICIO ZANDONADI ----------------------------------

using System;

// MAIN

Console.WriteLine("Escriba una frase");
String[] frase = Console.ReadLine().ToLower().Split(" ");

char[] vocales = {'a','e','i','o','u', 'á', 'é', 'í', 'ó', 'ú' };


for (int i = 0; i < frase.Length; i++)
{
    for (int j = 0; j < vocales.Length; j++)
    {
        if (frase[i].Count() == 1)
        {
            frase[i] = DuplicarPalabraD1Letra(frase[i]);
        }
        else
        {
            DuplicarVocalPalabra(frase, vocales, i, j);
            AgregaAnAMayorD6(frase, i, j);
            AgregaStenOSo(frase, vocales, i, j);

        }

    }
}
Console.WriteLine(ConvertirACadena(frase));

// FUNCIONES 

void AgregaStenOSo(string[] frase, char[] vocales, int i, int j)
{
    char ultimaLetra = frase[i].ElementAt(frase[i].Count() - 1); //saca la ultima letra de la palabra que recibe por el array


    if (ultimaLetra == vocales[j] && ultimaLetra != 'o' && j == 0)
    {
        frase[i] += "sten";
    }
    else if (ultimaLetra == 'o' && j == 0)
    {
        frase[i] += "so";
    }
}

void DuplicarVocalPalabra(string[] frase, char[] vocales, int i, int j)
{
    if (frase[i].ElementAt(0) == vocales[j] && frase[i].ElementAt(1) != null && !EsVocal(frase[i].ElementAt(1))) //puede llegar a tira excepcion por mas de un espacio
    {
        frase[i] = vocales[j] + frase[i];
    }
}

String DuplicarPalabraD1Letra(String letra)
{
    for (int i = 0; i < vocales.Length; i++)
    {
        if (letra == Convert.ToString(vocales[i]))

            return letra + letra;

    }
    return letra;
}

String ConvertirACadena(String[] frase)
{
    String frasecompleta = "";
    for (int i = 0; i < frase.Length; i++)
    {
        frasecompleta += frase[i] + " ";
    }

    return frasecompleta;
}


Boolean EsVocal(char letra)
{

    for (int p = 0; p < vocales.Length; p++)
    {
        if (letra == vocales[p] ? true : false)
        {
            return true;
        }

    }
        return false;
}

 void AgregaAnAMayorD6(string[] frase, int i, int j)
{
    if (frase[i].Count() >= 6 && j == 0) // ponemos j == 0 para que solo coloque una sola vez el an
    {
        frase[i] = "an" + frase[i];
    }
}