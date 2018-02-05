using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superposiciones
{
    class Node
    {
        private string id;
        private List<string> funcs;

        public string Id { get => id; set => id = value; }
        public List<string> Funcs { get => funcs; set => funcs = value; }

        /**
         * Crear nodo de arbol con la informacion sin parsear
         * Por ejemplo: "S1(F1)" será un nodo con id S1 y F1 en la lista;
         * @param info - String que representa un segmento y sus funciones "S1(F1)"
         */
        public Node(string info)
        {
            Funcs = new List<string>();

            // Extraer informacion detro de parentesis
            string strFunc = info.Split('(', ')')[1];

            if (strFunc.Contains(","))
            {
                foreach(var f in strFunc.Split(','))
                    Funcs.Add(f.Trim());
            } else
            {
                Funcs.Add(strFunc);
            }

            // Obtener informacion primero quitando contenido de parentesis
            // y luego los parentesis.
            id = info.Replace(strFunc, "")
                        .Replace("(", "")
                        .Replace(")", "");
        }
    }
}
