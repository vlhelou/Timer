using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer;

internal class ArgsParse
{
    private Dictionary<string, string> _valores = new Dictionary<string, string>();
    public ArgsParse(string[] argumentos)
    {
        for (int i = 0; i < argumentos.Length; i++)
        {
            string nome = argumentos[i];
            if (nome.Length >2 && nome.StartsWith("--"))
            {
                string nomeFinal = nome.Substring(2).ToLower();
                if (i + 1 < argumentos.Length && !argumentos[i + 1].StartsWith("--"))
                {
                    _valores.Add(nomeFinal, argumentos[i + 1]);
                    i++;
                }
                else
                {
                    _valores.Add(nomeFinal, "true");
                }
                continue;
            } else
            {
                _valores.Add(nome.ToLower(), "true");
            }
        }
    }

    public Dictionary<string, string> Valores
    {
        get
        {
            return this._valores;
        }
    }

    public string? Valor(string nome)
    {
        if (this._valores.ContainsKey(nome.ToLower()))
            return this._valores[nome];
        return null;
    }
}
