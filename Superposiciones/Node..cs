using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superposiciones
{
    public class Node
    {
        private string id;
        private List<string> funcs;
        private int nodeSize;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public int nSize
        {
            get { return nodeSize; }
            set { nodeSize = value; }
        }
        public List<string> Funcs {get { return funcs; } set { funcs = value; } }

        /**
         * Crear nodo de arbol con la informacion sin parsear
         * Por ejemplo: "S1(F1)" será un nodo con id S1 y F1 en la lista;
         * @param info - String que representa un segmento y sus funciones "S1(F1)"
         */
        public Node(string info)
        {
            funcs = new List<string>();

            // Extraer informacion detro de parentesis
            string strFunc = info.Split('(', ')')[1];

            if (strFunc.Contains(","))
            {
                foreach(var f in strFunc.Split(','))
                    funcs.Add(f.Trim());
            } else
            {
                funcs.Add(strFunc);
            }

            // Obtener informacion primero quitando contenido de parentesis
            // y luego los parentesis.
            id = info.Replace(strFunc, "")
                        .Replace("(", "")
                        .Replace(")", "");
        }
    }
}
