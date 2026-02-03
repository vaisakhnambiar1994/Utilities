using GoetheApp.Core.Extensions;
using GoetheApp.ExceptionUtilities.MetaModels;
using System.Diagnostics;

namespace GoetheApp.ExceptionUtilities
{
    public class StackTraceParser
    {
        /// <summary>
        /// Parse stack trace
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public StackTraceMetaData Parse(Exception exception)
        {
            var stackTrace = new StackTrace(exception, true);
            var frameList = new List<StackFrameMetaData>();
            var stackFrames = stackTrace.GetFrames();
            int index = 1;
            foreach (var stackFrame in stackFrames)
            {
                var method = stackFrame.GetMethod();
                var fileName = stackFrame.GetFileName();
                if (method == null || fileName == null)
                    continue;

                var methodName = method?.DeclaringType?.Name.GetBetweenString("<", ">");
                var frameData = new StackFrameMetaData
                {
                    Index = index,
                    MethodName = string.IsNullOrEmpty(methodName) ? method.Name : methodName,
                    ColumnNumber = stackFrame.GetFileColumnNumber(),
                    LineNumber = stackFrame.GetFileLineNumber(),
                    FileName = fileName
                };

                index++;
                frameList.Add(frameData);
            }
            return new StackTraceMetaData
            {
                Identifier = GetStackFrameHash(frameList),
                StackFrames = frameList
            };
        }

        private string GetStackFrameHash(List<StackFrameMetaData> stackFrames)
        {
            var stringInput = "";
            foreach (var frame in stackFrames)
                stringInput = stringInput + frame.Index + frame.FileName + frame.MethodName + frame.LineNumber;
            return stringInput;
        }
    }
}
