// See https://aka.ms/new-console-template for more information
using System.Threading;

Welcome();

char readOption;
do
{
    WriteMenu();
    readOption = Console.ReadKey().KeyChar;
    switch (readOption)
    {
        case '1':
            Console.Clear();
            string NumeroTarjeta;
            string PIN;
            (NumeroTarjeta, PIN) = IngresarDatos();
            Thread.Sleep(500);
            Console.WriteLine(NumeroTarjeta);
            Thread.Sleep(500);
            Console.WriteLine(PIN);
            _ = Console.ReadKey().KeyChar;
            break;
        case '0':
            Console.WriteLine("\nSalir");
            _ = Console.ReadKey().KeyChar;
            break;
        default:
            Console.WriteLine("\nOpción no valida...");
            _ = Console.ReadKey().KeyChar;
            break;
    }
    Console.Clear();
} while (readOption != '0');


void Welcome()
{
    LoadLine("\n\nBienvenido de vuelta\n", 100);
    LoadLine("\n\nCargando el sistema...\n", 100);
    LoadLine("\n\n  0%  |--------------------| ", 300);
    LoadLine("\r 10 % |**------------------| ", 300);
    LoadLine("\r 20 % |****----------------| ", 300);
    LoadLine("\r 30 % |******--------------| ", 300);
    LoadLine("\r 40 % |********------------| ", 300);
    LoadLine("\r 50 % |**********----------| ", 300);
    LoadLine("\r 60 % |************--------| ", 300);
    LoadLine("\r 70 % |**************------| ", 300);
    LoadLine("\r 80 % |****************----| ", 300);
    LoadLine("\r 90 % |******************--| ", 300);
    LoadLine("\r100 % |********************| ", 300);
    Thread.Sleep(2000);
    Console.Clear();
}

void LoadLine(string text, int time)
{
    Thread.Sleep(time);
    Console.Write(text);
}

// Escribir menu
void WriteMenu(){
    Console.WriteLine("\n\nMenú de Operaciones");
    Console.WriteLine("\n1. Realizar venta");
    Console.WriteLine("0. Salir");
    Console.Write("Ingrese una opción: ");
}

// 
(string, string) IngresarDatos()
{
    string NumeroTarjeta;
    string PIN;

    Console.WriteLine("\n\n\nIngresar numero de tarjeta: ");
    NumeroTarjeta = Console.ReadLine();

    Console.WriteLine("Ingresar PIN:");
    PIN = Console.ReadLine();
    
    return (NumeroTarjeta, PIN);
}