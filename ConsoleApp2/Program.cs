using System;
public class cardHolder
{
    string cardNum;
    int pin;
    string FirstName;
    string LastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        FirstName = firstName;
        LastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return this.cardNum;
    }

    public int getPin()
    {
        return this.pin;
    }

    public string getFirstName()
    {
        return FirstName;
    }

    public string getLastName()
    { return LastName; }

    public double getBalance()
    { return this.balance; }

    public void setPin(int newPin)
    { pin = newPin; }

    public void setFirstName(String newFirstName)
    { FirstName = newFirstName; }

    public void setLastName(String newLastName)
    { LastName = newLastName; }

    public void setBalance(Double newBalance)
    { balance = newBalance; }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Lütfen seçeneklerden birini seçiniz...");
            Console.WriteLine("1. Para yatır");
            Console.WriteLine("2. Para çek");
            Console.WriteLine("3. Bakiye göster");
            Console.WriteLine("4. Çıkış");

        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("Ne kadar para yatırmak istiyorsunuz?: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Yeni bakiyeniz: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("Ne kadar para çekmek istiyorsunuz? ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Yetersiz bakiye...");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Yeni bakiyeniz: " + currentUser.getBalance());
            }

        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Yeni bakiyeniz: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4556780797904452", 1234, "Syble", "Treutel", 150.31));
        cardHolders.Add(new cardHolder("4532728918783460", 4321, "Jewel", "Christiansen", 178.0));
        cardHolders.Add(new cardHolder("4532843551977103", 3421, "Dudley", "Grimes", 3200.55));
        cardHolders.Add(new cardHolder("4556216476176005", 2134, "Idella", "Krajcik", 15.75));
        cardHolders.Add(new cardHolder("4716514922634578", 3421, "Makayla", "Moore", 700.21));


        //Başlangıç

        Console.WriteLine("EnesBank'a Hoş geldiniz!");
        Console.WriteLine("Kart numaranızı giriniz: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Kart tanınmadı. Tekrar deneyiniz."); }
            }
            catch { Console.WriteLine("Kart tanınmadı. Tekrar deneyiniz."); }
        }

        Console.WriteLine("Lütfen dört haneli şifrenizi giriniz: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Şifre yanlış. Tekrar deneyiniz."); }
            }
            catch { Console.WriteLine("Şifre yanlış. Tekrar deneyiniz."); }

        }

        Console.WriteLine("Hoşgeldin, " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option== 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }

        }while (true);
    }
}