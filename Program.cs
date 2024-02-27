using System;
using System.Collections.Generic;

namespace TallerSgbMadelynRestrepoRestrepo
{
    class Program
    {
        static List<Usuario> usuarios = new List<Usuario>();
        static List<Prestamo> prestamos = new List<Prestamo>();
        static List<Libros> CatalogoLibros = new List<Libros>();

        static void Main(string[] args)
        {
            CatalogoLibros.Add(new Libro("El Cuervo", "Edgar Allan Poe"));
            CatalogoLibros.Add(new Libro("Cien años de soledad", "Gabriel García Márquez"));
            CatalogoLibros.Add(new Libro("Diario del fin del mundo ", "Patrick Rothfuss"));

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("¡Bienvenido a la Biblioteca!");
                Console.WriteLine("1. Registrar Usuario");
                Console.WriteLine("2. Registrar Préstamo");
                Console.WriteLine("3. Mostrar Usuarios");
                Console.WriteLine("4. Mostrar Préstamos");
                Console.WriteLine("5. Mostrar Catalogo Libros");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Seleccione una opción:");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarUsuario();
                        break;
                    case "2":
                        RegistrarPrestamo();
                        break;
                    case "3":
                        MostrarUsuarios();
                        break;
                    case "4":
                        MostrarPrestamos();
                        break;
                    case "5":
                       MostrarCatalogolibros();
                        break
                    case "6":

                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }

        static void MostrarCatalogoLibros()
        {
            Console.WriteLine("Catálogo de Libros:");
            foreach (Libro libro in CatalogoLibros)
            {
                Console.WriteLine($"Título: {libro.Titulo}, Autor: {libro.Autor}");
            }
        }

        static void RegistrarUsuario()
        {
            Console.WriteLine("Ingrese el nombre del usuario:");
            string Nombre = Console.ReadLine();
            

            Usuario nuevoUsuario = new Usuario(Nombre );
            usuarios.Add(nuevoUsuario);

            Console.WriteLine("Usuario registrado exitosamente.");
        }

        static void RegistrarPrestamo()
        {
            Console.WriteLine("Ingrese el título del libro:");
            string titulo = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del usuario que realiza el préstamo:");
            string nombreUsuario = Console.ReadLine();

            Usuario usuarioPrestamo = usuarios.Find(u => u.Nombre == nombreUsuario);
            if (usuarioPrestamo == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                return;
            }

            Prestamo nuevoPrestamo = new Prestamo(titulo, usuarioPrestamo);
            prestamos.Add(nuevoPrestamo);

            Console.WriteLine("Préstamo registrado exitosamente.");
        }

        static void MostrarUsuarios()
        {
            Console.WriteLine("Lista de Usuarios:");
            foreach (Usuario usuario in usuarios)
            {
                Console.WriteLine($"Nombre: {usuario.Nombre}");
            }
        }

        static void MostrarPrestamos()
        {
            Console.WriteLine("Lista de Préstamos:");
            foreach (Prestamo prestamo in prestamos)
            {
                Console.WriteLine($"Libro: {prestamo.Titulo}, Usuario: {prestamo.Usuario.Nombre}");
            }
        }
    }

    class Usuario
    {
        public string Nombre { get; set; }


        public Usuario(string nombre, string id)
        {
            Nombre = nombre;
        }

        public Usuario(string nombre)
        {
            Nombre = nombre;
        }
    }

    class Prestamo
    {
        public string Titulo { get; set; }
        public Usuario Usuario { get; set; }

        public Prestamo(string titulo, Usuario usuario)
        {
            Titulo = titulo;
            Usuario = usuario;
        }
    }
}