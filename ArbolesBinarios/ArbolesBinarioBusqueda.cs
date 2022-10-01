using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesBinarios
{
    public class ArbolesBinarioBusqueda
    {
        private Nodo raiz;
        public Nodo Raiz { get { return raiz; } }
        public ArbolesBinarioBusqueda(int valor)
        {
            raiz = new Nodo(valor);
        }
        public void Insertar(int valor, Nodo nodoPadre=null)
        {
            if (nodoPadre == null)
            {
                nodoPadre = raiz;
            }
            if (valor > nodoPadre.Valor)
            {
                if(nodoPadre.HijoDerecho==null)
                {
                    nodoPadre.HijoDerecho = new Nodo(valor);
                }
                Insertar(valor, nodoPadre.HijoDerecho);
            }
            else if(valor < nodoPadre.Valor)
            {
                if (nodoPadre.HijoIzquierdo==null)
                {
                    nodoPadre.HijoIzquierdo = new Nodo(valor);
                }
                Insertar(valor, nodoPadre.HijoIzquierdo);
            }
        }
            public enum TipoRecorrido
        {
            Preorden=1,
            Inorden=2,
            Posorden=3,
        }

        private void RecorrerArbol(Nodo nodo, ref string recorrido)
        {
            if(nodo != null)
            {
                string textoRaiz = "";
                if(recorrido == "")
                {
                    textoRaiz = "Raiz";
                }
                recorrido += $"{textoRaiz} {nodo.Valor, 5}{Environment.NewLine}";
                if(nodo.HijoIzquierdo != null)
                {
                    recorrido += $"{nodo.Valor, -5}<- ";
                    RecorrerArbol(nodo.HijoIzquierdo, ref recorrido);
                }
                if (nodo.HijoDerecho != null) 
                {
                    recorrido += $"{nodo.Valor, -5}->";
                    RecorrerArbol(nodo.HijoDerecho, ref recorrido);
                }
                
            }
        }
            public string ObtenerArbol(Nodo nodo = null)
            {
            if(nodo == null)
            {
                nodo = raiz;
            }
            string recorrido = "";
            RecorrerArbol(nodo, ref recorrido);
            return recorrido;
            }
    }
}
