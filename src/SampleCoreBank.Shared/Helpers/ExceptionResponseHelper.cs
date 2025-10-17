using SampleCoreBank.Shared.Abstractions.Domain.Exceptions;
using SampleCoreBank.Shared.Extensions;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleCoreBank.Shared.Helpers
{
    public static class ExceptionResponseHelper
    {
        public static Tuple<int, int, object, Dictionary<string, object>, Dictionary<string, object>, string, long?> CreateTuple(IStringLocalizer localizer, object request, Exception exception, string message = "Falha na operação!", long? resultCount = null)
        {
            string localizedMessage = localizer[message].ToString();

            if (exception is BusinessException)
            {
                var businessException = exception as BusinessException;
                return (businessException.ExceptionCode, businessException.ExceptionInternalCode, request, default(Dictionary<string, object>), MapCoreBankExceptionToDictionary(localizer, businessException), localizedMessage, resultCount).ToTuple();
            }

            if (exception is CoreBankException)
            {
                var coreBankException = exception as CoreBankException;
                return (coreBankException.ExceptionCode, coreBankException.ExceptionInternalCode, request, default(Dictionary<string, object>), MapCoreBankExceptionToDictionary(localizer, coreBankException), localizedMessage, resultCount).ToTuple();
            }

            return (400, 400, request, default(Dictionary<string, object>), MapExceptionToDictionary(localizer, exception), localizedMessage, resultCount).ToTuple();
        }
        internal static Dictionary<string, object> MapExceptionToDictionary(IStringLocalizer localizer, Exception exception)
        {
            if (exception is BusinessException)
            {
                return MapBusinessExceptionToDictionary(localizer, exception as BusinessException);
            }

            if (exception is CoreBankException)
            {
                return MapCoreBankExceptionToDictionary(localizer, exception as CoreBankException);
            }

            Dictionary<string, object> exceptionDictionary = new Dictionary<string, object>
            {
                { "message", localizer[exception.Message].ToString() }
            };

            if (exception.InnerException != null)
            {
                exceptionDictionary.Add("innerNotification", MapExceptionToDictionary(localizer, exception.InnerException));
            }

            return exceptionDictionary;
        }
        internal static Dictionary<string, object> MapCoreBankExceptionToDictionary(IStringLocalizer localizer, CoreBankException coreBankException)
        {
            Dictionary<string, object> exceptionDictionary = new Dictionary<string, object>
            {
                { "message", localizer[coreBankException.Message].ToString() }
            };

            if (coreBankException.InnerException != null)
            {
                exceptionDictionary.Add("innerNotification", MapExceptionToDictionary(localizer, coreBankException.InnerException));
            }

            return exceptionDictionary;
        }
        internal static Dictionary<string, object> MapBusinessExceptionToDictionary(IStringLocalizer localizer, BusinessException businessException)
        {
            Dictionary<string, object> exceptionDictionary = new Dictionary<string, object>
            {
                { "message", localizer[businessException.Message].ToString() }
            };

            if (businessException.RequestExceptions != null && businessException.RequestExceptions.Count > 0)
            {
                Dictionary<string, object> requestExceptionDictionary = new Dictionary<string, object>();

                foreach (var group in businessException.RequestExceptions.GroupBy(exception => exception.SourceProperty))
                {
                    requestExceptionDictionary.Add(group.Key.ToCamelCase(), businessException.RequestExceptions.Where(exception => exception.SourceProperty.Equals(group.Key)).Select(exception => localizer[exception.Message].ToString()).ToArray());
                }

                exceptionDictionary.Add("requestNotifications", requestExceptionDictionary);
            }

            if (businessException.EntityExceptions != null && businessException.EntityExceptions.Count > 0)
            {
                Dictionary<string, object> entityExceptionDictionary = new Dictionary<string, object>();

                foreach (var group in businessException.EntityExceptions.GroupBy(x => x.SourceProperty))
                {
                    entityExceptionDictionary.Add(group.Key.ToCamelCase(), businessException.EntityExceptions.Where(exception => exception.SourceProperty.Equals(group.Key)).Select(x => localizer[x.Message].ToString()).ToArray());
                }

                exceptionDictionary.Add("entityNotifications", entityExceptionDictionary);
            }

            if (businessException.DomainExceptions != null && businessException.DomainExceptions.Count > 0)
            {
                exceptionDictionary.Add(
                    "domainNotifications",
                    businessException.DomainExceptions
                        .Select(exception => localizer[exception.Message].ToString())
                        .ToArray()
                );
            }

            return exceptionDictionary;
        }
    }
}