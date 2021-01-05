using System;
using System.Reflection;
using System.Text;

namespace UGF.Logs.Runtime
{
    public static class LogUtility
    {
        public const string LOG_INFO_DEFINE = "UGF_LOG_INFO";
        public const string LOG_DEBUG_DEFINE = "UGF_LOG_DEBUG";
        public const string LOG_WARNING_DEFINE = "UGF_LOG_WARNING";
        public const string LOG_ERROR_DEFINE = "UGF_LOG_ERROR";
        public const string LOG_EXCEPTION_DEFINE = "UGF_LOG_EXCEPTION";

        public static string Format(string message, Exception exception)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (exception == null) throw new ArgumentNullException(nameof(exception));

            var builder = new StringBuilder(message);

            builder.AppendLine();
            builder.Append(exception);
            builder.AppendLine();
            builder.Append("--- End of attached exception ---");

            return builder.ToString();
        }

        /// <summary>
        /// Formats the specified object arguments with message.
        /// </summary>
        /// <remarks>
        /// This method formats public properties of specified arguments object into comma separated values,
        /// and returns message with arguments after it.
        /// </remarks>
        /// <example>
        /// As example, method can be used with anonymous types to quickly format message.
        /// <code>
        /// string message = Format("Message", new { argumentA = 10, argumentB = "Argument" });
        ///
        /// Message result: "Message: argumentA:'10', argumentB:'Argument'.".
        /// </code>
        /// </example>
        /// <param name="message">Message to include with formatted arguments.</param>
        /// <param name="arguments">Arguments to format.</param>
        /// <returns>Formatted arguments with message.</returns>
        public static string Format(string message, object arguments)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (arguments == null) throw new ArgumentNullException(nameof(arguments));

            var builder = new StringBuilder(message);

            builder.Append(": ");

            Type type = arguments.GetType();
            PropertyInfo[] properties = type.GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];
                object value = property.GetValue(arguments);

                builder.Append(property.Name);
                builder.Append(":'");
                builder.Append(value);
                builder.Append('\'');

                if (i < properties.Length - 1)
                {
                    builder.Append(", ");
                }
            }

            builder.Append('.');

            return builder.ToString();
        }
    }
}
