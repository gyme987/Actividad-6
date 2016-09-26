/*
 * Creado por SharpDevelop.
 * Usuario: gymena
 * Fecha: 23/09/2016
 * Hora: 23:31
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace EJE1
{
	/// <summary>
	/// Description of Prestamos.
	/// </summary>
	public class Prestamos
	{
		private StreamReader lectura;
		private StreamWriter escritura, temporal;

		//private int nregs;
		bool encontrado;
		private string respuesta, codigo, cadena;
		static string[] campos = new string[12];
		
		public Prestamos()
		{
			escritura = File.AppendText(@"prestamos.txt");
			escritura.Close();
		}
		public void crearArchivo(){
			escritura = File.AppendText("prestamos.txt");
			escritura.Close();
		} 
				
		public void modificar()
		{
			encontrado = false;
			string nuevoPre;
			try{
				lectura = File.OpenText("prestamos.txt");
				temporal = File.CreateText("tmp.txt");
				Console.Write("Ingrese el Numero del Prestamo: ");
				codigo = Console.ReadLine();
				codigo.ToUpper();
				cadena = lectura.ReadLine();
				while(cadena != null)
				{
					campos = cadena.Split('-');
					if(campos[0].Trim().Equals(codigo))
					{
						encontrado = true;
						Console.WriteLine("******************************");
						Console.WriteLine("*****Datos encontrados *****");
						Console.WriteLine();
						Console.WriteLine("N° Prestamo: " + campos[0].Trim());
						Console.WriteLine("Dni: " + campos[1].Trim());
						Console.WriteLine("Nombre de solicitante: " + campos[2].Trim());
						Console.WriteLine("Apellido de solicitante: " + campos[3].Trim());
						//Console.WriteLine("Telefono casa: " + campos[4].Trim());
						//Console.WriteLine("Telefono celular: " + campos[5].Trim());
						Console.WriteLine("Valor del prestamo: " + campos[6].Trim());
						Console.WriteLine("Fecha de Autorizacion: " + campos[13].Trim());
						Console.WriteLine();
						if (campos[13].Trim().Equals(""))
						{
							Console.WriteLine("******************************");
							Console.Write("Es el registro que buscabas (SI/NO): ");
							respuesta = Console.ReadLine();
							respuesta = respuesta.ToUpper();
											
							Console.WriteLine("respuesta "+respuesta);
							if (respuesta.Equals("SI"))
							{
							Console.Write("Ingrese nuevo Monto: ");
							nuevoPre= Console.ReadLine();
							//nuevoPre = Convert.ToDouble(Console.ReadLine());
							
							temporal.WriteLine(campos[0]+"-"+campos[1]+"-"+campos[2]+"-"+campos[3]+"-"+campos[4]+"-"+campos[5]+"-"+nuevoPre+"-"+campos[7]+"-"+campos[8]+"-"+campos[9]+"-"+campos[10]+"-"+campos[11]+"-"+campos[12]+"-"+campos[13]+"-"+campos[14]);
							Console.WriteLine("*****************************************");
							Console.WriteLine("*** Registro modificado correctamente ***");
							Console.WriteLine();
				       		Console.WriteLine("N° Prestamo: " + campos[0].Trim());
				       		Console.WriteLine("Dni: " + campos[1].Trim());
					        Console.WriteLine("Nombre del solicitante: " + campos[2].Trim());
					        Console.WriteLine("Apellido del solicitante: "+campos[3].Trim());
					    	
						    Console.WriteLine("Valor del Prestamo: " + nuevoPre);
						    Console.WriteLine("Fecha de Autorizacion: " + campos[13].Trim());
					        Console.WriteLine();
							Console.WriteLine("*****************************************");			
							}
							else
							{
								temporal.WriteLine(cadena);
							}
							//temporal.WriteLine(cadena);
						}
						else
						{	
							Console.WriteLine("No se puede modificar este prestamo, ya que se le asigo fecha de Autorizacion");
							Console.WriteLine();
							temporal.WriteLine(cadena);
						}
					}
					else
					{
						temporal.WriteLine(cadena);
					}
					cadena = lectura.ReadLine();						
				}
				if(encontrado == false){
					Console.WriteLine("*******************************************************");
					Console.WriteLine("*** El N° de prestamo ingresado no está en la base de datos ***");
					Console.WriteLine("*******************************************************");
				}
				lectura.Close();
				temporal.Close();
				File.Delete("prestamos.txt");
				File.Move("tmp.txt","prestamos.txt");
			}catch(FileNotFoundException fn){
				Console.WriteLine("*************************");
				Console.WriteLine("Error!! " + fn.Message);
				Console.WriteLine("*************************");
			}catch(Exception e){
				Console.WriteLine("*************************");
				Console.WriteLine("Error!! " + e.Message);
				Console.WriteLine("*************************");
			}finally{
				lectura.Close();
				temporal.Close();
			}
		}	
	}
}
