using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesBinarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArbolesBinarioBusqueda arbol = new ArbolesBinarioBusqueda(65);
            int[] numeros = { 50, 23, 39, 70, 68, 82 };
            foreach(int numero in numeros)
            {
                arbol.Insertar(numero);
            }
            Console.WriteLine(arbol.ObtenerArbol());
            Console.ReadKey();
        }
    }
}
