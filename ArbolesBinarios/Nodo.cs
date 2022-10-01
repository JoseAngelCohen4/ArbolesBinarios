using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesBinarios
{
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo HijoIzquierdo { get; set; }
        public Nodo HijoDerecho { get; set; }

        public Nodo(int valor, Nodo hijoIzquierdo=null, Nodo hijoDerecho=null)
        {
            Valor = valor;
            HijoIzquierdo = hijoIzquierdo;
            HijoDerecho = hijoDerecho;
        }
    }
}
