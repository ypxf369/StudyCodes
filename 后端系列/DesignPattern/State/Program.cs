using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            //开一个新的账户
            Account account = new Account("yesir");

            //进行交易
            //存钱
            account.Deposit(1000);
            account.Deposit(200);
            account.Deposit(600);

            //付利息
            account.PayInterest();

            //取钱
            account.Withdraw(2000);
            account.Withdraw(500);
            Console.ReadKey();
        }
    }
}
