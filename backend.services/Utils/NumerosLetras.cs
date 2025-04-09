using iText.Kernel.Pdf.Canvas.Parser.ClipperLib;
using System.Globalization;

namespace backend.services.Utils
{
    public class NumerosLetras
    {
        private string sUnidad(int unidad)
        {
            string[] sUnidades = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
            return sUnidades[unidad];
        }

        private string sDecena(int decena)
        {
            string result = "";
            int unidad = decena % 10;

            if (decena > 10 && decena < 16)
            {
                switch (decena)
                {
                    case 11:
                        result = "once";
                        break;
                    case 12:
                        result = "doce";
                        break;
                    case 13:
                        result = "trece";
                        break;
                    case 14:
                        result = "catorce";
                        break;
                    case 15:
                        result = "quince";
                        break;
                }
            }
            else if ((decena / 10) < 3 && unidad == 0)
            {
                if (decena / 10 == 1) result = "diez";
                if (decena / 10 == 2) result = "veinte";
            }
            else
            {
                string[] sDecenas = { "", "dieci", "veinti", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
                result = sDecenas[decena / 10];
                if (unidad > 0)
                {
                    if ((decena / 10) < 3)
                    {
                        result += sUnidad(unidad);
                    }
                    else
                    {
                        result += " y " + sUnidad(unidad);
                    }
                }
            }
            return result;
        }

        private string sCentena(int centena)
        {
            string result = "";
            int decena = centena % 100;
            if (centena > 100)
            {
                string[] centenas = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };
                result = centenas[centena / 100];
                if (decena > 0) result += " " + sDecena(decena);
            }
            else
            {
                result = "cien";
            }
            return result;
        }

        private string sConvertirGrupo(int numero)
        {
            if ((numero / 100) > 0) return sCentena(numero);
            else if ((numero / 10) > 0) return sDecena(numero);
            else return sUnidad(numero);
        }

        public string sConvertir(decimal numero)
        {
            CultureInfo ci_PE = new CultureInfo("es-PE");
            string sNumero = string.Format(ci_PE, "{0:0,0.00}", numero);
            string result = "";
            int entero = (int)Math.Truncate(numero);
            string sDecimal = sNumero.Contains(".") ? "con " + string.Format(ci_PE, "{0:0,0.00}", Math.Round(numero, 2)).Split('.')[1] + "/100" : "con 00/100";

            if ((entero / 1000000) > 0)
            {
                if ((entero / 1000000) == 1) result += "Un millón ";
                else result += sConvertirGrupo(entero / 1000000) + " millones ";

                entero %= 1000000;
            }

            if ((entero / 1000) > 0)
            {
                if ((entero / 1000) == 1) result += "Mil ";
                else result += sConvertirGrupo(entero / 1000) + " mil ";
                entero %= 1000;
            }

            if (entero > 0)
            {
                result += sConvertirGrupo(entero);
            }

            return (result + " " + sDecimal).Trim().ToUpper();
        }
    }
}
