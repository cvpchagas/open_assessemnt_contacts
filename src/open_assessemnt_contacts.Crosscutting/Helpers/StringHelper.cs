using Open.Assessement.Contacts.Crosscutting.Enums;
using Open.Assessement.Contacts.Crosscutting.Extensions;
using Open.Assessement.Contacts.Crosscutting.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Open.Assessement.Contacts.Crosscutting.Helpers
{
    public class StringHelper
    {
        public static string ConcatenaMensagem(string mensagemAtual, string mensagemNova, string divisor = null)
        {
            if (string.IsNullOrEmpty(mensagemAtual))
            {
                return mensagemNova;
            }
            else
            {
                return string.Concat(mensagemAtual, (string.IsNullOrEmpty(divisor) ? Environment.NewLine : divisor), mensagemNova);
            }
        }
        public static string RemoveEspacosConverteEmMaiusculo(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            return texto.Trim().ToUpper();
        }
        public static string RemoveAcentos(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            StringBuilder sbReturn = new StringBuilder();
            var arrayText = texto.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
        public static string SubstituiCaracteres(string texto, string textoOrigem, string textoDestino)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            return texto.Replace(textoOrigem, textoDestino);
        }
        public static string RemoveCaracteresEspeciais(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            return Regex.Replace(texto, "[^a-zA-Z0-9]", " ", RegexOptions.Compiled);
        }

    }
}