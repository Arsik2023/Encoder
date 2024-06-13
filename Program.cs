using System.Runtime.Serialization.Formatters;
// начал кодить в 22:15
internal partial class Program
{
    static string all_signs_in_string = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz123456879!@#$%|^&*()_+\\/.,<>?";

    public static void Encrypt_text()
    {
        Console.Write("Введите сообщение: ");
        string text = Console.ReadLine();
        Console.Write("Зашифрованное сообщение: ");
        string encrypted_text = "";

        Random random = new Random();
        int random_number = random.Next(1, 9);

        for (int i = 0; i < text.Length; i++)
        {
            if (all_signs_in_string.Contains(text[i]))
            {
                int index = all_signs_in_string.IndexOf(text[i]);
                if ((index + random_number) < all_signs_in_string.Length)
                {
                    encrypted_text = encrypted_text + all_signs_in_string[index + random_number];
                }
                else
                {
                    encrypted_text = encrypted_text + all_signs_in_string[(index + random_number) - all_signs_in_string.Length];
                }
            }
            else
            {
                encrypted_text = encrypted_text + text[i];
            }
        }
        encrypted_text = encrypted_text + random_number;
        Console.WriteLine(encrypted_text);
    }
    public static void Decrypt_text()
    {
        Console.Write("Введите зашифрованное сообщение: ");
        string text = Console.ReadLine();
        Console.Write("Дешифрованное сообщение: ");

        int random_number = Convert.ToInt32(text[text.Length-1].ToString());
        string decrypted_text = "";
        string encrypted_text_with_out_last_letter = text.Remove(text.Length-1);

        for (int i = 0; i < encrypted_text_with_out_last_letter.Length; i++)
        {
            if (all_signs_in_string.Contains(encrypted_text_with_out_last_letter[i]))
            {
                int index = all_signs_in_string.IndexOf(encrypted_text_with_out_last_letter[i]);
                if ((index - random_number) < 0)
                {
                    decrypted_text = decrypted_text + all_signs_in_string[all_signs_in_string.Length + (index - random_number)];
                }
                else
                {
                    decrypted_text = decrypted_text + all_signs_in_string[index - random_number];
                }
            }
            else
            {
                decrypted_text = decrypted_text + encrypted_text_with_out_last_letter[i];
            }
        }
        Console.WriteLine(decrypted_text);
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Шифрование сообщения --- 1");
        Console.WriteLine("Десифрование сообщения - 2");
        Console.Write("Выберите, что вам нужно (1/2): ");
        string choice = Console.ReadLine();
        if (choice != "1" && choice != "2")
        {
            while (choice != "1" && choice != "2")
            {
            Console.WriteLine("Шифрование сообщения --- 1");
            Console.WriteLine("Десифрование сообщения - 2");
            Console.Write("Выберите либо 1, либо 2 в зависимости от того, что надо: ");
            choice = Console.ReadLine();
            }
        }
        if (choice == "1")
        {
            Encrypt_text();
        }
        if (choice == "2")
        {
            Decrypt_text();
        }
        
    }
}