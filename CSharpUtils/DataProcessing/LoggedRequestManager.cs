using CSharpUtils.EntityModel;
using CSharpUtils.Enum;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpUtils.DataProcessing
{
    public static class LoggedRequestManager
    {
        /// <summary>
        /// Dictionary used to support class being used with multiple database in a single project
        /// without needed to convert it from a static class to a non static class
        /// </summary>
        private static Dictionary<Type,Func<DbContext>> databaseContexts = new Dictionary<Type, Func<DbContext>>();

        public static void SetEntityContext<T>(Func<T> getEntityContext) where T : DbContext
        {
            Type type = typeof(T);

            if (!databaseContexts.ContainsKey(type))
            {
                databaseContexts.Add(type, getEntityContext);
            }
        }

        public static bool AddRequest<T>(Func<T, DbSet<RequestsToProcess>> getRequestTable, object requestData) where T : DbContext
        {
            Type type = typeof(T);

            if (!databaseContexts.ContainsKey(type))
            {
                return false;
            }

            try
            {
                using (T context = (T)databaseContexts[type].Invoke())
                {
                    RequestsToProcess newRequest = new RequestsToProcess();
                    newRequest.DataAsJson = JsonConvert.SerializeObject(requestData);

                    getRequestTable.Invoke(context).Add(newRequest);

                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ScheduleRequest<T>(Func<T, RequestsToProcess[]> getRequestCall, Action<int> scheduleRequestCall) where T : DbContext
        {
            Type type = typeof(T);

            if (!databaseContexts.ContainsKey(type))
            {
                return false;
            }

            using (T context = (T)databaseContexts[type].Invoke())
            {
                RequestsToProcess[] requestsToProcess = getRequestCall.Invoke(context);

                foreach (var request in requestsToProcess)
                {
                    scheduleRequestCall.Invoke(request.Id);
                    request.ProcessingStatus = ProcessingStatus.Scheduled;
                    request.WhenLastUpdated = DateTime.Now;
                    context.SaveChanges();
                }

                return true;
            }
        }

        public static bool ProcessRequest<T>(Func<T, RequestsToProcess> getRequestCall, Func<string?, bool> processRequestCall) where T : DbContext
        {
            Type type = typeof(T);

            if (!databaseContexts.ContainsKey(type))
            {
                return false;
            }

            using (T context = (T)databaseContexts[type].Invoke())
            {
                RequestsToProcess request = getRequestCall.Invoke(context);

                try
                {
                    request.ProcessingStatus = ProcessingStatus.BeingProcessed;
                    request.WhenLastUpdated = DateTime.Now;
                    context.SaveChanges();

                    // process transcription
                    bool processed = processRequestCall.Invoke(request.DataAsJson);

                    if (processed)
                    {
                        request.ProcessingStatus = ProcessingStatus.Processed;
                        request.WhenLastUpdated = DateTime.Now;
                        context.SaveChanges();

                        return true;
                    }
                    else
                    {
                        request.ProcessingStatus = ProcessingStatus.Errored;
                        request.FailCount += 1;
                        request.WhenLastUpdated = DateTime.Now;
                        context.SaveChanges();

                        return false;
                    }

                }
                catch
                {
                    request.ProcessingStatus = ProcessingStatus.Errored;
                    request.FailCount += 1;
                    request.WhenLastUpdated = DateTime.Now;
                    context.SaveChanges();

                    return false;
                }
            }
        }
    }
}

