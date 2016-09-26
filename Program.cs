/*
 * Creado por SharpDevelop.
 * Usuario: gymena
 * Fecha: 23/09/2016
 * Hora: 23:28
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using System.Text;

namespace EJE1
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Console.Title= "Trabajando con Ficheros";
			Prestamos archivo = new Prestamos();
			Console.ForegroundColor = ConsoleColor.Green;
			byte opcion;
			opcion = 0;
			do{
				try{
					Console.WriteLine("Menú de opciones");
					Console.WriteLine("1. Modificacion");
					Console.WriteLine("2. Salir");
					Console.Write("Qué deseas hacer?...");
					opcion = Convert.ToByte(Console.ReadLine());
					switch(opcion)
					{
						case 1:
							archivo.modificar();
							break;
						case 2:
							Console.WriteLine("****************************");
							Console.WriteLine("*** Saliendo del sistema ***");
							Console.WriteLine("****************************");
							break;
						default:
							Console.WriteLine("*************************");
							Console.WriteLine("*** Opción incorrecta ***");
							Console.WriteLine("*************************");
							break;
					}
				}
				catch(FormatException fe)
				{
					Console.WriteLine("*************************");
					Console.WriteLine("Error!! " + fe.Message);
					Console.WriteLine("*************************");
				} catch(Exception e){
					Console.WriteLine("*************************");
					Console.WriteLine("Error!! " + e.Message);
					Console.WriteLine("*************************");
				}
			}while(opcion!=2);
			Console.ReadKey(true);
		}
	}
}