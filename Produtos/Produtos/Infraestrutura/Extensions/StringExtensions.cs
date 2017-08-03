using System;
using System.Globalization;
using System.Text;

namespace Produtos.Infraestrutura.Extensions
{
    public static class StringExtensions
    {
        public static string RemoverAcentos(this string palavra)
        {
            if (string.IsNullOrEmpty(palavra))
                return palavra;

            string stringNormalizada =
                palavra.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();

            for (int index = 0; index < stringNormalizada.Length; ++index)
            {
                char c = stringNormalizada[index];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            }
            return builder.ToString().ToLower();
        }

        public static string Formatar(this string mensagem, params string[] termos)
        {
            return string.Format(mensagem, termos);
        }
    }
}
