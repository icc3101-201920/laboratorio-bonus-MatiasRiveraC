using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace big_sister_base
{
    public class BigSister
    {
        List<string> allowed = new List<string> { "Leche Entera", "Mantequilla", "Pimienta","Malla de Cebollas","Sal Lobos", "Láminas de Lasaña", "Harina", "Queso Rallado Parmesano",
                "Vino Sauvignon Blanc Reserva Botella", "Carne Molida", "Tomates Pelados en lata", "Bolsa de Zanahorias","Aceite de Oliva" };
        public void OnAddProduct(object source, EventProduct e)
        {
            LittleGuy littleGuy = (LittleGuy)source;
            foreach(Product product in littleGuy.ShopList)
            {
                if(product.Name == e.Product.Name)
                {
                    if (product.Stock == 0)
                    {
                        littleGuy.RemoveProduct(e.Product);
                        Console.WriteLine("Producto no permitido");
                        Thread.Sleep(3000);
                    }
                    else 
                    {

                        int cont = 0;
                        foreach (Product cartProduct in littleGuy.Cart.Products)
                        {
                            if (cartProduct.Name == e.Product.Name)
                            {
                                cont++;
                            }

                        }
                       if (cont >=2)
                        {
                            littleGuy.RemoveProduct(e.Product);
                            Console.WriteLine("Producto repetido");
                            Thread.Sleep(3000);
                        }
                        
                    }
                }
            }


        }


        public bool OnCheckPay(object source, EventArgs e)
        {
            LittleGuy littleGuy = (LittleGuy)source;
            List<string> compareList = new List<string>() { };
            foreach(Product product in littleGuy.Cart.Products)
            {
                compareList.Add(product.Name);
            }
            bool Done = false;
            foreach(string item in allowed)
            {
                if (!compareList.Contains(item))
                {
                    Done = true;
                }
            }
            if (Done)
            {
                Console.WriteLine("FALTAN PRODUCTOS!!!!11111!!");
                Thread.Sleep(3000);
                return false;
            }
            return true;
        }

    }
}
