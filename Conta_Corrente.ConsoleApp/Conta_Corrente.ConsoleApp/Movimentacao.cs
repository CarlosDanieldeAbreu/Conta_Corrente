using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta_Corrente.ConsoleApp
{
    public class Movimentacao
    {
        public decimal valor;
        public TipoMovimentacao tipo;
        public string descricao;

        public enum TipoMovimentacao
        {
            Credito, Debito
        }
    }
}
