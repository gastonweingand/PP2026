using Services.Dal.Implementations;
using Services.DomainModel.Composite;
using Services.DomainModel.Exceptions.Base;
using Services.Exceptions.Base;
using Services.Exceptions.DataAccess;
using Services.Logic.Infrastructure.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade.ExtensionsMethods
{
    public static class ExceptionManager
    {
        public static void HandleException(Exception ex, object[] args = null)
        {
            //en un futuro cercano DINÁMICAMENTE sabremos de dónde viene esta exception
            //switch(ex.GetType()) {

            if (ex is DataAccessException)
            {
                //Aplicamos la política de excepciones para DataAccessException
                //1) Registrar la excepción
                var context = new ExceptionContext
                {
                    Exception = ex,
                    MethodName = nameof(HandleException),
                    ClassName = nameof(ExceptionManager),
                    LogLevel = DomainModel.LogLevel.Error,
                    Arguments = args
                };
                ExceptionLogger.Log(context);

                //2) Propagar
                throw ex;
            }
            else if (ex is BusinessRuleException)
            {
                //Son excepciones esperadas en la capa Logic (BLL)

                //Opción A -> Nativa de Logic o BLL


                //Opción B -> DAL?


            }
            else if (ex is UIException)
            {

            }
            else
            {
                //Otro tipo de excepciones de las cuales no conozco el tipado (Por ahora)

            }
        }
    }
}
