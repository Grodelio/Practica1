// --------------------------------------------
// ANTONIO BLANCO RUIZ
// Curso DAW
// Modalidad Semipresencial
// Práctica nº 1
// --------------------------------------------

using System;
using System.Buffers;
using System.Globalization;

namespace Practica_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaración de variables
            char operation = '\0';
            char lastOperation = '\0';
            double numA = double.NaN;            
            double resultado = double.NaN;
            
            Console.WriteLine("---------------Calculadora sencilla---------");

            // Bucle principal del programa
            do
            {
                // Bucle que persiste hasta que se inserte u nnúmero
                do
                {
                    Console.Write("Introduce un número: ");
                    // Control de error de introducción de número
                    try
                    {
                        numA = Convert.ToDouble(Console.ReadLine());
                    
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("--> Número incorrecto");
                        numA = double.NaN;

                    }
                } while (double.IsNaN(numA));

                // Bucle que persiste hasta que se introduce una operación correcta
                do
                {
                    Console.Write("Introduce una operación: ");
                    operation = Convert.ToChar(Console.ReadLine());
                    // Si la operación introducdia no es la esperada, se muestra un mensaje de error
                    if (operation != '+' && operation != '-' && operation != '/' && operation != '*'
                        && operation != '=' && operation != 's')
                    {
                        Console.WriteLine("--> Operación incorrecta");
                    }
                } while (operation != '+' && operation != '-' && operation != '/' && operation != '*'
                        && operation != '=' && operation != 's');

                // Si es la primera vez, no se puede operar porque sólo tenemos un operando
                if (!double.IsNaN(resultado))
                {
                    resultado = Operate(resultado, numA, lastOperation);
                }

                // Guardamos la última operación introducida
                lastOperation = operation;

                // Condición de salida
                if (operation ==  '=' || operation == 's')
                {
                    Console.Write("El resultado es: ");
                    Console.WriteLine(resultado);
                }

                // Como la primera vez no se ha podido operar, guardamos el número introducido
                // como resultado para poder operar al introducir el siguiente número
                if (double.IsNaN(resultado))
                {
                    resultado = numA;
                }
            } while (operation != 's');
            Console.WriteLine("FIN DEL PROGRAMA");
            Console.ReadKey();
        }

        /// <summary>
        /// Método que se encarga de realizar la operación según el paámetro operation ( +, -, /, *)
        /// </summary>
        /// <param name="numA">Operando A</param>
        /// <param name="numB">Operando B</param>
        /// <param name="operation">Código de operación ( +, -, /, *)</param>
        /// <returns>El resultado de operar numA y numB con la operación introducida</returns>
        static double Operate(double numA, double numB, char operation)
        {
            double result = double.NaN;
            
            switch (operation)
            {
                case '+':
                    result = numA + numB;
                    break;
                case '-':
                    result = numA - numB;
                    break;
                case '/':
                    result = numA / numB;
                    break;
                case '*':
                    result = numA * numB;
                    break;
                default:
                    break;
            }
            return result;

        }
    }
}
