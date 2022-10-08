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
        public void Insertar(int valor, Nodo nodoPadre = null)
        {
            if (nodoPadre == null)
            {
                nodoPadre = raiz;
            }
            if (valor > nodoPadre.Valor)
            {
                if (nodoPadre.HijoDerecho == null)
                {
                    nodoPadre.HijoDerecho = new Nodo(valor);
                }
                Insertar(valor, nodoPadre.HijoDerecho);
            }
            else if (valor < nodoPadre.Valor)
            {
                if (nodoPadre.HijoIzquierdo == null)
                {
                    nodoPadre.HijoIzquierdo = new Nodo(valor);
                }
                Insertar(valor, nodoPadre.HijoIzquierdo);
            }
        }
        public enum TipoRecorrido
        {
            Preorden = 1,
            Inorden = 2,
            Posorden = 3,
        }

        private void RecorrerArbol(Nodo nodo, ref string recorrido)
        {
            if (nodo != null)
            {
                string textoRaiz = "";
                if (recorrido == "")
                {
                    textoRaiz = "Raiz";
                }
                recorrido += $"{textoRaiz} {nodo.Valor,5}{Environment.NewLine}";
                if (nodo.HijoIzquierdo != null)
                {
                    recorrido += $"{nodo.Valor,-5}<- ";
                    RecorrerArbol(nodo.HijoIzquierdo, ref recorrido);
                }
                if (nodo.HijoDerecho != null)
                {
                    recorrido += $"{nodo.Valor,-5}->";
                    RecorrerArbol(nodo.HijoDerecho, ref recorrido);
                }

            }
        }
        public string ObtenerArbol(Nodo nodo = null)
        {
            if (nodo == null)
            {
                nodo = raiz;
            }
            string recorrido = "";
            RecorrerArbol(nodo, ref recorrido);
            return recorrido;
        }
        public string Recorrido(Nodo nodo = null, TipoRecorrido tipoRecorrido = TipoRecorrido.Preorden)
        {
            if (nodo == null)
            {
                nodo = raiz;

            }
            string recorrido = "";
            switch (tipoRecorrido)
            {
                case TipoRecorrido.Preorden:
                    RecorridoPreorden(nodo, ref recorrido);
                    break;
                case TipoRecorrido.Posorden:
                    RecorridoPosorden(nodo, ref recorrido);
                    break;
                case TipoRecorrido.Inorden:
                    RecorridoInorden(nodo, ref recorrido);
                    break;

                default: throw new Exception("");
            }
            return $"{tipoRecorrido}:{recorrido}";
        }
        private void AgregarValor(Nodo nodo, ref string recorrido)
        {
            string coma = (recorrido == "") ? "" : ",";
            recorrido += $"{coma}{nodo.Valor}";
        }


        private void RecorridoInorden(Nodo nodo, ref string recorrido)
        {
            if (nodo != null)
            {
                
                if (nodo.HijoIzquierdo != null)
                {
                    RecorridoInorden(nodo.HijoIzquierdo, ref recorrido);
                }

                AgregarValor(nodo, ref recorrido);

                if (nodo.HijoDerecho != null)
                {
                    RecorridoInorden(nodo.HijoDerecho, ref recorrido);
                }    
                
            }

        }

        private void RecorridoPosorden(Nodo nodo, ref string recorrido)
        {
            if (nodo != null)
            {

                if (nodo.HijoIzquierdo != null)
                {
                    RecorridoInorden(nodo.HijoIzquierdo, ref recorrido);
                }

                if (nodo.HijoDerecho != null)
                {
                    RecorridoInorden(nodo.HijoDerecho, ref recorrido);
                }

                AgregarValor(nodo, ref recorrido);

            }
        }

        private void RecorridoPreorden(Nodo nodo, ref string recorrido)
        {

            if (nodo != null)
            {
                AgregarValor(nodo, ref recorrido);
                if (nodo.HijoIzquierdo != null)
                {
                    RecorridoPreorden(nodo.HijoIzquierdo, ref recorrido);
                }
                if (nodo.HijoDerecho != null)
                {
                    RecorridoPreorden(nodo.HijoDerecho, ref recorrido);
                }

            }
        }
    }

}
