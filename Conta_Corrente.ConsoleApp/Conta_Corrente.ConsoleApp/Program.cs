using System;

namespace Conta_Corrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente(1, 1000, 12, 0, true, 10);

            conta1.Sacar(200);
            conta1.Depositar(300);
            conta1.Depositar(500);
            conta1.Sacar(200);

            ContaCorrente conta2 = new ContaCorrente(2 , 300, 13, 0, true, 10);

            conta1.TransferirPara(conta2, 400);

            conta1.ExibirExtrato();
            conta2.ExibirExtrato();
        }
    }
}
