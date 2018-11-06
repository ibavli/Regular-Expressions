using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressionsExamples
{
    class Program
    {
        static void Main(string[] args)
        {  /*
                ÖZEL KARAKTERLER 

                Bir string ya da string dizisi içerisinden çeşitli ifade kalıplarını kullanarak, bu kalıplara uyan yeni string ya da string dizileri elde etmek amacı ile kullanılır. Örneğin; bir yazı içerisindeki web adreslerini elde etmek ya da bir web sayfasındaki mail adreslerini elde etmek gibi.

                $ => Bir metnin bitiş pozisyonunu belirtir. Örnek olarak multiline özelliği aktif edildiğinde bir satırın bitiş pozisyonunu ifade eder.

                () => Bir alt ifadenin başlangıç ve bitişine işaret eder.

                * => Kendisinden önce belirtilen karakterin belirtilen metnin içerisinde ya hiç olmadığını ya da bir veya birden fazla mevcut olduğunu belirtir.

                + => Kendisinden önce belirtilen karakterin veya alt ifadenin bir veya daha fazla defa tekrarlanabileceğini belirtir.

                . => Yeni satır karakteri (\n) dışındaki herhangi bir karakteri belirtir.

                [] => Bir aralığın başlangıcını belirtir.

                ? => Kendisinden önce belirtilen karakterin belirtilen metin içerisinde ya hiç olmadığını ya da mevcut olduğunu belirtir.

                \ => Kendisinden sonra belirtilen karakterin arama kriterini oluşturan ifade içerisine dahil edilmesini sağlar.

                / => Bir düzenli ifadenin başlangıcını veya bitişini belirtir.

                ^ => Karşılaştırma işleminin başlayacağı ilk karakteri belirtir.

                {} => Kendisinden önce gelen karakterin ne kadar tekrar edilebileceğini belirtir.

                | => İki eleman arasındaki seçimi belirtir.


                YAZDIRILMAYAN KARAKTERLER

                \cx => Ctrl tuşu ile birlikte kullanılan karakterleri belirtir. Örneğin \cV ifadesi Ctrl + V tuşlarını belirtir.

                \n => Yeni satır başlangıcını belirtir.

                \r => Satırbaşı karakteri

                \s => Boşluk karakteri

                \S => Boşluk olmayan karakterler

                \t => Tap karakterini belirtir

     */
            //REGEX
            //Regex sınıfı arama, karşılaştırma ve değiştirme işlemleri için kullanabileceğimiz ///metotlara sahip bir sınıftır.

            //IsMatch Metodu bir metnin başka bir metnin içerisinde mevcut olup olmadığını bulmak için kullanılır ve boolean değer döner.

            //Herhangi bir seçenek uygulanmaz.
            bool NoneControl = Regex.IsMatch("deneme", "dene", RegexOptions.None);
            Console.WriteLine("None result => " + NoneControl.ToString());

            //Büyük küçük harf duyarlı olmadan arama yapılır.
            bool IgnoreCaseControl = Regex.IsMatch("Deneme", "dene", RegexOptions.IgnoreCase);
            Console.WriteLine("IgnoreCase result => " + IgnoreCaseControl.ToString());

            //Birden fazla satır üzerinde işlem yapılacağını belirtir.
            bool MultilineControl = Regex.IsMatch("Deneme", "dene", RegexOptions.Multiline);
            Console.WriteLine("Multiline result => " + MultilineControl.ToString());

            //Arama kalıbı (pattern) içerisindeki boşlukların yok sayılmasını sağlar.
            bool IgnorePatternWhitespaceControl = Regex.IsMatch("deneme", "den e", RegexOptions.IgnorePatternWhitespace);
            Console.WriteLine("IgnorePatternWhitespace result => " + IgnorePatternWhitespaceControl.ToString());

            //Sağdan sola doğru bir arama yapar. Aranan kelime ile mi bitmiş diye kontrol ediyor.
            bool RightToLeftControl = Regex.IsMatch("deneme", "neme", RegexOptions.RightToLeft);
            Console.WriteLine("RightToLeft result => " + RightToLeftControl.ToString());

            //Stringin içi boş mu diye kontrol ediyoruz.
            //   \s başlangıç boş olabilir demek istedik.
            //   * ile boşluğun bir ya da birden fazla olabileceğini
            //   $ ile arama metninin sonuna gelindiğini belirttik.
            string EmptyString = "x";
            if (Regex.IsMatch(EmptyString, "^\\s*$"))
                Console.WriteLine("EmptyString is empty.");
            else
                Console.WriteLine("EmptyString is not empty");

            Console.WriteLine("\n------\n");
            //MATCH Metodu bir metni başka bir metin içerisinde aramak amacı ile kullanılır ve eğer metin bulunursa geriye aranan metin döndürülür.

            // ^Adı: ile Adı: kelimesi ile başlayan metinleri, (.*) ile de Adı: kelimesinden sonra gelebilecek herhangi bir metni arıyoruz.
            //Groups metodu ile bulunan metinler dizi içerisinde saklanır. Örneğimizde Groups[1].Value şeklinde kullanım ile bulunan değerlenden ilk sıradaki değeri görüntülüyoruz.
            string ResultNameString = "Adı:ibrahim bavlı";
            string Name = Regex.Match(ResultNameString, "Adı:(.*)", RegexOptions.IgnoreCase).Groups[1].Value;
            Console.WriteLine(Name);

            //30 karakter uzunluğundan uzun olamaz.
            string NameSurname = "qwertyuopasdfghjklzcvbnmqwertjk";
            Regex regex1 = new Regex("^[a-zA-Z\\s]{1,30}$");
            if (!regex1.Match(NameSurname).Success)
                Console.WriteLine("30 karakter uzunluğunda bir string giirebilirsiniz.");


            //TC kimlik sadece 11 karakterden oluşabilir.
            string TCkimlik = "4511221121";
            Regex regex2 = new Regex("^\\d{11}$");
            if (!regex2.Match(TCkimlik).Success)
                Console.WriteLine("TC kimlik numarasında bir yanlışlık var");

            string Phone = "0 555 323 22 22";
            Regex regex3 = new Regex(@"^(0 (\d{3}) (\d{3}) (\d{2}) (\d{2}))$");
            if (!regex3.Match(Phone).Success)
                Console.WriteLine("Telefon numarasında bir yanlışlık var");

            string IsJustNumber = "1";
            Regex regex4 = new Regex("^\\d*$");
            if (!regex4.Match(IsJustNumber).Success)
                Console.WriteLine("Yalnızca rakam girebilirsiniz");
            Console.Read();

        }
    }
}
