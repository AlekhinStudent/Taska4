Console.WriteLine("Введите число в десятичной системе:");
int decimalNumber = int.Parse(Console.ReadLine());

Console.WriteLine("Введите основание системы счисления q (от 2 до 9):");
int q = int.Parse(Console.ReadLine());

if (q < 2 || q > 9)
{
    Console.WriteLine("Основание системы счисления должно быть от 2 до 9.");
    return;
}

string qBaseNumber = ConvertDecimalToQBase(decimalNumber, q);
Console.WriteLine($"Число {decimalNumber} в системе счисления с основанием {q}: {qBaseNumber}");

// Часть 2: Из q-ичной в десятичную

Console.WriteLine($"Введите число в {q}-ичной системе счисления:"); // Исправлено
string qBaseInput = Console.ReadLine();

Console.WriteLine("Введите основание системы счисления q (от 2 до 9):");
int q2 = int.Parse(Console.ReadLine());

if (q2 < 2 || q2 > 9)
{
    Console.WriteLine("Основание системы счисления должно быть от 2 до 9.");
    return;
}

int decimalFromQBase = ConvertQBaseToDecimal(qBaseInput, q2);
Console.WriteLine($"Число {qBaseInput} в десятичной системе: {decimalFromQBase}");


// Часть 3: Из q1-ичной в q2-ичную

Console.WriteLine("Введите число в q1-ичной системе:");
string q1BaseInput = Console.ReadLine();

Console.WriteLine("Введите основание исходной системы счисления q1 (от 2 до 9):");
int q1 = int.Parse(Console.ReadLine());

Console.WriteLine("Введите основание целевой системы счисления q2 (от 2 до 9):");
int q3 = int.Parse(Console.ReadLine());


if (q1 < 2 || q1 > 9 || q3 < 2 || q3 > 9)
{
    Console.WriteLine("Основание системы счисления должно быть от 2 до 9.");
    return;
}

// Конвертируем q1-ичное число в десятичное
int decimalIntermediate = ConvertQBaseToDecimal(q1BaseInput, q1);

// Конвертируем десятичное число в q2-ичное
string q2BaseResult = ConvertDecimalToQBase(decimalIntermediate, q3);


Console.WriteLine($"Число {q1BaseInput} из системы счисления с основанием {q1} в систему счисления с основанием {q3}: {q2BaseResult}");


// Функция для перевода из десятичной в q-ичную
static string ConvertDecimalToQBase(int decimalNumber, int q)
{
    string result = "";
    while (decimalNumber > 0)
    {
        int remainder = decimalNumber % q;
        result = remainder + result; // Добавляем остаток в начало строки
        decimalNumber /= q;
    }
    return (result == "" ? "0" : result); //  Если входное число 0,  вернем "0"
}

// Функция для перевода из q-ичной в десятичную
static int ConvertQBaseToDecimal(string qBaseNumber, int q)
{
    int decimalResult = 0;
    int power = 1;

    // Идем по строке справа налево
    for (int i = qBaseNumber.Length - 1; i >= 0; i--)
    {
        int digit = int.Parse(qBaseNumber[i].ToString());
        decimalResult += digit * power;
        power *= q;
    }

    return decimalResult;
}