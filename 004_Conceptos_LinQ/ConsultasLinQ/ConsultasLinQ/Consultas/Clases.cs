using ConsultasLinQ.Consultas.Ejercicio_003_consulta_a_clase;
using ConsultasLinQ.Consultas.Ejercicio_005_orderby;
using ConsultasLinQ.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Sources;
using ConsultasLinQ.Consultas.Ejercicio_007_transformacion;
using ConsultasLinQ.Consultas.Ejercicio_012_join;
using ConsultasLinQ.Ejercicio_013_join_multiple;
using ConsultasLinQ.Consultas.Ejercicio_013_join_multiple;
using ConsultasLinQ.Consultas.Ejercicio_014_join_multiple;
using ConsultasLinQ.Consultas.Ejercicio_017_lambda;
using System.Linq.Expressions;

namespace ConsultasLinQ.Consultas
{
    public static class Clases
    {
        public static void Clase_001()
        {
            Console.WriteLine("Clase 001-Consulta básica");
            //Origen de datos.
            int[] scores = new int[] { 97, 92, 81, 60 };

            //Consulta.
            var consulta = from score in scores //Score es la variable de rango, scores el origen de datos.
                           where score > 80 //Condicional
                           select score; //Campos que contendra el resultado.
            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ejercicio_001()
        {
            Console.WriteLine("Ejercicio 001-Consulta básica");
            //Origen de datos.
            int[] notas = new int[] { 10, 11, 17, 8, 9, 13, 14 };

            //Consulta.
            var consulta = from nota in notas //Notas es la variable de rango, nota el origen de datos.
                           where nota > 10 //Condicional
                           select nota; //Campos que contendra el resultado.
            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }

        /*Obtener : a)El numero de elementos de la respuesta 
         * b)El mayor elemento de la respuesta 
         * c) El promedio de la respuesta 
         * d)El primer elemento de la respuesta
        */
        public static void Ejercicio_002()
        {
            Console.WriteLine("Ejercicio 002-Métodos a la consulta");
            //Origen de datos.
            int[] numeros = new int[4] { 10, 11, 12, 13 };

            //Consulta.
            var consulta = from numero in numeros //numeros es la variable de rango, numero el origen de datos.
                           where numero % 2==0 //Números pares.
                           select numero; //Campos que contendra el resultado.
            //Ejecutar la consulta.
            Console.WriteLine($" El numero de elementos de la respuesta es {consulta.Count()}");
            Console.WriteLine($" El mayor elemento de la respuesta es {consulta.Max()}");
            Console.WriteLine($" El promedio de la respuesta es {consulta.Average()}");
            Console.WriteLine($" El primer de la respuesta es {consulta.FirstOrDefault()}");
        }

        public static void Ejercicio_003()
        {
            Console.WriteLine("Ejercicio 003-Consulta a clase");
            //Origen de datos.
            List<Customers> listaCustomers = new List<Customers>
            {
                new Customers {nombre="Ricardo" , apellido="Sanchez" , ciudad="Lima" },
                new Customers {nombre="Victor" , apellido="Alegria" , ciudad="Arequipá" },
                new Customers {nombre="Julio" , apellido="Felipe" , ciudad="Lima" },
            };


            //Consulta Aquellos que viven en Lima (Nombre: ______ Apellido: ________).
            IEnumerable<Customers> consulta = from item in listaCustomers
                                              where item.ciudad.Equals("Lima")//Compara la cadena.
                                              select item; //Campos que contendra el resultado.
            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine($" Aquellos que viven en Lima son: {item.nombre} {item.apellido}");
            }
        }

        public static void Ejercicio_004()
        {
            Console.WriteLine("Ejercicio 004-Consulta a usando order by");
            //Origen de datos.
            int[] notas = new int[] { 10, 11, 17, 8, 9, 13, 14 };

            //Creación de la consulta.
            IEnumerable<int> notasQuery = from nota in notas
                                          where nota > 10 //Notas mayores a 10
                                          orderby nota ascending// Ordenar ascendentemente.
                                          select nota;//Campo a seleccionar.
            
            Console.WriteLine($"Las notas son:");
            //Ejecutar la consulta.
            foreach (var item in notasQuery)
            {
                Console.WriteLine($" {item}");
            }
        }

        /*
         * Tenemos una lista de empleados :Imprimir con el formato:
         * “El apellido es…,su sueldo es …” de aquellos que ganan mas de 1500 .
         * Ordenar por orden alfabético de acuerdo al apellido ascendentemente 
         */
        public static void Ejercicio_005()
        {
            Console.WriteLine("Ejercicio 005-Consulta a una clase usando order by");
            //Origen de datos.
            List<Empleado> listaEmpleado = new List<Empleado>
            {
                new Empleado {nombre="Pepe" , apellido="Lucho" ,sueldo=1500 },
                new Empleado {nombre="Jose" , apellido="Perez" ,sueldo=1800 },
                new Empleado {nombre="Nicolas" , apellido="Alva" ,sueldo=1590 },
                new Empleado {nombre="Charo" , apellido="Gonzalez" ,sueldo=1520 }
            };

            //Creación de la consulta.
            var consulta = from empleado in listaEmpleado
                           where empleado.sueldo > 1500 //Sueldo mayor a 1500.
                           orderby empleado.nombre descending// Ordenar descendentemente
                           select empleado;//Campo a seleccionar.
            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine($"El apellido es {item.apellido} y su sueldo es {item.sueldo}");
            }
        }

        public static void Ejercicio_006()
        {
            Console.WriteLine("Ejercicio 006-Consulta con string en select");
            //Origen de datos.
            List<Ejercicio_006_select_string.Empleado> listaEmpleados = new List<Ejercicio_006_select_string.Empleado>
            {
                new Ejercicio_006_select_string.Empleado {nombreCompleto="Jorge Cairo", ciudad="Lima", sueldo=1500 },
                new Ejercicio_006_select_string.Empleado {nombreCompleto="Jonathan Olivares", ciudad="Arequipa", sueldo=1800 },
                new Ejercicio_006_select_string.Empleado {nombreCompleto="Sebastian Gonzales", ciudad="Lima", sueldo=1590 },
                new Ejercicio_006_select_string.Empleado {nombreCompleto="Pedrito Lorcho", ciudad="Lima", sueldo=1520 }
            };

            //Creación de la consulta con select tipo string.
            var consulta = from empleado in listaEmpleados
                           orderby empleado.nombreCompleto descending// Ordenar descendentemente
                           select $" {empleado.nombreCompleto} gana {empleado.sueldo} en la ciudad de {empleado.ciudad}.";//Campo a seleccionar.
            
            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ejercicio_007()
        {
            Console.WriteLine("Ejercicio 007-Consulta con transformaciones en select");
            //Origen de datos.
            List<Alumno> listaAlumnos = new List<Alumno>
            {
               new Alumno {nombreCompleto="Felipe Melo",notas=new List<int> {10,15,13,9 } },
               new Alumno {nombreCompleto="Gerardo Martino",notas=new List<int> {11,8,15,18 } },
               new Alumno {nombreCompleto="Jorge Julian",notas=new List<int> {16,19,12,13 } }
            };

            //Creación de la consulta con select tipo string.
            var consulta = from alumno in listaAlumnos
                           orderby alumno.notas.Average() descending// Ordenar descendentemente
                           select $" {alumno.nombreCompleto} tu primera nota es {alumno.notas[0]} y la mas alta es {alumno.notas.Max()}.";//Campo a seleccionar.

            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ejercicio_008()
        {
            Console.WriteLine("Ejercicio 008-Consulta con group by");
            //Origen de datos.
            List<Customers> listaCustomers = new List<Customers>
            {
                new Customers {nombre="Ricardo" , apellido="Sanchez" , ciudad="Lima" },
                new Customers {nombre="Victor" , apellido="Alegria" , ciudad="Arequipá" },
                new Customers {nombre="Julio" , apellido="Felipe" , ciudad="Lima" },
            };


            //Consulta con group by sin select.
            var listaCustomerQuerys = from customer in listaCustomers
                           group customer by customer.ciudad;//Campo a agrupar y elemento por el cual agrupar.

            //Ejecutar la consulta con lista dentro de lista por el group by.
            foreach (var customerGroup in listaCustomerQuerys)
            {
                Console.WriteLine($"Personas en ciudad de {customerGroup.Key}");//Criterio con ciudades
                foreach (Customers customer in customerGroup)//Lista con elementos agrupados.
                {
                    Console.WriteLine($"    Nombre: {customer.nombre}, Apellido: {customer.apellido}");
                }
            }
        }

        public static void Ejercicio_009()
        {
            Console.WriteLine("Ejercicio 009-Consulta con group by");
            //Origen de datos.
            List<Empleado> listaEmpleado = new List<Empleado>
            {
                new Empleado {nombre="Pepe" , apellido="Lucho" ,sueldo=1200 },
                new Empleado {nombre="Christian", apellido="Perez" ,sueldo=1300 },
                new Empleado {nombre="Nicolas", apellido="Alva" ,sueldo=1200 },
                new Empleado {nombre="Charo", apellido="Gonzalez" ,sueldo=1200 },
                new Empleado {nombre="Paolo", apellido="Farfan" ,sueldo=1300 }
            };


            //Consulta con group by sin select.
            var listaEmpleadoQuerys = from empleado in listaEmpleado
                                      group empleado by empleado.sueldo;

            //Ejecutar la consulta con lista dentro de lista por el group by.
            foreach (var empleadoGroup in listaEmpleadoQuerys)
            {
                Console.WriteLine($"Personas con sueldo de {empleadoGroup.Key}");//Criterio con sueldo.
                foreach (Empleado empleado in empleadoGroup)//Lista con elementos agrupados.
                {
                    Console.WriteLine($"    El nombre es: {empleado.nombre}, su sueldo es: {empleado.sueldo}");
                }
            }
        }

        public static void Ejercicio_010()
        {
            Console.WriteLine("Ejercicio 010-Consulta con having");
            //Origen de datos.
            //Origen de datos.
            List<Customers> listaCustomers = new List<Customers>
            {
                new Customers {nombre="Ricardo" , apellido="Sanchez" , ciudad="Lima" },
                new Customers {nombre="Victor" , apellido="Alegria" , ciudad="Arequipá" },
                new Customers {nombre="Julio" , apellido="Felipe" , ciudad="Lima" },
            };

            //Consulta con group by con select.
            var listaCustomerQuerys = from customer in listaCustomers
                                      group customer by customer.ciudad into cantidad //cantidad permite ser el nuevo valor.
                                      where cantidad.Count() > 1//condicional que indica que la lista tenga mas de un elemento.
                                      select cantidad;//

            //Ejecutar la consulta con lista dentro de lista por el group by.
            foreach (var customerGroup in listaCustomerQuerys)
            {
                Console.WriteLine($"Personas en la ciudad {customerGroup.Key}");//Criterio con ciudades
                foreach (Customers customer in customerGroup)//Lista con elementos agrupados.
                {
                    Console.WriteLine($"    El nombre es: {customer.nombre}, su apellido es: {customer.apellido}");
                }
            }
        }

        public static void Ejercicio_011()
        {
            Console.WriteLine("Ejercicio 011-Consulta con having");
            //Origen de datos.
            List<Empleado> listaEmpleado = new List<Empleado>
            {
                new Empleado {nombre="Cecilia" , apellido="Fito" ,sueldo=2500 },
                new Empleado {nombre="Pepe", apellido="Lucho" ,sueldo=1200 },
                new Empleado {nombre="Jose", apellido="Perez" ,sueldo=1300 },
                new Empleado {nombre="Nicolas", apellido="Mendez" ,sueldo=1200 },
                new Empleado {nombre="Charo", apellido="Gonzalez" ,sueldo=1200 },
                new Empleado {nombre="Paolo", apellido="Farfan" ,sueldo=1300 }
            };

            //Consulta con group by con select.
            var listaEmpleadoQuerys = from empleado in listaEmpleado
                                      group empleado by empleado.sueldo into empleado_sueldo
                                      where empleado_sueldo.Count()>2
                                      select empleado_sueldo;

            //Ejecutar la consulta con lista dentro de lista por el group by.
            foreach (var empleadoGroup in listaEmpleadoQuerys)
            {
                Console.WriteLine($"Personas con sueldo de {empleadoGroup.Key}");//Criterio con sueldo.
                foreach (Empleado empleado in empleadoGroup)//Lista con elementos agrupados.
                {
                    Console.WriteLine($"    El nombre es: {empleado.nombre}, su apellido es: {empleado.apellido}, su sueldo es: {empleado.sueldo}");
                }
            }
        }

        
        public static void Ejercicio_012()
        {
            Console.WriteLine("Ejercicio 012-Consulta con join");
            //Origen de datos.
            List<ModalidadContrato> listaModalidad = new List<ModalidadContrato>
            {
                new ModalidadContrato {idModalidad=1 , nombreModalidad="CAS" },
                new ModalidadContrato {idModalidad=2 , nombreModalidad="Temporal" },
            };
            List<EmpleadoModalidad> listaEmpleado = new List<EmpleadoModalidad>
            {
                new EmpleadoModalidad {idEmpleado=1 , nombre="Pedro" , idModalidad=1 },
                new EmpleadoModalidad {idEmpleado=2 , nombre="Jorge" , idModalidad=2 },
                new EmpleadoModalidad {idEmpleado=3 , nombre="Erazmo" , idModalidad=1 },
                new EmpleadoModalidad {idEmpleado=4 , nombre="Julio" , idModalidad=3 }
            };

            //Consulta con join.
            var listaEmpleados = from empleado in listaEmpleado
                                 join modalidad in listaModalidad
                                 on empleado.idModalidad equals modalidad.idModalidad
                                 select new { empleado.nombre , modalidad.nombreModalidad};

            //Ejecutar la consulta con lista del nuevo objeto creado.
            foreach (var empleado in listaEmpleados)
            {
                Console.WriteLine($"{empleado.nombre} tiene la modalidad {empleado.nombreModalidad}");//Mostrar conforme al nuevo objeto basado en el join.
            }
        }

        public static void Ejercicio_013()
        {
            Console.WriteLine("Ejercicio 013-Consulta con join múltiple");
            //Origen de datos.
            List<Categoria> listaCategoria = new List<Categoria>
            {
                new Categoria{idCategoria=1 , nombreCategoria="Fruta"},
                new Categoria {idCategoria=2 , nombreCategoria="Verdura"}
            };
            List<Proveedor> listaProveedor = new List<Proveedor>
            {
                new Proveedor{idProveedor=1 , nombre="ABC"},
                new Proveedor {idProveedor=2 , nombre="CDE"}
            };
            List<Producto> listaProducto = new List<Producto>
            {
                new Producto{idProducto=1 , nombre="Fruta" , idCategoria=1 , idProveedor=1},
                new Producto {idProducto=2 , nombre="Verdura" , idCategoria=2 , idProveedor=2},
                new Producto {idProducto=2 , nombre="AOL" , idCategoria=2 , idProveedor=1}
            };

            //Consulta con join múltiple.
            var listaProductos = from producto in listaProducto
                                 join proveedor in listaProveedor
                                 on producto.idProveedor equals proveedor.idProveedor //Se coloca la llave del campo del from primero.
                                 join categoria in listaCategoria
                                 on producto.idCategoria equals categoria.idCategoria//Join con la categoria.
                                 select new { producto.nombre, nombreProveedor= proveedor.nombre, categoria.nombreCategoria};//Crea un nuevo objeto con los campos deseados.

            //Ejecutar la consulta con lista del nuevo objeto creado.
            foreach (var producto in listaProductos)
            {
                Console.WriteLine($"El producto {producto.nombre} del proveedor {producto.nombreProveedor} tiene la categoría {producto.nombreCategoria}");//Mostrar conforme al nuevo objeto basado en el join.
            }
        }

        public static void Ejercicio_014()
        {
            Console.WriteLine("Ejercicio 014-Consulta con join múltiple");
            //Origen de datos.
            List<Genero> listaGenero = new List<Genero>
            {
                new Genero{idGenero=1 , nombreGenero="Masculino"},
                new Genero{idGenero=2 , nombreGenero="Femenino"},
            };
            List<ModalidadContratoGenero> listaModalidad = new List<ModalidadContratoGenero>
            {
                new ModalidadContratoGenero {idModalidadContrato=1 , nombreModalidadContrato="CAS" },
                new ModalidadContratoGenero {idModalidadContrato=2 , nombreModalidadContrato="Temporal" },
            };
            List<EmpleadoGenero> listaEmpleado = new List<EmpleadoGenero>
            {
                new EmpleadoGenero { nombre="Andrea" , idEmpleado=1 , idModalidadContrato=1, idGenero=2 },
                new EmpleadoGenero { nombre="Jorge" , idEmpleado=2 , idModalidadContrato=2, idGenero=1 },
                new EmpleadoGenero { nombre="Rogelia" ,idEmpleado=3 , idModalidadContrato=2, idGenero=2 },
                new EmpleadoGenero { nombre="Julio" , idEmpleado=4 , idModalidadContrato=1, idGenero=1 }
            };

            //Consulta con join múltiple.
            var listaEmpleados = from empleado in listaEmpleado
                                 join modalidad in listaModalidad
                                 on empleado.idModalidadContrato equals modalidad.idModalidadContrato //Se coloca la llave del campo del from primero.
                                 join genero in listaGenero
                                 on empleado.idGenero equals genero.idGenero//Join con el genero.
                                 select new { empleado.nombre, modalidad.nombreModalidadContrato, genero.nombreGenero };//Crea un nuevo objeto con los campos deseados.

            //Ejecutar la consulta con lista del nuevo objeto creado.
            foreach (var empleado in listaEmpleados)
            {
                Console.WriteLine($"Empleado {empleado.nombre} con modalidad {empleado.nombreModalidadContrato} tiene género {empleado.nombreGenero}.");//Mostrar conforme al nuevo objeto basado en el join.
            }
        }

        public static void Ejercicio_015()
        {
            Console.WriteLine("Ejercicio 015-Consulta con expresion lambda");
            //Origen de datos.
            List<Customers> listaCustomers = new List<Customers>
            {
                new Customers {nombre="Ricardo" , apellido="Sanchez" , ciudad="Lima" },
                new Customers {nombre="Victor" , apellido="Alegria" , ciudad="Arequipá" },
                new Customers {nombre="Julio" , apellido="Felipe" , ciudad="Lima" },
            };


            //Consulta Lambda
            var consulta = listaCustomers.Where(c => c.ciudad.Equals("Lima")).Select(c => c);
            //Consulta equivalente
            //IEnumerable<Customers> consulta = from item in listaCustomers
            //                                  where item.ciudad.Equals("Lima")//Compara la cadena.
            //                                  select item; //Campos que contendra el resultado.
            //Ejecutar la consulta.
            foreach (var item in consulta)
            {
                Console.WriteLine($" Aquellos que viven en Lima son: {item.nombre} {item.apellido}");
            }
        }

        public static void Ejercicio_016()
        {
            Console.WriteLine("Ejercicio 016-Consulta where con lambda.");
            //Origen de datos.
            List<EmpleadoModalidad> listaEmpleado = new List<EmpleadoModalidad>
            {
                new EmpleadoModalidad {idEmpleado=1 , nombre="Pedro" , idModalidad=1 },
                new EmpleadoModalidad {idEmpleado=2 , nombre="Jorge" , idModalidad=2 },
                new EmpleadoModalidad {idEmpleado=3 , nombre="Erazmo" , idModalidad=1 },
                new EmpleadoModalidad {idEmpleado=4 , nombre="Julio" , idModalidad=3 }
            };

            //Consulta con lambda en where.
            var listaEmpleados = listaEmpleado.Where(p => p.idModalidad.Equals(1));

            //Ejecutar la consulta lambda.
            foreach (var empleado in listaEmpleados)
            {
                Console.WriteLine($"Nombre: {empleado.nombre}.");//Mostrar la consulta.
            }
        }

        public static void Ejercicio_017()
        {
            Console.WriteLine("Ejercicio 017-Consulta expresiones con lambda.");
            //Origen de datos.
            List<AlumnoMateria> listaEmpleado = new List<AlumnoMateria>
            {
                new AlumnoMateria {idAlumno=1 , nombre="Algebra" },
                new AlumnoMateria {idAlumno=1 , nombre="Trigonometria" }
            };

            //Consulta con lambda en where.
            var listaAlumnos = listaEmpleado.Select(p => p.nombre);

            //Ejecutar la consulta lambda.
            foreach (var alumno in listaAlumnos)
            {
                Console.WriteLine($"Materia preferida: {alumno}.");//Mostrar la consulta.
            }
        }

        public static void Ejercicio_018()
        {
            Console.WriteLine("Ejercicio 018-Consulta orderby con lambda.");
            //Origen de datos.
            List<EmpleadoModalidad> listaEmpleado = new List<EmpleadoModalidad>
            {
                new EmpleadoModalidad {idEmpleado=1 , nombre="Pedro" , idModalidad=1 },
                new EmpleadoModalidad {idEmpleado=2 , nombre="Jorge" , idModalidad=2 },
                new EmpleadoModalidad {idEmpleado=3 , nombre="Erazmo" , idModalidad=1 },
                new EmpleadoModalidad {idEmpleado=4 , nombre="Julio" , idModalidad=3 }
            };

            //Consulta con lambda en orderby.
            var listaEmpleados = listaEmpleado
                .Select(e => new { e.nombre, e.idModalidad })
                .OrderBy(x => x.nombre);

            //Ejecutar la consulta lambda.
            foreach (var empleado in listaEmpleados)
            {
                Console.WriteLine($"Nombre: {empleado.nombre} IdModalidad: {empleado.idModalidad}.");//Mostrar la consulta.
            }
        }
    }
}
