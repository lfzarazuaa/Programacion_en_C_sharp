using ConsultasLinQ.Consultas.Tareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultasLinQ.Consultas
{
    public static class Tarea
    {
        public static void Ejercicio_001()
        {
            Console.WriteLine("Ejercicio 001");
            //Origen de datos.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Consulta.
            var consulta = from number in numbers
                           where number < 5
                           select number;

            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ejercicio_002()
        {
            Console.WriteLine("Ejercicio 002");
            //Origen de datos.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Consulta.
            var consulta = from number in numbers
                           where number % 2 == 0
                           select number;

            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ejercicio_003()
        {
            Console.WriteLine("Ejercicio 003-Ascendente");
            //Origen de datos.
            string[] fruits = { "cherry", "apple", "blueberry" };

            //Consulta.
            var consulta = from fruit in fruits
                           orderby fruit ascending
                           select fruit;

            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Ejercicio 003-Descendente");

            //Consulta.
            var consulta2 = from fruit in fruits
                            orderby fruit descending
                            select fruit;

            //Ejecutar la consulta.
            foreach (var item in consulta2)
            {
                Console.WriteLine(item);
            }
        }


        public static void Ejercicio_004()
        {
            Console.WriteLine("Ejercicio 004");
            //Origen de datos.
            int[] scores = { 90, 71, 82, 93, 75, 82 };

            //Consulta.
            var consulta = from score in scores
                           orderby score descending
                           select score;

            //Ejecutar la consulta.
            Console.WriteLine(consulta.Max());
            Console.WriteLine(consulta.First());
        }



        public static void Ejercicio_005()
        {
            Console.WriteLine("Ejercicio 005");
            //Origen de datos.
            int[] scores = { 18, 25, 19, 16, 21, 80 };

            //Consulta.
            var consulta = from score in scores
                           where score > 20
                           select score;

            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ejercicio_006()
        {
            Console.WriteLine("Ejercicio 006");
            //Origen de datos.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Consulta.
            var consulta = from number in numbers
                           where number != 0 && number < 5 && number % 2 == 0
                           select number;

            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }


        public static void Ejercicio_007()
        {
            Console.WriteLine("Ejercicio 007");
            //Origen de datos.
            List<Student> students = new List<Student> {
                new Student {First="Svetlana", Last="Omelchenko", ID=111},
                new Student {First="Claire", Last="O'Donnell", ID=112},
                new Student {First="Sven", Last="Mortensen", ID=113},
                new Student {First="Cesar", Last="Garcia", ID=114},
                new Student {First="Debra", Last="Garcia", ID=115}
            };

            //Consulta.
            var consulta = from student in students
                           orderby student.Last ascending
                           select $"Mi nombre es {student.First} y mi apellido es {student.Last}";

            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ejercicio_008()
        {
            Console.WriteLine("Práctica 2-1");
            //Origen de datos.
            List<Curso> listaCursos = new List<Curso> {
                new Curso {idCurso=1, nombreCurso="Programación Orientada a Objetos"},
                new Curso {idCurso=2, nombreCurso="Cálculo Diferencial e Integral"},
                new Curso {idCurso=3, nombreCurso="Biología"},
                new Curso {idCurso=4, nombreCurso="Fundamentos de Electrónica"},
                new Curso {idCurso=5, nombreCurso="Tópicos Avanzados de Sensores"},
                new Curso {idCurso=6, nombreCurso="Termodinámica"},
                new Curso {idCurso=7, nombreCurso="Mecánica de Fluidos"},
                new Curso {idCurso=8, nombreCurso="Teoría Electromagnética"},
                new Curso {idCurso=9, nombreCurso="Microcontroladores y Microprocesadores"},
                new Curso {idCurso=10, nombreCurso="Diseño básico de elementos de máquina"},
                new Curso {idCurso=11, nombreCurso="Mecánica del cuerpo rígido"}
            };

            List<Profesor> listaProfesores = new List<Profesor> {
                new Profesor { idProfesor = 1, nombre = "Farrah Wooten", edad = 35, IdCurso = 2 },
                new Profesor { idProfesor = 2, nombre = "Ramona Casey", edad = 57, IdCurso = 3 },
                new Profesor { idProfesor = 3, nombre = "Matthew Wilkinson", edad = 57, IdCurso = 2 },
                new Profesor { idProfesor = 4, nombre = "Meghan Benson", edad = 30, IdCurso = 11 },
                new Profesor { idProfesor = 5, nombre = "Anjolie Kent", edad = 37, IdCurso = 3 },
                new Profesor { idProfesor = 6, nombre = "Trevor Tate", edad = 42, IdCurso = 4 },
                new Profesor { idProfesor = 7, nombre = "Neil Ferrell", edad = 39, IdCurso = 6 },
                new Profesor { idProfesor = 8, nombre = "Tate Rosa", edad = 67, IdCurso = 3 },
                new Profesor { idProfesor = 9, nombre = "Murphy Robbins", edad = 58, IdCurso = 3 },
                new Profesor { idProfesor = 10, nombre = "Lani Bowman", edad = 70, IdCurso = 5 },
                new Profesor { idProfesor = 11, nombre = "Colby Oneal", edad = 36, IdCurso = 6 },
                new Profesor { idProfesor = 12, nombre = "Cassandra Leon", edad = 49, IdCurso = 4 },
                new Profesor { idProfesor = 13, nombre = "Ivy Fletcher", edad = 68, IdCurso = 6 },
                new Profesor { idProfesor = 14, nombre = "Channing Spears", edad = 34, IdCurso = 10 },
                new Profesor { idProfesor = 15, nombre = "Candace Beach", edad = 65, IdCurso = 3 },
                new Profesor { idProfesor = 16, nombre = "Erich Frye", edad = 38, IdCurso = 5 },
                new Profesor { idProfesor = 17, nombre = "Nasim Mclean", edad = 52, IdCurso = 8 },
                new Profesor { idProfesor = 18, nombre = "Dillon Hebert", edad = 44, IdCurso = 3 },
                new Profesor { idProfesor = 19, nombre = "Wayne Barnett", edad = 37, IdCurso = 10 },
                new Profesor { idProfesor = 20, nombre = "Dai Hobbs", edad = 35, IdCurso = 7 },
                new Profesor { idProfesor = 21, nombre = "Miriam Christian", edad = 37, IdCurso = 2 },
                new Profesor { idProfesor = 22, nombre = "Hoyt Parrish", edad = 58, IdCurso = 5 },
                new Profesor { idProfesor = 23, nombre = "Iona Young", edad = 55, IdCurso = 7 },
                new Profesor { idProfesor = 24, nombre = "Blythe Kidd", edad = 49, IdCurso = 1 },
                new Profesor { idProfesor = 25, nombre = "Hope Cummings", edad = 46, IdCurso = 11 },
                new Profesor { idProfesor = 26, nombre = "Lesley Charles", edad = 28, IdCurso = 5 },
                new Profesor { idProfesor = 27, nombre = "Petra Pace", edad = 42, IdCurso = 6 },
                new Profesor { idProfesor = 28, nombre = "Ruth Carver", edad = 28, IdCurso = 11 },
                new Profesor { idProfesor = 29, nombre = "Gary Monroe", edad = 50, IdCurso = 6 },
                new Profesor { idProfesor = 30, nombre = "Sebastian Bryan", edad = 64, IdCurso = 1 },
                new Profesor { idProfesor = 31, nombre = "Christian Mccray", edad = 31, IdCurso = 6 },
                new Profesor { idProfesor = 32, nombre = "Moses Brown", edad = 43, IdCurso = 6 },
                new Profesor { idProfesor = 33, nombre = "Adena Oconnor", edad = 49, IdCurso = 4 },
                new Profesor { idProfesor = 34, nombre = "Wade Hines", edad = 55, IdCurso = 3 },
                new Profesor { idProfesor = 35, nombre = "Calista Kane", edad = 64, IdCurso = 11 },
                new Profesor { idProfesor = 36, nombre = "Hanae Grant", edad = 39, IdCurso = 4 },
                new Profesor { idProfesor = 37, nombre = "Adam Ramos", edad = 60, IdCurso = 10 },
                new Profesor { idProfesor = 38, nombre = "Suki Ray", edad = 50, IdCurso = 8 },
                new Profesor { idProfesor = 39, nombre = "Quinn Noble", edad = 54, IdCurso = 10 },
                new Profesor { idProfesor = 40, nombre = "Amanda Chen", edad = 59, IdCurso = 1 },
                new Profesor { idProfesor = 41, nombre = "Skyler Hernandez", edad = 35, IdCurso = 7 },
                new Profesor { idProfesor = 42, nombre = "Xena Chambers", edad = 66, IdCurso = 8 },
                new Profesor { idProfesor = 43, nombre = "Evan Morales", edad = 56, IdCurso = 3 },
                new Profesor { idProfesor = 44, nombre = "Laurel Gonzalez", edad = 39, IdCurso = 3 },
                new Profesor { idProfesor = 45, nombre = "Martena Watson", edad = 55, IdCurso = 6 },
                new Profesor { idProfesor = 46, nombre = "Ryan Herring", edad = 34, IdCurso = 10 },
                new Profesor { idProfesor = 47, nombre = "Blythe Warren", edad = 27, IdCurso = 5 },
                new Profesor { idProfesor = 48, nombre = "Samuel Glenn", edad = 30, IdCurso = 4 },
                new Profesor { idProfesor = 49, nombre = "Elizabeth Mercado", edad = 56, IdCurso = 4 },
                new Profesor { idProfesor = 50, nombre = "Carly Trujillo", edad = 46, IdCurso = 2 },
                new Profesor { idProfesor = 51, nombre = "McKenzie Gilliam", edad = 57, IdCurso = 4 },
                new Profesor { idProfesor = 52, nombre = "Daphne Montgomery", edad = 67, IdCurso = 4 },
                new Profesor { idProfesor = 53, nombre = "Britanney Mitchell", edad = 26, IdCurso = 10 },
                new Profesor { idProfesor = 54, nombre = "Gail Larson", edad = 51, IdCurso = 9 },
                new Profesor { idProfesor = 55, nombre = "Isadora Mcfadden", edad = 24, IdCurso = 2 },
                new Profesor { idProfesor = 56, nombre = "Holmes Wright", edad = 56, IdCurso = 2 },
                new Profesor { idProfesor = 57, nombre = "Chantale Adams", edad = 58, IdCurso = 1 },
                new Profesor { idProfesor = 58, nombre = "Barbara Guy", edad = 24, IdCurso = 1 },
                new Profesor { idProfesor = 59, nombre = "Alika Williams", edad = 67, IdCurso = 11 },
                new Profesor { idProfesor = 60, nombre = "Chaim Mason", edad = 39, IdCurso = 11 },
                new Profesor { idProfesor = 61, nombre = "Summer Gonzales", edad = 70, IdCurso = 1 },
                new Profesor { idProfesor = 62, nombre = "Amaya Noble", edad = 26, IdCurso = 7 },
                new Profesor { idProfesor = 63, nombre = "Britanney Johns", edad = 59, IdCurso = 3 },
                new Profesor { idProfesor = 64, nombre = "Preston Buckner", edad = 55, IdCurso = 9 },
                new Profesor { idProfesor = 65, nombre = "Dakota Maxwell", edad = 25, IdCurso = 2 },
                new Profesor { idProfesor = 66, nombre = "Eve Glover", edad = 45, IdCurso = 1 },
                new Profesor { idProfesor = 67, nombre = "Angela Thornton", edad = 32, IdCurso = 11 },
                new Profesor { idProfesor = 68, nombre = "Katell Miller", edad = 65, IdCurso = 4 },
                new Profesor { idProfesor = 69, nombre = "Harrison Booker", edad = 52, IdCurso = 6 },
                new Profesor { idProfesor = 70, nombre = "Ella Schmidt", edad = 29, IdCurso = 2 },
                new Profesor { idProfesor = 71, nombre = "Cade Nixon", edad = 64, IdCurso = 1 },
                new Profesor { idProfesor = 72, nombre = "Pamela Caldwell", edad = 64, IdCurso = 6 },
                new Profesor { idProfesor = 73, nombre = "Deacon Sampson", edad = 32, IdCurso = 11 },
                new Profesor { idProfesor = 74, nombre = "Althea Merritt", edad = 52, IdCurso = 5 },
                new Profesor { idProfesor = 75, nombre = "Ursa Sykes", edad = 70, IdCurso = 11 },
                new Profesor { idProfesor = 76, nombre = "Yasir Lynch", edad = 47, IdCurso = 4 },
                new Profesor { idProfesor = 77, nombre = "Tanya Wyatt", edad = 66, IdCurso = 8 },
                new Profesor { idProfesor = 78, nombre = "Trevor Meadows", edad = 42, IdCurso = 3 },
                new Profesor { idProfesor = 79, nombre = "Iliana Britt", edad = 45, IdCurso = 8 },
                new Profesor { idProfesor = 80, nombre = "Ethan Dudley", edad = 45, IdCurso = 11 },
                new Profesor { idProfesor = 81, nombre = "Cody Moon", edad = 40, IdCurso = 10 },
                new Profesor { idProfesor = 82, nombre = "Caldwell Berg", edad = 41, IdCurso = 9 },
                new Profesor { idProfesor = 83, nombre = "Melodie Wilkins", edad = 69, IdCurso = 1 },
                new Profesor { idProfesor = 84, nombre = "Lee Henry", edad = 49, IdCurso = 5 },
                new Profesor { idProfesor = 85, nombre = "Cole Odonnell", edad = 68, IdCurso = 2 },
                new Profesor { idProfesor = 86, nombre = "Marsden Sims", edad = 31, IdCurso = 10 },
                new Profesor { idProfesor = 87, nombre = "Rafael Chan", edad = 64, IdCurso = 10 },
                new Profesor { idProfesor = 88, nombre = "Fallon Davis", edad = 63, IdCurso = 2 },
                new Profesor { idProfesor = 89, nombre = "Louis Thornton", edad = 64, IdCurso = 9 },
                new Profesor { idProfesor = 90, nombre = "Tana Meadows", edad = 67, IdCurso = 9 },
                new Profesor { idProfesor = 91, nombre = "Sloane Foley", edad = 62, IdCurso = 3 },
                new Profesor { idProfesor = 92, nombre = "Nayda Cole", edad = 57, IdCurso = 5 },
                new Profesor { idProfesor = 93, nombre = "Pascale Ewing", edad = 59, IdCurso = 6 },
                new Profesor { idProfesor = 94, nombre = "Stacy Bridges", edad = 68, IdCurso = 3 },
                new Profesor { idProfesor = 95, nombre = "Emily Fitzpatrick", edad = 47, IdCurso = 5 },
                new Profesor { idProfesor = 96, nombre = "Dahlia Gates", edad = 37, IdCurso = 2 },
                new Profesor { idProfesor = 97, nombre = "Sandra Sheppard", edad = 30, IdCurso = 11 },
                new Profesor { idProfesor = 98, nombre = "Jena Wallace", edad = 58, IdCurso = 10 },
                new Profesor { idProfesor = 99, nombre = "Gay Hays", edad = 41, IdCurso = 11 },
                new Profesor { idProfesor = 100, nombre = "Dean Barr", edad = 54, IdCurso = 9 }
            };

            //Consulta.
            var consulta = from profesor in listaProfesores
                           join curso in listaCursos on profesor.IdCurso equals curso.idCurso
                           orderby curso.nombreCurso ascending
                           select $"El curso {curso.nombreCurso} es enseñado por {profesor.nombre}";

            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }


        public static void Ejercicio_009()
        {
            Console.WriteLine("Práctica 2-2 Números pares expresion lambda");
            //Origen de datos.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Consulta.
            var consulta = numbers.Where(n => n % 2 == 0);

            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ejercicio_010()
        {
            Console.WriteLine("Práctica 2-3 Números mayores a 5 expresion lambda");
            //Origen de datos.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Consulta.
            var consulta = numbers.Where(n => n > 5);

            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }
    }
}
