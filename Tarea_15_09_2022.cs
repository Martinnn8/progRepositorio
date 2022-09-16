using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static Tarea_15_09_2022.CTarea_15_09_2022;

namespace Tarea_15_09_2022
{
    internal class CTarea_15_09_2022
    {

        // Tarea_15_09_2022

        static void Main()
        {
            //Llamo el método desde el main
            Console.WriteLine(StringReverse("hola mundo"));
        }
        public static string StringReverse(string cadena)
        {
            string response = "";
            char[] caracteres = cadena.ToCharArray(); //convertimos la cadena a un array de caracteres

            Stack miPila = new Stack();//declaro la pila

            foreach (var item in caracteres)
            {
                miPila.Push(item);//voy apilando los caracteres de la cadena
            }

            while (miPila.Count > 0)
            { //itero hasta vacear la pila
                response += miPila.Pop();  //voy desapilando los caracteres y los concateno
                                           //también podríamos haber hecho un peek pero luego un pop
            }
            return response;
        }

        public class Alumno
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public int Edad { get; set; }
        }

        Stack<Alumno> pila = new Stack<Alumno>();
        pila.Push(new Alumno { Id = 1, Nombre = "Gerson", Edad = 32 }); //apilamos elementos
        pila.Push(new Alumno { Id = 2, Nombre = "Eder", Edad = 42 });
        pila.Push(new Alumno { Id = 3, Nombre = "Rosa", Edad = 12 });

        Console.WriteLine(pila.Count);//3-> Muestra el número de elementos de la pila           
        Console.WriteLine(pila.Peek().Nombre);//Rosa -> Muestra el primero de la pila
        Console.WriteLine(pila.Pop().Nombre);//Rosa -> Muestra el primero y borra
        Console.WriteLine(pila.Peek().Nombre);//Eder -> Ahora el primero es Eder
        Console.WriteLine(pila.Count);//2-> Ahora hay dos


// Cola


[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
public interface IOrderProcessor
{
    [OperationContract(IsOneWay = true)]
    void SubmitPurchaseOrder(PurchaseOrder po);
}

[DataContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
public class PurchaseOrder
{
    static readonly string[] OrderStates = { "Pending", "Processed", "Shipped" };
    static Random statusIndexer = new Random(137);

    [DataMember]
    public string PONumber;

    [DataMember]
    public string CustomerId;

    [DataMember]
    public PurchaseOrderLineItem[] orderLineItems;

    public float TotalCost
    {
        get
        {
            float totalCost = 0;
            foreach (PurchaseOrderLineItem lineItem in orderLineItems)
                totalCost += lineItem.TotalCost;
            return totalCost;
        }
    }

    public string Status
    {
        get
        {
            return OrderStates[statusIndexer.Next(3)];
        }
    }

    public override string ToString()
    {
        System.Text.StringBuilder strbuf = new System.Text.StringBuilder("Purchase Order: " + PONumber + "\n");
        strbuf.Append("\tCustomer: " + CustomerId + "\n");
        strbuf.Append("\tOrderDetails\n");

        foreach (PurchaseOrderLineItem lineItem in orderLineItems)
        {
            strbuf.Append("\t\t" + lineItem.ToString());
        }

        strbuf.Append("\tTotal cost of this order: $" + TotalCost + "\n");
        strbuf.Append("\tOrder status: " + Status + "\n");
        return strbuf.ToString();
    }
}



    }
}

// SINGLETON

namespace RefactoringGuru.DesignPatterns.Singleton.Conceptual.NonThreadSafe
{
  
    public sealed class Singleton
    {
     
        private Singleton() { }

    
        private static Singleton _instance;

       
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

       
        public void someBusinessLogic()
        {
            // ...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton funciona, ambas variables en las mismas intancias");
            }
            else
            {
                Console.WriteLine("Singleton fallo, error");
            }
        }
    }
}
