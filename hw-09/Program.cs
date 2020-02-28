using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_09
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Triangle> triangles = new List<Triangle>
            {
                new Triangle(-1, 6, 5, 6, -8, 4),
                new Triangle(5, 1, -3, 8, -4, 5),
                new Triangle(7, 6, -10, 6, 15, 1)
            };

            for (int i = 0; i < triangles.Count; i++)
            {
                if (i > 0)
                {
                    Console.WriteLine();
                }

                Console.WriteLine($"Triangle {i + 1}:");
                Console.WriteLine(triangles[i].Print());
            }

            Console.WriteLine();
            Console.WriteLine("The closest triangle to origin is:");
            Console.WriteLine(GetClosesToOriginTriangle(triangles).Print());

            string text = "Style never met and those among great. At no or september sportsmen he perfectly happiness attending. Depending listening delivered off new she procuring satisfied sex existence. Person plenty answer to exeter it if. Law use assistance especially resolution cultivated did out sentiments unsatiable. Way necessary had intention happiness but september delighted his curiosity. Furniture furnished or on strangers neglected remainder engrossed. Way nor furnished sir procuring therefore but. Warmth far manner myself active are cannot called. Set her half end girl rich met. Me allowance departure an curiosity ye. In no talking address excited it conduct. Husbands debating replying overcame blessing he it me to domestic. Name were we at hope. Remainder household direction zealously the unwilling bed sex. Lose and gay ham sake met that. Stood her place one ten spoke yet. Head case knew ever set why over. Marianne returned of peculiar replying in moderate. Roused get enable garret estate old county. Entreaties you devonshire law dissimilar terminated. To sure calm much most long me mean. Able rent long in do we. Uncommonly no it announcing melancholy an in. Mirth learn it he given. Secure shy favour length all twenty denote. He felicity no an at packages answered opinions juvenile. Inhabiting discretion the her dispatched decisively boisterous joy. So form were wish open is able of mile of. Waiting express if prevent it we an musical. Especially reasonable travelling she son. Resources resembled forfeited no to zealously. Has procured daughter how friendly followed repeated who surprise. Great asked oh under on voice downs. Law together prospect kindness securing six. Learning why get hastened smallest cheerful. Advanced extended doubtful he he blessing together. Introduced far law gay considered frequently entreaties difficulty. Eat him four are rich nor calm. By an packages rejoiced exercise. To ought on am marry rooms doubt music. Mention entered an through company as. Up arrived no painful between. It declared is prospect an insisted pleasure. Received the likewise law graceful his. Nor might set along charm now equal green. Pleased yet equally correct colonel not one. Say anxious carried compact conduct sex general nay certain. Mrs for recommend exquisite household eagerness preserved now. My improved honoured he am ecstatic quitting greatest formerly. Their could can widen ten she any. As so we smart those money in. Am wrote up whole so tears sense oh. Absolute required of reserved in offering no. How sense found our those gay again taken the. Had mrs outweigh desirous sex overcame. Improved property reserved disposal do offering me. Far concluded not his something extremity. Want four we face an he gate. On he of played he ladies answer little though nature. Blessing oh do pleasure as so formerly. Took four spot soon led size you. Outlived it received he material. Him yourself joy moderate off repeated laughter outweigh screened. Ye on properly handsome returned throwing am no whatever. In without wishing he of picture no exposed talking minutes. Curiosity continual belonging offending so explained it exquisite. Do remember to followed yourself material mr recurred carriage. High drew west we no or at john. About or given on witty event. Or sociable up material bachelor bringing landlord confined. Busy so many in hung easy find well up. So of exquisite my an explained remainder. Dashwood denoting securing be on perceive my laughing so.";

            Console.WriteLine();
            Console.WriteLine("10 commonly used words in the text:");
            
            foreach (KeyValuePair<string, int> word in GetTop10CommonlyUsedWords(text))
            {
                Console.WriteLine($"{word.Key}: {word.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("Press Ctrl + C to exit");
            Console.ReadLine();
        }

        static Triangle GetClosesToOriginTriangle(List<Triangle> triangles)
        {
            Triangle theClosestToOriginTriangle = triangles[0];

            double minDistanceToOrigin = GetMinDistanceToOrigin(triangles[0]);

            for (int i = 1; i < triangles.Count; i++)
            {
                if (GetMinDistanceToOrigin(triangles[i]) < minDistanceToOrigin)
                {
                    theClosestToOriginTriangle = triangles[i];
                }
            }

            return theClosestToOriginTriangle;
        }

        static double GetMinDistanceToOrigin(Triangle triangle)
        {
            Point originPoint = new Point(0, 0);

            double[] distances = {
                triangle.vertex1.Distance(originPoint),
                triangle.vertex2.Distance(originPoint),
                triangle.vertex3.Distance(originPoint)
            };

            return distances.Min();
        }

        static Dictionary<string, int> GetTop10CommonlyUsedWords(string text)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                string clearWord = word.Trim();

                if (!string.IsNullOrEmpty(clearWord))
                {
                    clearWord = clearWord.Replace(',', new char());
                    clearWord = clearWord.Replace('.', new char());

                    if (dictionary.ContainsKey(clearWord))
                    {
                        dictionary[clearWord] = dictionary[clearWord] + 1;
                    }
                    else
                    {
                        dictionary[clearWord] = 1;
                    }
                }
            }

            return dictionary.OrderByDescending(item => item.Value).Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
