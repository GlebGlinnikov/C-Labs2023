using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

namespace Lab2
{
    public class Mark 
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double[] sol { get; set; }

        public Mark() {}
        public Mark(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            if (a != 0) sol = EquationSolver.SolveQuadratic(a, b, c);
            else sol = EquationSolver.SolveLinear(b, c);
        }

        public Mark(double b, double c)
        {
            this.b = b;
            this.c = c;
            sol = EquationSolver.SolveLinear(b, c);
        }

        public void print()
        {
            string output, equation;
 
            if (a == 0)
            {
                equation = $"{b}x + {c} = 0";
                output = $"x = {sol[0]}";
            }

            else
            {
                equation = $"{a}x^2 + {b}x + {c} = 0";
                if (sol.Length == 2)
                {
                    output = $"x1 = {sol[0]}, x2 = {sol[1]}";
                }
                else if (sol.Length == 1)
                {
                    output = $"x1 = {sol[0]}";
                }
                else
                {
                    output = "No solutions";
                }
            }

            Console.WriteLine($"Solution: {equation} => {output}");
        }

        public void serializeToXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Mark));

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, this);
            }
        }

        public void serializeToJson(string filePath)
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(filePath, json);
        }
    }
}
