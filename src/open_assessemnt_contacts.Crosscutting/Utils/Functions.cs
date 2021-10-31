using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Assessement.Contacts.Crosscutting.Utils
{
    public static class Functions
    {

        /// <summary>
        /// Retorna um Enumerable com os dias com relação a um periodo.
        /// </summary>
        /// <param name="dataInicial">Data Inicial.</param>
        /// <param name="dataFinal">Data Final.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> ReturnsDatesList(DateTime dataInicial, DateTime dataFinal)
        {
            for (var day = dataInicial.Date; day.Date <= dataFinal.Date; day = day.AddDays(1))
                yield return day;
        }

    }
}
