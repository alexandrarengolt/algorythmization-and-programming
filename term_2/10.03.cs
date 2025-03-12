class PNumber
    {
        public string PhoneNumber { get; set; }
        public string Operator { get; set; }

        public PNumber(string num, string oper)
        {
            PhoneNumber = num;
            Operator = oper;
        }
    }
public class Program
{
    public static void Main(string[] args)
    {
        List<PNumber> phones = new List<PNumber>()
        {
            new PNumber("999-454-7830", "ОтпетыеМошенники"),
            new PNumber("987-654-3210", "СамыеНевыгодныеТарифы"),
            new PNumber("555-123-4567", "НичеНеСлышно"),
            new PNumber("151-262-3033", "СамыеНевыгодныеТарифы"),
            new PNumber("444-555-6666", "СамыеНевыгодныеТарифы"),
            new PNumber("777-888-9999", "ОтпетыеМошенники"),
            new PNumber("733-818-2399", "НикогдаНеНаСвязи"),
        };
        Dictionary<string, int> amount = new Dictionary<string, int>();
    
        foreach (PNumber phone in phones)
            {
                if (amount.ContainsKey(phone.Operator))
                {
                    amount[phone.Operator]++;
                }
                else
                {
                    amount[phone.Operator] = 1;
                }
            }

        Console.WriteLine("Частота встречаемости операторов:");
        foreach (KeyValuePair<string, int> pair in amount)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
