using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta_Corrente.ConsoleApp
{
    public class ContaCorrente
    {
        public int ID;
        public decimal saldo;
        public int numero;
        public decimal limite;
        public bool ehEspecial;
        public Movimentacao[] movimentacoes;

        public string StatusDaConta()
        {
            string status = "";
            if (ehEspecial == true)
            
                status = "CONTA=ESPECIAL";
            
            else
            
                status = "CONTA=NORMAL";
            
            return status;
        }

        public void Sacar(decimal valor)
        {
            if (saldo < valor)
                Console.WriteLine("Seu saldo é insuficiente para sacar a quantia desejada");
            else
            {
                decimal novoSaldo = saldo - valor;
                saldo = novoSaldo;
                

                Movimentacao movimentacao = new Movimentacao();
                movimentacao.valor = valor;
                movimentacao.tipo = Movimentacao.TipoMovimentacao.Debito;
                movimentacao.descricao = "Débito de " + valor + " R$";

                int posicaoVazia = PegaPosicaoVazia();
                movimentacoes[posicaoVazia] = movimentacao;
            }
               
        }

        public void Depositar(decimal valor)
        {
            this.saldo += valor;

            Movimentacao movimentacao = new Movimentacao();
            movimentacao.valor = valor;
            movimentacao.tipo = Movimentacao.TipoMovimentacao.Credito;
            movimentacao.descricao = "Crédito de " + valor + " R$";

            int posicaoVazia = PegaPosicaoVazia();
            movimentacoes[posicaoVazia] = movimentacao;
        }

        public void TransferirPara( ContaCorrente destino ,decimal valor)
        {
            if (this.saldo < valor)
                Console.WriteLine("Não foi possivel transferir seu saldo é menor que o valor");
            else
            {
                Sacar(valor);
                destino.Depositar(valor);
            }

        }
        public int PegaPosicaoVazia()
        {
            int posicao = 0;

            for(int i = 0; i < movimentacoes.Length; i++)
            {
                if(movimentacoes[i] == null)
                {
                    posicao = i;
                    break;
                }
            }
            return posicao;
        }

        public void ExibirExtrato()
        {
            Console.WriteLine("======Conta corrente do {0} ° cliente========", ID);
            Console.WriteLine("Saldo: " + saldo);
            Console.WriteLine("Número: " + numero);
            Console.WriteLine("Limite: " + limite);
            Console.WriteLine("Tipo da conta: " + StatusDaConta());
            Console.WriteLine("");
            Console.WriteLine("====Movimentação====");
            for(int i = 0; i < movimentacoes.Length; i++)
            {
                if(movimentacoes[i] != null)
                {
                    Console.WriteLine(movimentacoes[i].descricao);
                }
            }

            Console.ReadLine();
        }
    }
}
