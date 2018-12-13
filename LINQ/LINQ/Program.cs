using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {

        /*
         
        Нижче є завдання, які слід вирішити використовуючи лише Linq. Для початку застосуйте функцію String.Split, також вам можуть пригодитися наступні функції: String.Join, Enumerable.Range, Zip, Aggregate, SelectMany і клас TimeSpan.
        На вхід є стрічка  "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert"
        Кожному гравцеві надайте номер, починаючи з 1, щоб вийшла стрічка подібна : "1. Davis, 2. Clyne, 3. Fonte" ...
        */
        static void Main(string[] args)
        {
            //вхідна стрічка
            string inputNames = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";

            // масив знаків розділювачів, щоб знати яким чином розбивати її на підрядки - імена
            char[] splittersNames = { ' ', ',' };
            // вивід на екран вхідної стрічки
            Console.WriteLine(String.Format("Inpup string: \n{0}", inputNames));
            // множина Імен - персонс - результат  розбиття вхідного рядка , System.StringSplitOptions.RemoveEmptyEntries = щоб ігнорувати пробіли
            string[] Persons = inputNames.Split(splittersNames, System.StringSplitOptions.RemoveEmptyEntries);
            // вибираємо з масиву стрічок - імен person у перечислювальні об'єкти з властивостями - номер, імя, номер + імя IndexName
            var person = Persons.Select((p, i) => new { Index = i + 1, Name = p, IndexName = String.Format("{0}.{1}", i + 1, p) });

            // номер + імя записуємо у масив person
            foreach (var obj in person)
                Persons[obj.Index - 1] = obj.IndexName;
            // додаємо розділювач між записами
            String splitter = ", ";
            String result;
            // обєднуємо множину стрічок з номерів і імен у одну
            result = String.Join(splitter, Persons, 0, Persons.Length);
            Console.WriteLine(String.Format("\nResult string: \n{0}", result));
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            /*
         
       
         Візьміть стрічку "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; 
         Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
            і перетворіть її на IEnumerable гравців в порядку віку (і ще бажано вивести вік)
       
         */
            string inputPlayers = "Jason Puncheon, 26/06/1986;Jos Hooiveld, 22/04/1983;Kelvin Davis, 29/09/1976;Luke Shaw, 12/07/1995;" +
                        "Gaston Ramirez, 02/12/1990;Adam Lallana, 10/05/1988";

            Console.WriteLine(String.Format("\n------------------------------------------\n\nPart 2:\n"));
            Console.WriteLine(String.Format("Inpup string: \n{0}", inputPlayers));

            char[] splittersPlayers = { ';' };
            string[] PlayersArray = inputPlayers.Split(splittersPlayers, System.StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(String.Format("\nPlayers sorted by age:\n"));

            IEnumerable<Player> Team = PlayersArray.Select(x => new Player(x) { });

            var resSort = from player in Team
                          orderby player.GetAge()
                          select player;

            foreach (Player obj in resSort)
                Console.WriteLine(obj.Name + " - " + obj.Birth + " - " + obj.GetAge());

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            /*
         
                Візьміть стрічку "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27", 
                яка відображає довжину пісень в хвилинах і секунда і обрахуйте загальну довжину всіх пісень.

         */
            string inputSongsLength = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";

            Console.WriteLine(String.Format("\n------------------------------------------\n\nPart 3:\n"));
            Console.WriteLine(String.Format("Inpup string: \n{0}", inputSongsLength));

            char[] splittersSongs = { ',' };
            string[] Songs = inputSongsLength.Split(splittersSongs, System.StringSplitOptions.RemoveEmptyEntries);


            IEnumerable<Song> PlayList = Songs.Select(x => new Song(x) { });

            int Sum = PlayList.Sum(n => n.LengthSec);

            Console.WriteLine(String.Format("\nTotal songs time: {0}:{1}\n", Sum / 60, Sum % 60));

            Console.ReadKey();
            return;

        }
    }

    class Song
    {
        public int LengthSec
        {
            get;
        }
        public Song(string l)
        {
            char[] splitterPlayerInfo = { ':' };
            string[] Info = l.Split(splitterPlayerInfo, System.StringSplitOptions.RemoveEmptyEntries);
            // час в секундах
            LengthSec = Convert.ToInt16(Info[0]) * 60 + Convert.ToInt16(Info[1]);
        }
    }
    class Player
    {
        public Player(string n)
        {
            // розділяємо інфу про гравця на імя і дату народження і записуємо у поля класу
            char[] splitterPlayerInfo = { ',' };
            string[] Info = n.Split(splitterPlayerInfo, System.StringSplitOptions.RemoveEmptyEntries);
            Name = Info[0];
            Birth = Info[1];
        }

        public string Name
        {
            get;
        }
        public string Birth
        {
            get;
        }

        public int GetAge()
        {
            // рахуємо вік
            DateTime birthDate = Convert.ToDateTime(Birth);

            var now = DateTime.Today;
            return now.Year - birthDate.Year - 1 +
                ((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 1 : 0);
        }

    }


}
