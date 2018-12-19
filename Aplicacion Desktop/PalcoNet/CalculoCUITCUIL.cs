using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet
{
    public partial class CalculoCUITCUIL   
    {

        private static CalculoCUITCUIL instance = null;

        public CalculoCUITCUIL() { }

        public static CalculoCUITCUIL getInstance()
        {
            if (instance == null)
                instance = new CalculoCUITCUIL();
            return instance;
        }

        public static bool cuitEsValido(string cuit)
        {
            cuit = cuit.Replace("-", string.Empty);
            int longitudCadena = cuit.Length;
            if (longitudCadena != 11 || cuit == null)
            {
                return false;
            }
            else
            {   //Aca le mando la cadena de los 11 caracteres
                int digitoVerificadorCalculado = CalcularDigitoVerificador(cuit);
                int digitoVerificadorCadena = int.Parse(cuit.Substring(10));
                return digitoVerificadorCalculado == digitoVerificadorCadena;
            }
        }

        //Va a recibir una cadena de 11 caracteres que son todos numeros
        public static int CalcularDigitoVerificador(string cuit)
        {
            
            char[] arrayCuit = cuit.ToCharArray();
            //Numero sacado a partir de referencias de internet
            int[] arrayNumeroVerificador = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int total = 0;
            for (int i = 0; i < arrayNumeroVerificador.Length; i++)
            {
                total += int.Parse(arrayCuit[i].ToString()) * arrayNumeroVerificador[i];
            }
            //Obtenemos el resto de la division
            var resto = total % 11;
            //return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
            if (resto == 0) return 0;
            if (resto == 1) return 9;
            else { return 11 - resto; }
        }

         
    }
     
}
