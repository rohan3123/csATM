using System;

// simple ATM system by Rohan

// class bank
class Bank
{
    // private variable for class cannot be acessed 
    private string bankName;
    private string bankAddress;
    private int bankBalance;

    // constuctor bank 
    public Bank(string name, string address, int balance)
    {
        bankName = name;
        bankAddress = address;
        bankBalance = balance;
    }

    // returns bank balance of user account 
    public int checkBalance()
    {
        return bankBalance;
    }

    // loop of withdraw
    public bool withdraw(int amount)
    {
        // checks if money withdrawn is more then the account holds
        if (amount > bankBalance)
        {
            // returns error if ammount attempted to withdraw is bigger then balance
            Console.WriteLine("Insufficient balance.");
            return false;
        }
        else
        {
            // if the ammount is able to be withdrawn minuses from the balance
            bankBalance -= amount;

            Console.WriteLine("Withdrawal successful. New balance: " + bankBalance);
            return true;
        }
    }

    public bool deposit(int amount)
    {
        bankBalance += amount;
        Console.WriteLine("Deposit successful. New balance: " + bankBalance);
        return true;
    }
}

// class for ATM
class Atm
{
    // variable of bank 
    private Bank bank;

    // constructor 
    public Atm(Bank bank)
    {
        this.bank = bank;
    }

    // returns UI when run so user can access the banks options
    public void start()
    {
        Console.WriteLine("Welcome to " + bank.bankName + " ATM");
        Console.WriteLine("1. Check balance");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Deposit");
        Console.WriteLine("4. Exit");

        // checks if user choice is a integer
        int choice = int.Parse(Console.ReadLine());

        // options for bank
        switch (choice)
        {
            case 1:
                Console.WriteLine("Your current balance is: " + bank.checkBalance());
                break;
            case 2:
                Console.WriteLine("Enter amount to withdraw: ");
                int withdrawAmount = int.Parse(Console.ReadLine());
                bank.withdraw(withdrawAmount);
                break;
            case 3:
                Console.WriteLine("Enter amount to deposit: ");
                int depositAmount = int.Parse(Console.ReadLine());
                bank.deposit(depositAmount);
                break;
            case 4:
                Console.WriteLine("Thank you for using our ATM. Have a great day!");
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // instance of class with bank name, location and balcnce
        Bank bank = new Bank("Natwest", "12 Bruh Street", 5000);
        Atm atm = new Atm(bank);
        atm.start();
    }
}
